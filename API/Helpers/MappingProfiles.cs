using AutoMapper;
using Core.Entities;
using Core.Entities.DTOs;

namespace API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(destination => destination.ProductBrand, origin => origin.MapFrom(x => x.ProductBrand.Name))
                .ForMember(destination => destination.ProductType, origin => origin.MapFrom(x => x.ProductType.Name))
                .ForMember(destination => destination.PhotoUrl, origin => origin.MapFrom<ProductUrlResolver>());
        }
    }
}
