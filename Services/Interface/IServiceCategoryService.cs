using Fuchonet.Entities.Models;
using Fuchonet.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Services.Interface
{
    public interface IServiceCategoryService 
    {
        Task<IEnumerable<ServiceCategory>> GetAll();
    }
}
