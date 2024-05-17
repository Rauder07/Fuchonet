using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Services.Interface
{
    public interface IServiceAgrementService
    {
        public Task<int> CountServiceAgrementByService(string status_service);
    }
}
