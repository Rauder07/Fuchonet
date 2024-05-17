using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Dto.Response
{
    public class ServiceCategoryDTO
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public List<ServiceDTO> Services { get; set; } = new List<ServiceDTO> { };

    }
}
