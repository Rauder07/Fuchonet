using System;
using System.Collections.Generic;

namespace FuchonetAPI.Models
{
    public partial class ServiceAgrement
    {
        public ServiceAgrement()
        {
            Accounts = new HashSet<Account>();
            ClientServiceHistories = new HashSet<ClientServiceHistory>();
            Ipshistories = new HashSet<Ipshistory>();
        }

        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public decimal MonthlyFee { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public byte CutoffDay { get; set; }
        public byte ContractMonth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<ClientServiceHistory> ClientServiceHistories { get; set; }
        public virtual ICollection<Ipshistory> Ipshistories { get; set; }
    }
}
