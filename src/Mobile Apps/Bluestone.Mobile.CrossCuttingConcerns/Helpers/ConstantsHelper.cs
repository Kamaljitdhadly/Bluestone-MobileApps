using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Bluestone.Mobile.CrossCuttingConcerns.Helpers
{
    public static class ConstantsHelper
    {
        public static ObservableCollection<string> AddOptions = new ObservableCollection<string>() {
            "task",
            "list"
        };

        public static List<string> ListColorList = new List<string>() {
            "#F9371C",
            "#F97C1C",
            "#F9C81C",
            "#41D0B6",
            "#2CADF6",
            "#6562FC"
        };

        public static class Errors
        {
            public static string GeneralError = "Something went wrong! Please wait a moment and try again.";
            public static string WrongUserOrPasswordError = "The email or password is incorrect";
            public static string RequiredUsernameError = "A username is required.";
            public static string RequiredPasswordError = "A password is required.";
        }
    }
}
