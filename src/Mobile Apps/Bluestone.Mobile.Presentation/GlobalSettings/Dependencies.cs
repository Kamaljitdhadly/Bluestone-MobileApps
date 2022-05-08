using Bluestone.Mobile.Application.Account;
using Bluestone.Mobile.Application.Facility;
using Bluestone.Mobile.Application.Identity;
using Bluestone.Mobile.Application.Message;
using Bluestone.Mobile.Application.Patient;
using Bluestone.Mobile.Application.User;
using Bluestone.Mobile.Domain.IDataStore;
using Bluestone.Mobile.Domain.RequestProvider;
using Bluestone.Mobile.Domain.Services.Account;
using Bluestone.Mobile.Domain.Services.Facility;
using Bluestone.Mobile.Domain.Services.Identity;
using Bluestone.Mobile.Domain.Services.Message;
using Bluestone.Mobile.Domain.Services.Patient;
using Bluestone.Mobile.Domain.Services.RequestProvider;
using Bluestone.Mobile.Domain.Services.User;
using Bluestone.Mobile.Persistence.DataConnection;
using Bluestone.Mobile.Persistence.DataStore;
using Bluestone.Mobile.Persistence.PatientStore;
using Bluestone.Mobile.Presentation.Services.Dialog;
using Bluestone.Mobile.Presentation.Services.Navigation;
using Bluestone.Mobile.Presentation.Services.OpenUrl;
using Bluestone.Mobile.Presentation.Services.Permissions;
using Bluestone.Mobile.Presentation.Services.Preference;
using Bluestone.Mobile.Presentation.Services.Settings;
using Bluestone.Mobile.Presentation.Services.Theme;
using Bluestone.Mobile.Presentation.ViewModels.Account;
using Bluestone.Mobile.Presentation.ViewModels.Facility;
using Bluestone.Mobile.Presentation.ViewModels.Identity;
using Bluestone.Mobile.Presentation.ViewModels.Message;
using Bluestone.Mobile.Presentation.ViewModels.Patient;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.GlobalSettings
{
    public static class Dependencies
    {
        public static void Register()
        {
            // Services - by default, TinyIoC will register interface registrations as singletons.
            var preferenceService = new PreferenceService();
            var requestProvider = new RequestProvider();
            var dataConnection = DataConnection.GetConnection();


            DependencyService.RegisterSingleton<IPreferenceService>(preferenceService);
            DependencyService.RegisterSingleton<IShellNavigationService>(new ShellNavigationService(preferenceService));
            DependencyService.RegisterSingleton<IDialogService>(new DialogService());
            DependencyService.RegisterSingleton<IShellDialogService>(new ShellDialogService());
            DependencyService.RegisterSingleton<IOpenUrlService>(new OpenUrlService());
            DependencyService.RegisterSingleton<IThemeService>(new ThemeService());
            DependencyService.RegisterSingleton<IRequestProvider>(requestProvider);
            DependencyService.RegisterSingleton<IIdentityService>(new IdentityService(requestProvider));
            DependencyService.RegisterSingleton<ISettingsService>(new SettingsService(requestProvider));
            DependencyService.RegisterSingleton<IAccountService>(new AccountService(requestProvider));
            

            //DependencyService.RegisterSingleton<IMessageService>(new MessageService(requestProvider, new Repository<PatientDataModel>(dataConnection), new PatientDataStore(dataConnection)));
            //DependencyService.RegisterSingleton<IPatientService>(new PatientService(requestProvider, new Repository<PatientDataModel>(dataConnection), new PatientDataStore(dataConnection)));
            //DependencyService.RegisterSingleton<IUserService>(new UserService(requestProvider, new Repository<PatientDataModel>(dataConnection), new PatientDataStore(dataConnection)));
            //DependencyService.RegisterSingleton<IFacilityService>(new FacilityService(requestProvider, new Repository<PatientDataModel>(dataConnection), new PatientDataStore(dataConnection)));

            DependencyService.RegisterSingleton<IMessageService>(new MessageMockService(requestProvider, new Repository<PatientDataModel>(dataConnection), new PatientDataStore(dataConnection)));
            DependencyService.RegisterSingleton<IPatientService>(new PatientMockService(requestProvider, new Repository<PatientDataModel>(dataConnection), new PatientDataStore(dataConnection)));
            DependencyService.RegisterSingleton<IUserService>(new UserMockService(requestProvider, new Repository<PatientDataModel>(dataConnection), new PatientDataStore(dataConnection)));
            DependencyService.RegisterSingleton<IFacilityService>(new FacilityMockService(requestProvider, new Repository<PatientDataModel>(dataConnection), new PatientDataStore(dataConnection)));




            // View models - by default, TinyIoC will register concrete classes as multi-instance.
            DependencyService.Register<LoginViewModel>();
            DependencyService.Register<LoginWithFingerPrintViewModel>();
            DependencyService.Register<SignUpViewModel>();
            DependencyService.Register<ForgotPasswordViewModel>();
            DependencyService.Register<ResetPasswordViewModel>();


            DependencyService.Register<InboxViewModel>();
            DependencyService.Register<MessageDetailsViewModel>();
            DependencyService.Register<MessagesHistoryViewModel>();
            DependencyService.Register<CreateGeneralMessageViewModel>();


            DependencyService.Register<FacilityViewModel>();
            DependencyService.Register<FacilityDetailsViewModel>();


            DependencyService.Register<AccountViewModel>();
            DependencyService.Register<SettingsViewModel>();
            DependencyService.Register<ProfileViewModel>();
        }
    }
}
