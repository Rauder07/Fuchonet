using Fuchonet.Dto.Request;
using Fuchonet.Dto.Response;
using Fuchonet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Services.Interface
{
    public interface ICustomerService 
    {
        public Task<IEnumerable<CustomerDTO>> Get(PaginationParams request, string? query, string? loadRelations);
        public Task<CustomerDTO> GetById(int id, string? loadRelations);
    }
}


