using System;
using System.Net;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using CRMLogsExporterService.Configuration;
using CRMLogsExporterService.Interfaces;

namespace CRMLogsExporterService.Services
{
    public class CrmService : ICrmService
    {
        private readonly CrmSettings _crmSettings;

        public CrmService(CrmSettings crmSettings)
        {
            _crmSettings = crmSettings;
        }

        public IOrganizationService Connect()
        {
            var credentials = new ClientCredentials();

            credentials.Windows.ClientCredential =
                new NetworkCredential(
                    _crmSettings.Username,
                    _crmSettings.Password,
                    _crmSettings.Domain);

            var serviceProxy = new OrganizationServiceProxy(
                new Uri(_crmSettings.Url),
                null,
                credentials,
                null);

            serviceProxy.EnableProxyTypes();

            return (IOrganizationService)serviceProxy;

            // Implement the logic to connect to the CRM using _crmSettings
            // For example, you can use the CrmServiceClient or OrganizationServiceProxy classes
            // Return an instance of IOrganizationService
            //throw new NotImplementedException();
        }
    }
}
