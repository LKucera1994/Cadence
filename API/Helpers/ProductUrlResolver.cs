using AutoMapper;
using Core.Entities;
using Core.Entities.DTOs;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PhotoUrl))
            {
                return _config["ApiUrl"];
            }
            return null;
        }
    }
}
