
namespace CRMLogsExporterService.Configuration
{
    public class ServiceSettings
    {
        public string ExportFolder { get; set; }

        public string LogFolder { get; set; }

        public int PollingIntervalMinutes { get; set; }
    }
}
