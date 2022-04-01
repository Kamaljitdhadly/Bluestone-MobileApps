using Bluestone.Application.Account;
using Bluestone.Application.Identity;
using Bluestone.Application.Message;
using Bluestone.Application.Patient;
using Bluestone.Application.RequestProvider;
using Bluestone.Domain.IDataStore;
using Bluestone.Domain.Services.Account;
using Bluestone.Domain.Services.Identity;
using Bluestone.Domain.Services.Message;
using Bluestone.Domain.Services.Patient;
using Bluestone.Domain.Services.RequestProvider;
using Bluestone.Persistence.DataConnection;
using Bluestone.Persistence.DataStore;
using Bluestone.Persistence.PatientStore;
using Bluestone.Presentation.Services.Dialog;
using Bluestone.Presentation.Services.Navigation;
using Bluestone.Presentation.Services.OpenUrl;
using Bluestone.Presentation.Services.Preference;
using Bluestone.Presentation.Services.Settings;
using Bluestone.Presentation.Services.Theme;
using Bluestone.Presentation.ViewModels.Account;
using Bluestone.Presentation.ViewModels.Identity;
using Bluestone.Presentation.ViewModels.Message;
using Bluestone.Presentation.ViewModels.Patient;
using Xamarin.Forms;

namespace Bluestone.Presentation.GlobalSettings
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
            
            DependencyService.RegisterSingleton<IMessageService>(new MessageMockService(requestProvider, new Repository<PatientDataModel>(dataConnection), new PatientDataStore(dataConnection)));
            DependencyService.RegisterSingleton<IPatientService>(new PatientMockService(requestProvider, new Repository<PatientDataModel>(dataConnection), new PatientDataStore(dataConnection)));



            // View models - by default, TinyIoC will register concrete classes as multi-instance.
            DependencyService.Register<LoginViewModel>();
            DependencyService.Register<LoginWithFingerPrintViewModel>();
            DependencyService.Register<SignUpViewModel>();
            DependencyService.Register<ForgotPasswordViewModel>();
            DependencyService.Register<ResetPasswordViewModel>();


            DependencyService.Register<InboxViewModel>();
            DependencyService.Register<MessageDetailsViewModel>();
            DependencyService.Register<MessagesHistoryViewModel>();


            DependencyService.Register<PatientViewModel>();
            DependencyService.Register<PatientDetailsViewModel>();


            DependencyService.Register<SettingsViewModel>();
            DependencyService.Register<SettingsViewModel>();
            DependencyService.Register<ProfileViewModel>();
        }
    }
}
