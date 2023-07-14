using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Interfaces
{
    public interface IProductTypeRepository: IRepository<ProductType>
    {
        Task Update(ProductType productType); 
    }
}
