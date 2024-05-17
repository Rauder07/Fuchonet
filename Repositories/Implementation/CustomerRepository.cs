using Fuchonet.Dto.Response;
using Fuchonet.Entities.Models;
using Fuchonet.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Fuchonet.Repositories.Utils;
using Mapster;
namespace Fuchonet.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {

        public readonly FuchonetDbContext _context; 
        public CustomerRepository(FuchonetDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> Get(string? loadRelations)
        {
            IQueryable<Customer> query = _context.Customers;

            if (!string.IsNullOrWhiteSpace(loadRelations))
            {
                query = query.IncludeRelations(loadRelations);
            }
            
            
            return query.AsEnumerable();
        }

        public async Task<Customer> GetById(int id, string? loadRelations)
        {
            IQueryable<Customer> query = _context.Customers;

            if (!string.IsNullOrWhiteSpace(loadRelations))
            {
                query = query.IncludeRelations(loadRelations);
            }

            var customer = await query.FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

       



        }
}

