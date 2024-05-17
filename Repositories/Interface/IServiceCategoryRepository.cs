using Fuchonet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Repositories.Interface
{
    public interface IServiceCategoryRepository : IGenericRepository<ServiceCategory>
    {
        public Task<IEnumerable<ServiceCategory>> GetAll();
    }
}
