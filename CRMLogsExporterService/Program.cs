using CRMLogsExporterService.Configuration;
using CRMLogsExporterService.Services;
using Microsoft.Crm.Sdk.Messages;
using System;
using System.ServiceModel;
using System.Configuration;
using System.ServiceProcess;

namespace CRMLogsExporterService
{
    public static class Program
    {
        static void Main()
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

                var crmService = new CrmService(crmSettings);

                var service = crmService.Connect();

                var response = (WhoAmIResponse)service.Execute(new WhoAmIRequest());

                //Console.WriteLine("=================================");
                //Console.WriteLine("Connected to Dynamics CRM!");
                //Console.WriteLine("User Id: " + response.UserId);
                //Console.WriteLine("=================================");
            }
            catch (Exception ex)
            {
                throw;
                //Console.WriteLine("Connection Failed");
                //Console.WriteLine(ex.Message);
            }

            //Console.ReadKey();
        }
    }
}
