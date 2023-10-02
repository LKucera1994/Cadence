using Core.Entities;
using Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class ProductTypeRepository : GenericRepository<ProductType>, IProductTypeRepository
    {
        private readonly DataContext dataContext;
        public ProductTypeRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }
        
    }
}
