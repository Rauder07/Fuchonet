using System;
using System.Collections.Generic;

namespace Fuchonet.Entities.Models
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
