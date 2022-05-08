using Bluestone.Mobile.CrossCuttingConcerns.Helpers;
using Bluestone.Mobile.Domain.Models.Message;
using Bluestone.Mobile.Domain.Services.Message;
using Bluestone.Mobile.Presentation.GlobalSettings;
using Bluestone.Mobile.Presentation.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.XamarinForms.DataControls.ListView.Commands;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.ViewModels.Message
{
    public class InboxViewModel : ViewModelBase
    {
        private readonly IMessageService _messageService;

        private ViewModeEnum _viewMode;


        public ViewModeEnum ViewMode
        {
            get
            {
                return this._viewMode;
            }
            set
            {
                if (this._viewMode != value)
                {
                    this._viewMode = value;
                    this.OnPropertyChanged(nameof(IsReadMode));
                    this.OnPropertyChanged(nameof(IsEditMode));
                }
            }
        }


        private ObservableCollection<MessageModel> _messages;

        public InboxViewModel()
        {
            _messageService = DependencyService.Get<IMessageService>();
        }

        public bool IsReadMode
        {
            get
            {
                return this._viewMode == ViewModeEnum.Read;
            }
        }

        public bool IsEditMode
        {
            get
            {
                return this._viewMode == ViewModeEnum.Edit;
            }
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

        public ICommand GetMessageDetailsCommand => new Command<ItemTapCommandContext>(async (item) => await GetMessageDetailsByIdAsync(item));

        public ICommand MessageFilterOptionsCommand => new Command(async () => await DisplayMessageFilterOptionsAsync());

        public ICommand MessageTypeOptionsCommand => new Command(async () => await DisplayMessageTypeOptionsAsync());

        public ICommand EditModeBackCommand => new Command(() => BackCommandAsync());


        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            // Get Messages by user
            Messages = await _messageService.GetInboxMessagesAsync(PreferenceService.AuthAccessToken);
            IsBusy = false;
        }

        private async Task GetMessageDetailsByIdAsync(ItemTapCommandContext obj)
        {
            MessageModel message = obj?.Item as MessageModel;
            await ShellNavigationService.PushAsync(AppRoutingConstants.MessageDetailsPageRoute,
                new Dictionary<string, string> { { nameof(message.MessageId), message.MessageId.ToString() } });
        }

        private async Task DisplayMessageTypeOptionsAsync()
        {
            var action = await ShellDialogService.DisplayActionSheetAsync("New Message", "Cancel", null, "Provider Message", "IBM - Internal Bluestone Message", "BH Message");

            switch (action)
            {
                case "Provider Message":
                    await ShellNavigationService.PushAsync(AppRoutingConstants.CreateMessagePageRoute);
                    break;
                case "IBM - Internal Bluestone Message":
                    await ShellNavigationService.PushAsync(AppRoutingConstants.CreateMessagePageRoute);
                    break;
                case "BH Message":
                    await ShellNavigationService.PushAsync(AppRoutingConstants.CreateMessagePageRoute);
                    break;
                default:
                    break;
            }
        }

        private async Task DisplayMessageFilterOptionsAsync()
        {
            var action = await ShellDialogService.DisplayActionSheetAsync("Message Filter", "Clear filter", null, "Urgent Messages", "Messages with order attached", "Messages for specific team");

            switch (action)
            {
                case "Urgent Messages":
                    await ShellNavigationService.PushAsync(AppRoutingConstants.CreateMessagePageRoute);
                    break;
                case "Messages with order attached":
                    await ShellNavigationService.PushAsync(AppRoutingConstants.CreateMessagePageRoute);
                    break;
                case "Messages for specific team":
                    await ShellNavigationService.PushAsync(AppRoutingConstants.CreateMessagePageRoute);
                    break;
                default:
                    break;
            }
        }


        private void BackCommandAsync()
        {
            this.ViewMode = ViewModeEnum.Read;
        }

    }
}
