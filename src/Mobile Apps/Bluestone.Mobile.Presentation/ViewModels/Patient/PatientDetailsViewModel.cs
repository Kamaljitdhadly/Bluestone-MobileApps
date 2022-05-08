using Bluestone.Mobile.CrossCuttingConcerns.Extensions;
using Bluestone.Mobile.Domain.Models.Patient;
using Bluestone.Mobile.Domain.Services.Patient;
using Bluestone.Mobile.Presentation.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.ViewModels.Patient
{
    public class PatientDetailsViewModel : ViewModelBase
    {
        private readonly IPatientService _patientService;

        private PatientModel _patient;
        private bool _isDetailsSite;

        public ICommand EnableDetailsSiteCommand => new Command(EnableDetailsSite);

        public PatientDetailsViewModel()
        {
            _patientService = DependencyService.Get<IPatientService>();
        }

        public PatientModel Patient
        {
            get => _patient;
            set
            {
                _patient = value;
                RaisePropertyChanged(() => Patient);
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
            var patientId = query.GetValueAsInt(nameof(Patient.PatientId));

            if (patientId.ContainsKeyAndValue)
            {
                IsBusy = true;
                Patient = await _patientService.GetPatientInfoByIdAsync(patientId.Value, PreferenceService.AuthAccessToken);
                IsBusy = false;
            }
        }

        private void EnableDetailsSite()
        {
            IsDetailsSite = true;
        }
    }
}
