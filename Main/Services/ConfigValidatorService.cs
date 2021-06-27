// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
// ----------------------------------------------------------------------------

namespace AppOwnsData.Services
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Protocols;
    using System;
    using System.Configuration;
    using System.IO;

    public class ConfigValidatorService
    {
        private static IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        public static readonly string ApplicationId = configuration["applicationId"];
        public static readonly Guid WorkspaceId = GetParamGuid(configuration["workspaceId"]);
        public static readonly Guid ReportId = GetParamGuid(configuration["reportId"]);
        public static readonly string AuthenticationType = configuration["authenticationType"];
        public static readonly string ApplicationSecret = configuration["applicationSecret"];
        public static readonly string Tenant = configuration["tenant"];
        public static readonly string Username = configuration["pbiUsername"];
        public static readonly string Password = configuration["pbiPassword"];

        /// <summary>
        /// Check if web.config embed parameters have valid values.
        /// </summary>
        /// <returns>Null if web.config parameters are valid, otherwise returns specific error string.</returns>
        public static string GetWebConfigErrors()
        {
            string message = null;
            Guid result;

            // Application Id must have a value.
            if (string.IsNullOrWhiteSpace(ApplicationId))
            {
                message = "ApplicationId is empty. please register your application as Native app in https://dev.powerbi.com/apps and fill client Id in web.config.";
            }
            // Application Id must be a Guid object.
            else if (!Guid.TryParse(ApplicationId, out result))
            {
                message = "ApplicationId must be a Guid object. please register your application as Native app in https://dev.powerbi.com/apps and fill application Id in web.config.";
            }
            // Workspace Id must have a value.
            else if (WorkspaceId == Guid.Empty)
            {
                message = "WorkspaceId is empty or not a valid Guid. Please fill its Id correctly in web.config";
            }
            // Report Id must have a value.
            else if (ReportId == Guid.Empty)
            {
                message = "ReportId is empty or not a valid Guid. Please fill its Id correctly in web.config";
            }
            else if (AuthenticationType.Equals("masteruser", StringComparison.InvariantCultureIgnoreCase))
            {
                // Username must have a value.
                if (string.IsNullOrWhiteSpace(Username))
                {
                    message = "Username is empty. Please fill Power BI username in web.config";
                }

                // Password must have a value.
                if (string.IsNullOrWhiteSpace(Password))
                {
                    message = "Password is empty. Please fill password of Power BI username in web.config";
                }
            }
            else if (AuthenticationType.Equals("serviceprincipal", StringComparison.InvariantCultureIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(ApplicationSecret))
                {
                    message = "ApplicationSecret is empty. please register your application as Web app and fill appSecret in web.config.";
                }
                // Must fill tenant Id
                else if (string.IsNullOrWhiteSpace(Tenant))
                {
                    message = "Invalid Tenant. Please fill Tenant ID in Tenant under web.config";
                }
            }
            else
            {
                message = "Invalid authentication type";
            }

            return message;
        }

        private static Guid GetParamGuid(string param)
        {
            Guid paramGuid = Guid.Empty;
            Guid.TryParse(param, out paramGuid);
            return paramGuid;
        }
    }
}
