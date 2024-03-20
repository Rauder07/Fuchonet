using System;
using System.Collections.Generic;

namespace FuchonetAPI.Models
{
    public partial class Zone
    {
        public Zone()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
