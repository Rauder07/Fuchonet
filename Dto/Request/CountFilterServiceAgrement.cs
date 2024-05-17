using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Dto.Request
{
    public class CountFilterServiceAgrement
    {
        public int service_id { get; set; }
        public int customer_id { get; set; }
        public int address_id { get; set; }
        public int monthly_fee { get; set; }
        public int cutoff_day { get; set; }
        public int status_service { get; set; }
    }
}
