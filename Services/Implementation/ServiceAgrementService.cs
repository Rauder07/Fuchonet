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
    public class ServiceAgrementService : IServiceAgrementService
    {
        public IUnitOfWork _unitOfWork;
        public ServiceAgrementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CountServiceAgrementByService(string status_service)
        {
            return await  _unitOfWork.ServiceAgrementRepository.CountServiceAgrementByService(status_service);
        }
    }
}
