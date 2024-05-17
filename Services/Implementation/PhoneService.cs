using Fuchonet.Entities.Models;
using Fuchonet.Repositories;
using Fuchonet.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Services.Implementation
{
    public class PhoneService : IPhoneService
    {
        public PhoneService(IPhoneRepository phoneRepository) 
        {
        }
    }
}
