using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IProductRepository
    {


        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<List<ProductType>> GetAllProductTypesAsync();
        Task<List<ProductBrand>> GetAllProductBrandsAsync();


    }
}
