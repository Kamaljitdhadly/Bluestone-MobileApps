using Bluestone.Mobile.CrossCuttingConcerns.Extensions;
using Bluestone.Mobile.Domain.ConfigurationOptions;
using Bluestone.Mobile.Domain.IDataStore;
using Bluestone.Mobile.Domain.Models.User;
using Bluestone.Mobile.Domain.Services.RequestProvider;
using Bluestone.Mobile.Domain.Services.User;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading.Tasks;


namespace Bluestone.Mobile.Application.User
{
    public class UserMockService : IUserService
    {
        private readonly ObservableCollection<PatientCareTeamModel> _mockCareTeamMembers = new ObservableCollection<PatientCareTeamModel>
        {
            new PatientCareTeamModel(1,"Joshua Price", "jprice@progress.com", "#FE6078"),
            new PatientCareTeamModel(2,"Reuben Holmes", "rholmes@progress.com","#FF714D"),
            new PatientCareTeamModel(3,"Eva Lawson", "lthomas@endava.com", "#FE6078"),
            new PatientCareTeamModel(4,"Rory Baxter", "rbaxter@telerik.com", "#FF714D"),
            new PatientCareTeamModel(5,"David Webb", "dwebb@telerk.com", "#72CDFE"),
            new PatientCareTeamModel(6,"Howard Pittman", "hpittman@gmail.com", "#FE6078"),
            new PatientCareTeamModel(7,"Davis Anderson", "danderson@progress.com", "#FE6078"),
            new PatientCareTeamModel(8,"Cannon Puckett", "cpuckett@softserve.com", "#FF714D"),
            new PatientCareTeamModel(9,"Xavi Vasquez", "vasquez@progress.com", "#FE6078"),
            new PatientCareTeamModel(10,"Ronald Hatfield", "rhaltfield@microsoft.com" ,"#72CDFE"),
            new PatientCareTeamModel(11,"Freda Curtis", "fcurtis@telerik.com" ,"#72CDFE"),
            new PatientCareTeamModel(12,"Jeffery Francis", "jfrancis@progress.com", "#72CDFE"),
            new PatientCareTeamModel(13,"Eva Lawson", "elawson@telerik.com", "#72CDFE"),
            new PatientCareTeamModel(14,"Emmett Santos", "esantos@progress.com", "#FE6078"),
            new PatientCareTeamModel(15,"Vada Davies", "vdavies@progress.com", "#72CDFE"),
            new PatientCareTeamModel(16,"Jenny Fuller", "jfuller@gmail.com", "#FE6078"),
            new PatientCareTeamModel(17,"Terrell Norris", "tnorris@telerik.com", "#FF714D"),
            new PatientCareTeamModel(18,"Vadim Saunders", "vsaunders@progress.com", "#72CDFE"),
            new PatientCareTeamModel(19,"Nida Carty", "ncarty@telerik.com", "#72CDFE"),
            new PatientCareTeamModel(20,"Niki Samaniego", "nsamaniego@gmail.com", "#FF714D"),
            new PatientCareTeamModel(21,"Valdex Mills", "vmills@progress.com", "#FE6078"),
            new PatientCareTeamModel(22,"Layton Buck", "lbuck@gmail.com", "#FF714D"),
            new PatientCareTeamModel(23,"Alex Ramos", "aramos@telerik.com", "#FE6078"),
            new PatientCareTeamModel(24,"Alena Cline", "acline@gmail.com", "#FF714D"),
            new PatientCareTeamModel(25,"Joel Walsh", "jwalsh@progress.com", "#FF714D"),
            new PatientCareTeamModel(26,"Vadik Pearson", "vpearson@telerik.com", "#72CDFE"),
            new PatientCareTeamModel(27,"Bob Carty", "bcarty@telerik.com", "#72CDFE"),
            new PatientCareTeamModel(28,"Carol Samaniego", "csamaniego@gmail.com", "#FF714D"),
            new PatientCareTeamModel(29,"Greg Nikolas", "gnikolas@progress.com", "#FE6078"),
            new PatientCareTeamModel(30,"Ivan Ivanov", "iivanov@telerik.com", "#72CDFE"),
            new PatientCareTeamModel(31,"Konny Mills", "kmills@gmail.com", "#FF714D"),
            new PatientCareTeamModel(32,"Matias Santos", "msantos@progress.com", "#FE6078"),
            new PatientCareTeamModel(33,"Peter Bence", "pbence@telerik.com", "#72CDFE"),
            new PatientCareTeamModel(34,"Quincy Sanchez", "qsanchez@gmail.com", "#FF714D")
        };

        private readonly IRequestProvider _requestProvider;
        private readonly IRepository<PatientDataModel> _repository;
        private readonly IPatientDataStore _patientStore;

        public UserMockService(IRequestProvider requestProvider, IRepository<PatientDataModel> repository, IPatientDataStore patientStore)
        {
            _requestProvider = requestProvider;
            _patientStore = patientStore;
            _repository = repository;
        }

        public async Task<ObservableCollection<PatientCareTeamModel>> GetPatientCareTeamAsync(string token)
        {
            return await Task.FromResult(_mockCareTeamMembers);
        }

    }
}
