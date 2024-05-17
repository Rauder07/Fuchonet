using Fuchonet.Persistence;
using Fuchonet.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Repositories
{
    public interface IUnitOfWork: IDisposable
    {

        //referencia  a los repositorios
        public ICustomerRepository CustomerRepository { get; }
        public IServiceCategoryRepository ServiceCategoryRepository { get; }
        public IServiceAgrementRepository ServiceAgrementRepository { get; }
        //Implementacion del contexto, ya no se usará contect.Customers,
        //Ahora será el objeto de unitofwork 
        //FuchonetDbContext Context { get; }
        //metodo para guardad cambios asincronos generales
        public Task SaveChanguesAsync();

    }
}
