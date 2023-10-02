using Core.Entities;
using Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class ProductBrandRepository : GenericRepository<ProductBrand>, IProductBrandRepository
    {
        private readonly DataContext dataContext;
        public ProductBrandRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }
        
    }
}
