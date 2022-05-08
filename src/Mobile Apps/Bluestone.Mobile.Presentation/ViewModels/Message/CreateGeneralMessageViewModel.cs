using Bluestone.Mobile.Domain.Models.User;
using Bluestone.Mobile.Domain.Services.User;
using Bluestone.Mobile.Presentation.GlobalSettings;
using Bluestone.Mobile.Presentation.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.ViewModels.Message
{
    public class CreateGeneralMessageViewModel : ViewModelBase
    {
        private readonly IUserService _userService;

        private ObservableCollection<PatientCareTeamModel> _careTeamMembers;

        public CreateGeneralMessageViewModel()
        {
            _userService = DependencyService.Get<IUserService>();
        }

        public ObservableCollection<PatientCareTeamModel> CareTeamMembers
        {
            get => _careTeamMembers;
            set
            {
                _careTeamMembers = value;
                RaisePropertyChanged(() => CareTeamMembers);
            }
        }

        public ICommand CreateGeneralMessageCommand => new Command<PatientCareTeamModel>(async (item) => await CreateGeneralMessageAsync(item));

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            CareTeamMembers = await _userService.GetPatientCareTeamAsync(PreferenceService.AuthAccessToken);
            IsBusy = false;
        }

        private async Task CreateGeneralMessageAsync(PatientCareTeamModel message)
        {
            await ShellNavigationService.PushAsync(AppRoutingConstants.MessageDetailsPageRoute,
                new Dictionary<string, string> { { nameof(message.UserId), message.UserId.ToString() } });
        }

    }
}
