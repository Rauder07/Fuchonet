using AutoMapper;
using FuchonetAPI.Dtos;
using FuchonetAPI.Models;

namespace FuchonetAPI.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PhonesToListDTO, Phone >()
                .ReverseMap();
            //origen , destino || .reversMap hace que sea un mapeado en ambos sentidos
            CreateMap<Customer, CustomerToListDTO>()
                .ForMember(dest => dest.FullName,
                            opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
