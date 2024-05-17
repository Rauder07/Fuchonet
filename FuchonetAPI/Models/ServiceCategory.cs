using System;
using System.Collections.Generic;

<<<<<<< Updated upstream:FuchonetAPI/Models/ServiceCategory.cs
namespace FuchonetAPI.Models
=======
namespace Fuchonet.Entities.Models
>>>>>>> Stashed changes:Entities/Models/ServiceCategory.cs
{
    public partial class ServiceCategory
    {
        public ServiceCategory()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Service> Services { get; set; }
    }
}
