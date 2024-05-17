using Fuchonet.Entities.Models;
using Fuchonet.Persistence;
using Fuchonet.Repositories.Interface;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Repositories.Implementation
{
    public class ServiceCategoryRepository : GenericRepository<ServiceCategory>, IServiceCategoryRepository
    {

        private FuchonetDbContext _context;
        public ServiceCategoryRepository(FuchonetDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceCategory>>  GetAll()
        {
            return await _context.ServiceCategories.Include(x=> x.Services).ToListAsync();
        }

    }
}


