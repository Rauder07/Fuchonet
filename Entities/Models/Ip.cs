using System;
using System.Collections.Generic;

namespace Fuchonet.Entities.Models
{
    public partial class Ip
    {
        public Ip()
        {
            Ipshistories = new HashSet<Ipshistory>();
        }

        public int Id { get; set; }
        public string IpAddress { get; set; } = null!;
        public string IpStatus { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Ipshistory> Ipshistories { get; set; }
    }
}
