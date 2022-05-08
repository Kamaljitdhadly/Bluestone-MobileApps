using AutoMapper;
using Bluestone.Application.Common.Exceptions;
using Bluestone.CrossCuttingConcerns.OS;
using Bluestone.Domain.Entities.Users.ViewModels;
using Bluestone.Domain.Identity;
using Bluestone.Domain.Services.Users;
using Bluestone.WebAPI.ConfigurationOptions;
using MediatR;

namespace Bluestone.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    //[Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly AppSettings _appSettings;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;


        public UserController(
            IMapper mapper,
            IMediator mediator,
            ICurrentUser currentUser,
            ILogger<UserController> logger,
            IDateTimeProvider dateTimeProvider,
            IOptionsSnapshot<AppSettings> appSettings,
            IUserService userService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }


        [HttpGet]
        [Route("detailsbyid/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetUserDetailsByIdViewModel>> GetUserDetailsByUserIdAsync(int userId)
        {
            GetUserDetailsByUserIdViewModel userdetails = await _userService.GetUserDetailsByUserIdAsync(userId);

            if (userdetails is null)
            {
                throw new NotFoundException(nameof(GetUserDetailsByUserIdViewModel), userId);
            }

            return Ok(_mapper.Map<GetUserDetailsByIdViewModel>(userdetails));
        }


        [HttpGet]
        [Route("detailsbyname/{userName:minlength(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetUserDetailsByIdViewModel>> GetUserDetailsByUsernameAsync(string userName)
        {
            GetUserDetailsByUsernameViewModel userdetails = await _userService.GetUserDetailsByUsernameAsync(userName);

            if (userdetails is null)
            {
                throw new NotFoundException(nameof(GetUserDetailsByUsernameViewModel), userName);
            }

            return Ok(_mapper.Map<GetUserDetailsByIdViewModel>(userdetails));
        }
    }
}
