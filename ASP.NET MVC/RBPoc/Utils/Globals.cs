using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RBPoc.Utils
{
    public static class Globals
    {
        // App config settings
        public static string ClientId = ConfigurationManager.AppSettings["ida:ClientId"];
        public static string ClientSecret = ConfigurationManager.AppSettings["ida:ClientSecret"];
        public static string RoleClientId = ConfigurationManager.AppSettings["ida:RoleClientId"];
        public static string RoleClientSecret = ConfigurationManager.AppSettings["ida:RoleClientSecret"];
        public static string AadInstance = ConfigurationManager.AppSettings["ida:AadInstance"];
        public static string Tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        public static string TenantId = ConfigurationManager.AppSettings["ida:TenantId"];
        public static string RedirectUri = ConfigurationManager.AppSettings["ida:RedirectUri"];
        public static string ServiceUrl = ConfigurationManager.AppSettings["api:TaskServiceUrl"];

        // B2C policy identifiers
        public static string SignUpPolicyId = ConfigurationManager.AppSettings["ida:SignUpPolicyId"];
        public static string SignInPolicyId = ConfigurationManager.AppSettings["ida:SignInPolicyId"];
        public static string EditProfilePolicyId = ConfigurationManager.AppSettings["ida:EditProfilePolicyId"];
        public static string ResetPasswordPolicyId = ConfigurationManager.AppSettings["ida:ResetPasswordPolicyId"];

        public static string DefaultPolicy = SignInPolicyId;

        // API Scopes
        public static string ApiIdentifier = ConfigurationManager.AppSettings["api:ApiIdentifier"];
        public static string ReadTasksScope = ApiIdentifier + ConfigurationManager.AppSettings["api:ReadScope"];
        public static string WriteTasksScope = ApiIdentifier + ConfigurationManager.AppSettings["api:WriteScope"];
        public static string[] Scopes = new string[] { ReadTasksScope, WriteTasksScope };

        // OWIN auth middleware constants
        public const string ObjectIdElement = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

        // Authorities
        public static string B2CAuthority = string.Format(AadInstance, Tenant, DefaultPolicy);
        public static string WellKnownMetadata = $"{AadInstance}/v2.0/.well-known/openid-configuration";

    }
}