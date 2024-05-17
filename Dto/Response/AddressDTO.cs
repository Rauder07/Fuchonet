using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Dto.Response
{
    public class AddressDTO
    {
 
        public string Address { get; set; } = null!;
        public bool IsActive { get; set; }
        public string? Note { get; set; }

        public ZoneDTO Zone { get; set; } = new ZoneDTO();

    }
}
