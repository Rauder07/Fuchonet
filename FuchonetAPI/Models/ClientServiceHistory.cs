using System;
using System.Collections.Generic;

namespace FuchonetAPI.Models
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
