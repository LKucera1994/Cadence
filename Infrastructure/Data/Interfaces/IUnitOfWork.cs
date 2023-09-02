
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        IProductBrandRepository ProductBrand { get; }
        IProductTypeRepository ProductType { get; }

        void Save();
    }
}
