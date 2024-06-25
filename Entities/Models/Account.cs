using System;
using System.Collections.Generic;

namespace Fuchonet.Entities.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public int? ServiceAgrementId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ServiceAgrement? ServiceAgrement { get; set; }
    }
}
