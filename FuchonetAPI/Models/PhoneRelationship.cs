using System;
using System.Collections.Generic;

namespace FuchonetAPI.Models
{
    public partial class PhoneRelationship
    {
        public int Id { get; set; }
        public int PhoneId { get; set; }
        public string? Relationship { get; set; }
        public string? PersonName { get; set; }

        public virtual Phone Phone { get; set; } = null!;
    }
}
