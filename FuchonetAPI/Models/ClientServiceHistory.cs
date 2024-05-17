using System;
using System.Collections.Generic;

<<<<<<< Updated upstream:FuchonetAPI/Models/ClientServiceHistory.cs
namespace FuchonetAPI.Models
=======
namespace Fuchonet.Entities.Models
>>>>>>> Stashed changes:Entities/Models/ClientServiceHistory.cs
{
    public partial class ClientServiceHistory
    {
        public int Id { get; set; }
        public int ServiceAgrementId { get; set; }
        public int EventType { get; set; }
        public DateTime EventDate { get; set; }
        public string? EventDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual EventType EventTypeNavigation { get; set; } = null!;
        public virtual ServiceAgrement ServiceAgrement { get; set; } = null!;
    }
}
