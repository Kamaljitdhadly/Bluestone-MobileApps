using AutoMapper;
using Bluestone.CrossCuttingConcerns.OS;
using Bluestone.Domain.Entities.Partners.RequestModels;
using Bluestone.Domain.Entities.Partners.ViewModels;
using Bluestone.Domain.Identity;
using Bluestone.Domain.Services.Partners;
using Bluestone.WebAPI.ConfigurationOptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Bluestone.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly AppSettings _appSettings;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILogger<PartnerController> _logger;
        private readonly IPartnerService _partnerService;


        public PartnerController(
            IMapper mapper,
            IMediator mediator,
            ICurrentUser currentUser,
            ILogger<PartnerController> logger,
            IDateTimeProvider dateTimeProvider,
            IOptionsSnapshot<AppSettings> appSettings,
            IPartnerService partnerService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _partnerService = partnerService ?? throw new ArgumentNullException(nameof(partnerService));
        }


        [HttpGet]
        [Route("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetPartnerListViewModel>>> GetPartnerListAsync([FromQuery] GetPartnerListRequestModel request)
        {
            List<GetPartnerListViewModel> partners = await _partnerService.GetPartnerListAsync(request);
            return Ok(partners);
        }

    }
}
