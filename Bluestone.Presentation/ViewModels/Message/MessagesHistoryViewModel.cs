using Bluestone.Domain.Models.Message;
using Bluestone.Domain.Services.Message;
using Bluestone.Presentation.GlobalSettings;
using Bluestone.Presentation.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Presentation.ViewModels.Message
{
    public class MessagesHistoryViewModel : ViewModelBase
    {
        private readonly IMessageService _messageService;

        private ObservableCollection<MessageModel> _messages;

        public MessagesHistoryViewModel()
        {
            _messageService = DependencyService.Get<IMessageService>();
        }

        public ObservableCollection<MessageModel> Messages
        {
            get => _messages;
            set
            {
                _messages = value;
                RaisePropertyChanged(() => Messages);
            }
        }

        public ICommand GetMessageDetailsCommand => new Command<MessageModel>(async (item) => await GetMessageDetailsAsync(item));

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            // Get Messages by user
            Messages = await _messageService.GetInboxMessagesAsync(PreferenceService.AuthAccessToken);
            IsBusy = false;
        }

        private async Task GetMessageDetailsAsync(MessageModel message)
        {
            await ShellNavigationService.PushAsync(AppRoutingConstants.MessageDetailsPageRoute,
                new Dictionary<string, string> { { nameof(message.MessageId), message.MessageId.ToString() } });
        }

    }
}
