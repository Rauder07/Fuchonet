using System;
using System.Collections.Generic;

<<<<<<< Updated upstream:FuchonetAPI/Models/Ipshistory.cs
namespace FuchonetAPI.Models
=======
namespace Fuchonet.Entities.Models
>>>>>>> Stashed changes:Entities/Models/Ipshistory.cs
{
    public partial class Ipshistory
    {
        public int Id { get; set; }
        public int ServiceAgrementId { get; set; }
        public int IpId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Ip Ip { get; set; } = null!;
        public virtual ServiceAgrement ServiceAgrement { get; set; } = null!;
    }
}
