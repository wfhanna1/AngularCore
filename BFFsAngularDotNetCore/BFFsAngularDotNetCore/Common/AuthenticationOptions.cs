using System;
namespace BFFsAngularDotNetCore.Common
{
    public class AuthenticationOptions
    {
        public string AADInstance { get; set; }

        public string CallbackPath { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Domain { get; set; }

        public string TenantId { get; set; }
    }
}
