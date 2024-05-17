using Fuchonet.Entities.Models;
using Fuchonet.Repositories;
using Fuchonet.Repositories.Interface;
using Fuchonet.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Services.Implementation
{
    public class ServiceCategoryService :  IServiceCategoryService
    {
        public IUnitOfWork _unitOfWork;
        public ServiceCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ServiceCategory>> GetAll()
        {
            return await _unitOfWork.ServiceCategoryRepository.GetAll();
        }
    }
}

