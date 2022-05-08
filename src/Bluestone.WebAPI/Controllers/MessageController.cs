using AutoMapper;
using Bluestone.Application.Common.Exceptions;
using Bluestone.CrossCuttingConcerns.OS;
using Bluestone.Domain.Entities.Messages.RequestModels;
using Bluestone.Domain.Entities.Messages.ViewModels;
using Bluestone.Domain.Identity;
using Bluestone.Domain.Services.Messages;
using Bluestone.WebAPI.ConfigurationOptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Bluestone.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly AppSettings _appSettings;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILogger<MessageController> _logger;
        private readonly IMessageService _messageService;


        public MessageController(
            IMapper mapper,
            IMediator mediator,
            ICurrentUser currentUser,
            ILogger<MessageController> logger,
            IDateTimeProvider dateTimeProvider,
            IOptionsSnapshot<AppSettings> appSettings,
            IMessageService messageService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        }



        [HttpGet]
        [Route("inbox/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetInboxMessageListViewModel>>> GetInboxMessageListAsync([FromQuery] GetInboxMessageListRequestModel request)
        {
            List<GetInboxMessageListViewModel> messages = await _messageService.GetInboxMessageListAsync(request);
            return Ok(messages);
        }


        [HttpGet]
        [Route("details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetMessageDetailsByIdViewModel>> GetMessageDetailsByIdAsync([FromQuery] GetMessageDetailsByIdRequestModel request)
        {
            GetMessageDetailsByIdViewModel Message = await _messageService.GetMessageDetailsByIdAsync(request);

            if (Message is null)
            {
                throw new NotFoundException(nameof(Message), request.MessageId);
            }

            return Ok(Message);
        }


        [HttpGet]
        [Route("history/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetPatientMessageHistoryViewModel>>> GetPatientMessageHistoryAsync([FromQuery] GetPatientMessageHistoryRequestModel request)
        {
            List<GetPatientMessageHistoryViewModel> messages = await _messageService.GetPatientMessageHistoryAsync(request);
            return Ok(messages);
        }


        [HttpGet]
        [Route("type/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetMessageTypeListByUserViewModel>>> GetMessageTypeListByUserAsync([FromQuery] GetMessageTypeListByUserRequestModel request)
        {
            List<GetMessageTypeListByUserViewModel> messages = await _messageService.GetMessageTypeListByUserAsync(request);
            return Ok(messages);
        }

    }
}
