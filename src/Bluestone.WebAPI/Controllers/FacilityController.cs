using AutoMapper;
using Bluestone.Application.Common.Exceptions;
using Bluestone.Application.Facilities.Services;
using Bluestone.CrossCuttingConcerns.OS;
using Bluestone.Domain.Entities.Facilities.RequestModels;
using Bluestone.Domain.Entities.Facilities.ViewModels;
using Bluestone.Domain.Identity;
using Bluestone.Domain.Services.Facilities;
using Bluestone.Infrastructure.Web.Authorization;
using Bluestone.Infrastructure.Web.Authorization.Policies;
using Bluestone.WebAPI.Authorization.Policies.Patients;
using Bluestone.WebAPI.ConfigurationOptions;
using MediatR;

namespace Bluestone.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly AppSettings _appSettings;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILogger<FacilityController> _logger;
        private readonly IFacilityService _facilityService;


        public FacilityController(
            IMapper mapper,
            IMediator mediator,
            ICurrentUser currentUser,
            ILogger<FacilityController> logger,
            IDateTimeProvider dateTimeProvider,
            IOptionsSnapshot<AppSettings> appSettings,
            IFacilityService facilityService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _facilityService = facilityService ?? throw new ArgumentNullException(nameof(facilityService));
        }

        [AuthorizePolicy(typeof(GetPatientsPolicy))]
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetFacilityListViewModel>>> GetFacilityListAsync([FromQuery] GetFacilityListRequestModel request)
        {
            List<GetFacilityListViewModel> facilities = await _facilityService.GetFacilityListAsync(request);
            return Ok(facilities);
        }

        [HttpGet]
        [Route("details/{facilityId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetFacilityDetailsByIdViewModel>> GetFacilityDetailsByIdAsync(int facilityId)
        {
            GetFacilityDetailsByIdViewModel facility = await _facilityService.GetFacilityDetailsByIdAsync(facilityId);

            if (facility is null)
            {
                throw new NotFoundException(nameof(GetFacilityDetailsByIdViewModel), facilityId);
            }

            return Ok(facility);
        }


        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> InsertFacilityAsync([FromBody] InsertFacilityRequestModel request)
        {
            var facilityId = await _facilityService.InsertFacilityAsync(request);
            return Ok(facilityId);
        }


        [HttpPost]
        [Route("update/{facilityId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateFacilityAsync(int facilityId, [FromBody] UpdateFacilityRequestModel request)
        {
            GetFacilityDetailsByIdViewModel facility = await _facilityService.GetFacilityDetailsByIdAsync(facilityId);

            if (facility is null)
            {
                throw new NotFoundException(nameof(GetFacilityDetailsByIdViewModel), facilityId);
            }

            UpdateFacilityRequestModel facilityinfo = _mapper.Map<UpdateFacilityRequestModel>(facility);
            return Ok(await _facilityService.UpdateFacilityAsync(facilityinfo));
        }


        [HttpDelete]
        [Route("delete/{facilityId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFacilityAsync(int facilityId)
        {
            GetFacilityDetailsByIdViewModel facility = await _facilityService.GetFacilityDetailsByIdAsync(facilityId);

            if (facility is null)
            {
                throw new NotFoundException(nameof(GetFacilityDetailsByIdViewModel), facilityId);
            }

            if (facility.FacilityId != 0)
            {
                await _facilityService.DeleteFacilityAsync(facilityId);
            }

            return NoContent();
        }
    }
}
