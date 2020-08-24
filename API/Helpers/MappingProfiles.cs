using API.Dtos;
using AutoMapper;
using core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
             CreateMap<product, ProductToReturnDto>()
             .ForMember(d => d.ProductBrand,  o=> o.MapFrom(s => s.ProductBrand.Name))
             .ForMember(d => d.ProductType,  o=> o.MapFrom(s => s.ProductType.Name))
             .ForMember(d => d.pictureurl , o => o.MapFrom<ProductUrlReslover>());

        }

    }
}