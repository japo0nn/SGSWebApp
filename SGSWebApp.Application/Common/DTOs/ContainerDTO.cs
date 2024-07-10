using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGSWebApp.Application.Common.DTOs
{
    public class ContainerDTO : MainDTO
    {
        public int Number { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public bool IsEmpty { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
