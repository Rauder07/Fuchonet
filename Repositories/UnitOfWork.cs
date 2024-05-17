using Fuchonet;
using Fuchonet.Entities.Models;
using Fuchonet.Persistence;
using Fuchonet.Repositories.Implementation;
using Fuchonet.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Repositories
{
    public class UnitOfWork : IUnitOfWork 
    {
        //contexto
        public readonly FuchonetDbContext _context;
        //propiedad para limpiar
        private bool _disposed;
        //repositorios
        public ICustomerRepository _customerRepository;
        public IServiceCategoryRepository _serviceCategoryRepository;
        public IServiceAgrementRepository _serviceAgrementRepository;

        //injeccion de dependencias del contexto y repositorios
        public UnitOfWork(FuchonetDbContext context)
        {
            _context = context;
        }
        public ICustomerRepository CustomerRepository
        {
            get { return _customerRepository = _customerRepository ?? new CustomerRepository(_context); }
        }
        
        public IServiceCategoryRepository ServiceCategoryRepository
        {
            get { return _serviceCategoryRepository = _serviceCategoryRepository ?? new ServiceCategoryRepository(_context); }
        }
        public IServiceAgrementRepository ServiceAgrementRepository
        {
            get { return _serviceAgrementRepository = _serviceAgrementRepository ?? new ServiceAgrementRepository(_context); }
        }





        //guardar datos de manera asincrona
        public async Task SaveChanguesAsync()   
        {
            await _context.SaveChangesAsync();
        }

        //limpiar datos
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //sobrecargar limpiar datos
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
