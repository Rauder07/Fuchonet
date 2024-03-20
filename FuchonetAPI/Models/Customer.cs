using System;
using System.Collections.Generic;

namespace FuchonetAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
            Phones = new HashSet<Phone>();
            ServiceAgrements = new HashSet<ServiceAgrement>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Dni { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<ServiceAgrement> ServiceAgrements { get; set; }
    }
}
