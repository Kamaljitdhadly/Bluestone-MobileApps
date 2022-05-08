using Bluestone.Mobile.Domain.Models.Facility;
using Bluestone.Mobile.Domain.Services.Facility;
using Bluestone.Mobile.Presentation.GlobalSettings;
using Bluestone.Mobile.Presentation.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.ViewModels.Facility
{
    public class FacilityViewModel : ViewModelBase
    {
        private readonly IFacilityService _facilityService;

        private ObservableCollection<FacilityModel> _facilities;

        public FacilityViewModel()
        {
            _facilityService = DependencyService.Get<IFacilityService>();
        }

        public ObservableCollection<FacilityModel> Facilities
        {
            get => _facilities;
            set
            {
                _facilities = value;
                RaisePropertyChanged(() => Facilities);
            }
        }

        public ICommand GetFacilityDetailsCommand => new Command<FacilityModel>(async (item) => await GetFacilityDetailsAsync(item));

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            Facilities = await _facilityService.GetAllFacilitiesAsync(PreferenceService.AuthAccessToken);
            IsBusy = false;
        }

        private async Task GetFacilityDetailsAsync(FacilityModel Facility)
        {
            await ShellNavigationService.PushAsync(AppRoutingConstants.MessageDetailsPageRoute,
                new Dictionary<string, string> { { nameof(Facility.FacilityId), Facility.FacilityId.ToString() } });
        }

    }
}
