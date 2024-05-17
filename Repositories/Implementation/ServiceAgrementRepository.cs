using Fuchonet.Entities.Models;
using Fuchonet.Persistence;
using Fuchonet.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Fuchonet.Dto.Request;

namespace Fuchonet.Repositories.Implementation
{
    public class ServiceAgrementRepository : GenericRepository<ServiceAgrement>, IServiceAgrementRepository
    {
        private FuchonetDbContext _context;
        
        public ServiceAgrementRepository(FuchonetDbContext context):base(context)
        {
            _context = context;
        }
        //TODO: add generic function for COUNT 
        public async Task<int> CountServiceAgrementByService(string request)
        {
            var response = await _context.ServiceAgrements.CountAsync();

            return response;
        }


    }
}
