using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuchonet.Dto.Response;
using Fuchonet.Entities;
using Fuchonet.Entities.Models;

namespace Fuchonet.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer> 
    {


        public  Task<IEnumerable<Customer>> Get(string? loadRelations);
        public  Task<Customer> GetById(int id, string loadRelations);
    }
}
