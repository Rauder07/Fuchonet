using Fuchonet.Entities.Models;
using Fuchonet.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Repositories
{
    public class PhoneRepository : GenericRepository<Phone> , IPhoneRepository
    {
        private FuchonetDbContext _context;
        public PhoneRepository(FuchonetDbContext context) : base(context)
        {
            _context = context;
        }

        //public Task<List<ServiceCategory>> Get();

    }
}
