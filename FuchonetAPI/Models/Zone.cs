using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Fuchonet.Entities.Models
{
    public partial class Zone
    {
        public Zone()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
