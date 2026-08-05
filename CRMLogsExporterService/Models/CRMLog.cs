using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLogsExporterService.Models
{
    public class CRMLog
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
