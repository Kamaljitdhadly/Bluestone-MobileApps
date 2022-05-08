using Bluestone.Mobile.CrossCuttingConcerns.Extensions;
using Bluestone.Mobile.Domain.Models.Facility;
using Bluestone.Mobile.Domain.Services.Facility;
using Bluestone.Mobile.Presentation.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.ViewModels.Facility
{
    public class FacilityDetailsViewModel : ViewModelBase
    {
        private readonly IFacilityService _facilityService;

        private FacilityModel _facility;
        private bool _isDetailsSite;

        public ICommand EnableDetailsSiteCommand => new Command(EnableDetailsSite);

        public FacilityDetailsViewModel()
        {
            _facilityService = DependencyService.Get<IFacilityService>();
        }

        public FacilityModel Facility
        {
            get => _facility;
            set
            {
                _facility = value;
                RaisePropertyChanged(() => Facility);
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
            var facilityId = query.GetValueAsInt(nameof(Facility.FacilityId));

            if (facilityId.ContainsKeyAndValue)
            {
                IsBusy = true;
                Facility = await _facilityService.GetFacilityDetailsByIdAsync(facilityId.Value, PreferenceService.AuthAccessToken);
                IsBusy = false;
            }
        }

        private void EnableDetailsSite()
        {
            IsDetailsSite = true;
        }
    }
}
