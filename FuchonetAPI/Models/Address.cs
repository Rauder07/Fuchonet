﻿using System;
using System.Collections.Generic;

namespace Fuchonet.Entities.Models
{
    public partial class Address
    {
        public Address()
        {
            ServiceAgrements = new HashSet<ServiceAgrement>();
        }

        public int Id { get; set; }
        public int ZoneId { get; set; }
        public int CustomerId { get; set; }
        public string Address1 { get; set; } = null!;
        public bool IsActive { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Zone Zone { get; set; } = null!;
        public virtual ICollection<ServiceAgrement> ServiceAgrements { get; set; }
    }
}
