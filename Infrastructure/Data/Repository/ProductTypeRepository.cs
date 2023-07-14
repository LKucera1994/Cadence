using Core.Entities;
using Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        private DataContext dataContext;
        public ProductTypeRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task Update(ProductType productType)
        {
            var productTypeFromDb = dataContext.ProductTypes.FirstOrDefault(x => x.Id == productType.Id);

            if (productTypeFromDb != null)
            {

                productTypeFromDb.Name = productType.Name; 


            }
        }
    }
}
