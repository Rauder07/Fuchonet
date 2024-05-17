using System;
using System.Collections.Generic;

<<<<<<< Updated upstream:FuchonetAPI/Models/EventType.cs
namespace FuchonetAPI.Models
=======
namespace Fuchonet.Entities.Models
>>>>>>> Stashed changes:Entities/Models/EventType.cs
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
