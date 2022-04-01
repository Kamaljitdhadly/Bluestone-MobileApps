using Bluestone.CrossCuttingConcerns.Helpers;
using Bluestone.Domain.Models.Message;
using Bluestone.Domain.Services.Message;
using Bluestone.Presentation.GlobalSettings;
using Bluestone.Presentation.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.XamarinForms.DataControls.ListView.Commands;
using Xamarin.Forms;

namespace Bluestone.Presentation.ViewModels.Message
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

        public ICommand GetMessageDetailsCommand => new Command<ItemTapCommandContext>(async (item) => await GetMessageDetailsAsync(item));
        public ICommand EditModeBackCommand => new Command(() => BackCommandAsync());


        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            // Get Messages by user
            Messages = await _messageService.GetInboxMessagesAsync(PreferenceService.AuthAccessToken);
            IsBusy = false;
        }

        private async Task GetMessageDetailsAsync(ItemTapCommandContext obj)
        {
            MessageModel message = obj?.Item as MessageModel;
            await ShellNavigationService.PushAsync(AppRoutingConstants.MessageDetailsPageRoute,
                new Dictionary<string, string> { { nameof(message.MessageId), message.MessageId.ToString() } });
        }

        private void BackCommandAsync()
        {
            this.ViewMode = ViewModeEnum.Read;
        }

    }
}
