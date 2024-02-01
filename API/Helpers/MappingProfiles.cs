
using AutoMapper;
using Core.Entities;
using Core.Entities.DTOs;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;

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

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(destination => destination.DeliveryMethod, origin => origin.MapFrom(x=> x.DeliveryMethod.ShortName))
                .ForMember(destination => destination.ShippingPrice, origin => origin.MapFrom(x => x.DeliveryMethod.Price));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(destination => destination.ProductId, origin => origin.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(destination => destination.ProductName, origin => origin.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(destination => destination.PhotoUrl, origin => origin.MapFrom<OrderItemResolver>());

            CreateMap<AppUserDto, Address>();
            CreateMap<UserBasketDto, UserBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AppUser, AppUserDto>().ReverseMap();
        }
    }
}
