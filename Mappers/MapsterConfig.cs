using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuchonet.Dto.Response;
using Fuchonet.Entities.Models;
using System.Reflection;

namespace Fuchonet.Mappers
{
    public static    class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Phone, PhoneDTO>.NewConfig()
               .Map(dest => dest.PhoneRelationship, src => src.PhoneRelationships.Adapt<List<PhoneRelationshipDTO>>());

            TypeAdapterConfig<Zone, ZoneDTO>.NewConfig()
               .Map(dest => dest.Name, src => src.Name);

            TypeAdapterConfig<Address, AddressDTO>.NewConfig()
                .Map(dest => dest.Address, src => src.Address1)
                .Map(dest => dest.Zone, src => src.Zone.Adapt<ZoneDTO>());

           

            TypeAdapterConfig<Customer, CustomerDTO>.NewConfig()
                .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
                .Map(dest => dest.Address, src => src.Addresses.Adapt<List<AddressDTO>>())
                .Map(dest => dest.Phones, src => src.Phones.Adapt<List<PhoneDTO>>());

      
            //.Map(dest => dest.Phones, src => new List<PhoneDTO>() { new PhoneDTO{ Id = src.Id } });

            TypeAdapterConfig<ServiceCategory, ServiceCategoryDTO>.NewConfig()
                .Map(dest => dest.Services, src => src.Services.Adapt<List<ServiceCategoryDTO>>());


            //Scan all mappers
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}


