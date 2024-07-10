using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGSWebApp.Application.Common.DTOs
{
    public class OperationDTO : MainDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OperationType { get; set; } = string.Empty;
        public string OperatorName { get; set; } = string.Empty;
        public string InspectionLocation { get; set; } = string.Empty;

        public Guid ContainerId { get; set; }
    }
}
