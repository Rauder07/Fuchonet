using Fuchonet.Dto.Request;
using Fuchonet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Repositories.Interface
{
    public interface IServiceAgrementRepository : IGenericRepository<ServiceAgrement>
    {
        public Task<int> CountServiceAgrementByService(string request);
    }
}
