using AutoMapper;
using Bluestone.CrossCuttingConcerns.Helpers;
using Bluestone.CrossCuttingConcerns.OS;
using Bluestone.Domain.Entities.Identity.RequestModels;
using Bluestone.Domain.Entities.Identity.ViewModels;
using Bluestone.Domain.Entities.Users.ViewModels;
using Bluestone.Domain.Identity;
using Bluestone.Domain.Services.Identity;
using Bluestone.Domain.Services.Users;
using Bluestone.WebAPI.ConfigurationOptions;
using MediatR;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bluestone.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly AppSettings _appSettings;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILogger<IdentityController> _logger;
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;


        public IdentityController(
            IMapper mapper,
            IMediator mediator,
            ICurrentUser currentUser,
            ILogger<IdentityController> logger,
            IDateTimeProvider dateTimeProvider,
            IOptionsSnapshot<AppSettings> appSettings,
            IIdentityService identityService,
            IUserService userService,
            IJwtService jwtService)

        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestModel request)
        {
            LoginViewModel vm = new();
            GetUserDetailsByUsernameViewModel user = await _userService.GetUserDetailsByUsernameAsync(request.Username);

            // if username does not exists
            if (user is null)
            {
                vm.Result = ConstantsHelper.Result.Failure;
                vm.Notes = ConstantsHelper.Errors.MissingUsernameOrPasswordError;
                return Ok(vm);
            }

            // Encrypting Password to MD5 and validating user's enter password
            bool loginStatus = _identityService.ValidateUserPassword(user.Password, request.Password);

            // if password is incorrect
            if (!loginStatus)
            {
                vm.Result = ConstantsHelper.Result.Failure;
                vm.Notes = ConstantsHelper.Errors.InCorrectPasswordError;
                return Ok(vm);
            }

            // get user's Roles by user id
            List<Claim> claims = await _identityService.GetUserRolesAsync(new GetUserRolesRequestModel() { UserId = user.UserId });


            // generate jwt token 
            JwtTokenRequestModel jwttokenmodel = new(user.UserId, user.UserName, user.UserType, _appSettings.Jwt.SigningKey,
            _appSettings.Jwt.Issuer, _appSettings.Jwt.Audience, _appSettings.Jwt.Expiration, claims);
            vm.Token = _jwtService.GenerateJwtToken(jwttokenmodel);

            vm.Result = ConstantsHelper.Result.Success;
            return Ok(vm);
        }

    }
}
