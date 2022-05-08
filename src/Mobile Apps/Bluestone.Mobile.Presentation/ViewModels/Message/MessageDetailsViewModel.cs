using Bluestone.Mobile.CrossCuttingConcerns.Extensions;
using Bluestone.Mobile.Domain.Models.Message;
using Bluestone.Mobile.Domain.Services.Message;
using Bluestone.Mobile.Presentation.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.ViewModels.Message
{
    public class MessageDetailsViewModel : ViewModelBase
    {
        private readonly IMessageService _messageService;

        private MessageModel _message;
        private bool _isDetailsSite;

        public ICommand EnableDetailsSiteCommand => new Command(EnableDetailsSite);

        public MessageDetailsViewModel()
        {
            _messageService = DependencyService.Get<IMessageService>();
        }

        public MessageModel Message
        {
            get => _message;
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }

        public bool IsDetailsSite
        {
            get => _isDetailsSite;
            set
            {
                _isDetailsSite = value;
                RaisePropertyChanged(() => IsDetailsSite);
            }
        }

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            var messageId = query.GetValueAsInt(nameof(Message.MessageId));

            if (messageId.ContainsKeyAndValue)
            {
                IsBusy = true;
                Message = await _messageService.GetMessageDetailsByIdAsync(messageId.Value, PreferenceService.AuthAccessToken);
                IsBusy = false;
            }
        }

        private void EnableDetailsSite()
        {
            IsDetailsSite = true;
        }
    }
}
