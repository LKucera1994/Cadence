using Core.Entities;
using Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class ProductBrandRepository : Repository<ProductBrand>, IProductBrandRepository
    {
        private readonly DataContext dataContext;
        public ProductBrandRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task Update(ProductBrand productBrand)
        {
            var productBrandFromDb = dataContext.ProductBrands.FirstOrDefault(x => x.Id == productBrand.Id);

            if (productBrandFromDb != null)
            {

                productBrandFromDb.Name = productBrand.Name;


            }
        }
    }
}
