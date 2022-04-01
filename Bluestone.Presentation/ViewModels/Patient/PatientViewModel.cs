using Bluestone.Domain.Models.Patient;
using Bluestone.Domain.Services.Patient;
using Bluestone.Presentation.GlobalSettings;
using Bluestone.Presentation.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Presentation.ViewModels.Patient
{
    public class PatientViewModel : ViewModelBase
    {
        private readonly IPatientService _patientService;

        private ObservableCollection<PatientModel> _patients;

        public PatientViewModel()
        {
            _patientService = DependencyService.Get<IPatientService>();
        }

        public ObservableCollection<PatientModel> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                RaisePropertyChanged(() => Patients);
            }
        }

        public ICommand GetPatientDetailsCommand => new Command<PatientModel>(async (item) => await GetPatientDetailsAsync(item));

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            Patients = await _patientService.GetAllPatientsAsync(PreferenceService.AuthAccessToken);
            IsBusy = false;
        }

        private async Task GetPatientDetailsAsync(PatientModel patient)
        {
            await ShellNavigationService.PushAsync(AppRoutingConstants.MessageDetailsPageRoute,
                new Dictionary<string, string> { { nameof(patient.PatientId), patient.PatientId.ToString() } });
        }

    }
}
