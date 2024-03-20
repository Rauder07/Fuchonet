using System;
using System.Collections.Generic;

namespace FuchonetAPI.Models
{
    public partial class EventType
    {
        public EventType()
        {
            ClientServiceHistories = new HashSet<ClientServiceHistory>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<ClientServiceHistory> ClientServiceHistories { get; set; }
    }
}
