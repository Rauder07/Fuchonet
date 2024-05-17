using System;
using System.Collections.Generic;

<<<<<<< Updated upstream:FuchonetAPI/Models/Service.cs
namespace FuchonetAPI.Models
=======
namespace Fuchonet.Entities.Models
>>>>>>> Stashed changes:Entities/Models/Service.cs
{
    public partial class Service
    {
        public Service()
        {
            ServiceAgrements = new HashSet<ServiceAgrement>();
        }

        public int Id { get; set; }
        public int? ServiceCategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ServiceCategory? ServiceCategory { get; set; }
        public virtual ICollection<ServiceAgrement> ServiceAgrements { get; set; }
    }
}
