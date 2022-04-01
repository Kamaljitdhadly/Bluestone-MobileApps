using Bluestone.Presentation.Views.Identity;
using Bluestone.Presentation.Views.Message;
using Bluestone.Presentation.Views.Patient;
using Bluestone.Presentation.Views.Account;
using Xamarin.Forms;

namespace Bluestone.Presentation.GlobalSettings
{
    internal static class AppRoutingConstants
    {
        public const string GlobalRoutePrefix = "//";
        public const string DoListRoutePrefix = "DoList/";
        public const string SentRoutePrefix = "Sent/";
        public const string FileRoutePrefix = "File/";


        public const string LoginPageRoute = nameof(LoginPage);
        public const string LoginWithFingerPrintPageRoute = nameof(LoginWithFingerPrintPage);
        public const string SignUpPageRoute = nameof(SignUpPage);
        public const string ForgotPasswordPageRoute = nameof(ForgotPasswordPage);
        public const string ResetPasswordPageRoute = nameof(ResetPasswordPage);

        public const string DoListInboxPageRoute = DoListRoutePrefix + nameof(InboxPage);
        public const string PatientPageRoute = DoListRoutePrefix + nameof(PatientPage);

        public const string MessageDetailsPageRoute = DoListRoutePrefix + nameof(InboxPage) + "/" + nameof(MessageDetailsPage);
        public const string SettingsPageRoute = DoListRoutePrefix + nameof(AccountPage) + "/" + nameof(SettingsPage);
    }

    internal static class AppRouting
    {
        internal static void RegisterRoute()
        {

            Routing.RegisterRoute(route: AppRoutingConstants.GlobalRoutePrefix + AppRoutingConstants.LoginPageRoute, typeof(LoginPage));
            Routing.RegisterRoute(route: AppRoutingConstants.GlobalRoutePrefix + AppRoutingConstants.LoginWithFingerPrintPageRoute, typeof(LoginWithFingerPrintPage));
            Routing.RegisterRoute(route: AppRoutingConstants.GlobalRoutePrefix + AppRoutingConstants.SignUpPageRoute, typeof(SignUpPage));
            Routing.RegisterRoute(route: AppRoutingConstants.GlobalRoutePrefix + AppRoutingConstants.ForgotPasswordPageRoute, typeof(ForgotPasswordPage));
            Routing.RegisterRoute(route: AppRoutingConstants.GlobalRoutePrefix + AppRoutingConstants.ResetPasswordPageRoute, typeof(ResetPasswordPage));

            Routing.RegisterRoute(route: AppRoutingConstants.MessageDetailsPageRoute, typeof(MessageDetailsPage));
            Routing.RegisterRoute(route: AppRoutingConstants.SettingsPageRoute, typeof(SettingsPage));
        }
    }
}
