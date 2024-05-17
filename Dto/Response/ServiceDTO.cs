using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Dto.Response
{
    public class ServiceDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        List<ServiceCategoryDTO> Category { get; set; } = new List<ServiceCategoryDTO> { };
    }
}
