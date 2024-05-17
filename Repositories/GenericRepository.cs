using Fuchonet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using Fuchonet.Entities.Models;
using Fuchonet.Persistence;

namespace Fuchonet.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //al injectar _unitOfWork se implementa las propiedades de:
        //Context [Que es una clase de FUCHONETDBCONTEXT]
        //SaveChanguesAsync [metodo para guardar data asincrona]

        public readonly FuchonetDbContext _context;
        public DbSet<T> DbSet;
        public GenericRepository(FuchonetDbContext context) 
        {
            _context = context;
            this.DbSet = _context.Set<T>();
        }
        
        public async Task<IEnumerable<T>> Get()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        } 
        public async Task<int> Count()
        {
            return await DbSet.CountAsync();
        }

        
    }
}   