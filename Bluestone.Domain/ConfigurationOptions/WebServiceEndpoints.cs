using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Domain.ConfigurationOptions
{
    public static class WebServiceEndpoints
    {
        public const string WebServiceUrl = AppSettings.WebServiceUrl;
        public static string LoginEndpoint = $"{WebServiceUrl}/Account/Login";
        public static string LogoutEndpoint = $"{WebServiceUrl}/Account/Logout";
        public static string LogoutCallback = $"{WebServiceUrl}/Account/LogoutCallback";
        public static string RegisterEndpoint = $"{WebServiceUrl}/Account/Register";
        public static string GetAllPatientsEndpoint = $"{WebServiceUrl}/Patient/GetAllPatients";
        public static string GetPatientInfoEndpoint = $"{WebServiceUrl}/Patient/GetPatientInfoById";
        public static string CreatePatientEndpoint = $"{WebServiceUrl}/Patient/CreatePatient";
        public static string DeletePatientEndpoint = $"{WebServiceUrl}/Patient/DeletePatient";
    }
}
