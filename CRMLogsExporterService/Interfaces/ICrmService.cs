using Microsoft.Xrm.Sdk;

namespace CRMLogsExporterService.Interfaces
{
    public interface ICrmService
    {
        IOrganizationService Connect();
    }
}
