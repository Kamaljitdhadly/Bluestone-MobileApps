using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Core.GlobalSettings
{
    public static class ApiEndpoints
    {
        public const string ApiBaseUrl = "";
        public static string LoginEndpoint = $"{ApiBaseUrl}/Account/Login";
        public static string LogoutEndpoint = $"{ApiBaseUrl}/Account/Logout";
        public static string LogoutCallback = $"{ApiBaseUrl}/Account/LogoutCallback";
        public static string RegisterEndpoint = $"{ApiBaseUrl}/Account/Register";
    }
}
