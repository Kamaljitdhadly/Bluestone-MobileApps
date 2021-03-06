using AutoMapper;
using Bluestone.CrossCuttingConcerns.OS;
using Bluestone.Domain.Entities.Patients.RequestModels;
using Bluestone.Domain.Entities.Patients.ViewModels;
using Bluestone.Domain.Identity;
using Bluestone.Domain.Services.Patients;
using Bluestone.WebAPI.ConfigurationOptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
namespace Bluestone.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly AppSettings _appSettings;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patientService;


        public PatientController(
            IMapper mapper,
            IMediator mediator,
            ICurrentUser currentUser,
            ILogger<PatientController> logger,
            IDateTimeProvider dateTimeProvider,
            IOptionsSnapshot<AppSettings> appSettings,
            IPatientService patientService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }


        [HttpGet]
        [Route("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetPatientListViewModel>>> GetPatientListAsync([FromQuery] GetPatientListRequestModel request)
        {
            List<GetPatientListViewModel> patients = await _patientService.GetPatientListAsync(request);
            return Ok(patients);
        }


        [HttpGet]
        [Route("listbyname")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetUserPatientListByNameViewModel>>> GetUserPatientListByNameAsync([FromQuery] GetUserPatientListByNameRequestModel request)
        {
            List<GetUserPatientListByNameViewModel> patients = await _patientService.GetUserPatientListByNameAsync(request);
            return Ok(patients);
        }


    }
}
