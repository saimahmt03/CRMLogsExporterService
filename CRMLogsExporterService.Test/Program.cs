using System;
using System.Configuration;
using CRMLogsExporterService.Configuration;
using CRMLogsExporterService.Services;
using Microsoft.Crm.Sdk.Messages;
using CRMLogsExporterService.Configuration;
using CRMLogsExporterService.Services;

namespace CRMLogsExporterService.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var crmSettings = new CrmSettings
                {
                    Url = ConfigurationManager.AppSettings["CrmUrl"],
                    Domain = ConfigurationManager.AppSettings["CrmDomain"],
                    Username = ConfigurationManager.AppSettings["CrmUsername"],
                    Password = ConfigurationManager.AppSettings["CrmPassword"]
                };

                Console.WriteLine("CRM URL:");
                Console.WriteLine(crmSettings.Url);
                Console.WriteLine();

                var crmService = new CrmService(crmSettings);

                var service = crmService.Connect();

                var response = (WhoAmIResponse)service.Execute(new WhoAmIRequest());

                Console.WriteLine("=================================");
                Console.WriteLine("Connected to Dynamics CRM!");
                Console.WriteLine($"User ID: {response.UserId}");
                Console.WriteLine("=================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Failed");
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
