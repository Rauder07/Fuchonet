using System;
using System.Collections.Generic;

<<<<<<< Updated upstream:FuchonetAPI/Models/Phone.cs
namespace FuchonetAPI.Models
=======
namespace Fuchonet.Entities.Models
>>>>>>> Stashed changes:Entities/Models/Phone.cs
{
    public partial class Phone
    {
        public Phone()
        {
            PhoneRelationships = new HashSet<PhoneRelationship>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<PhoneRelationship> PhoneRelationships { get; set; }
    }
}
