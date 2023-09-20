
using Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IProductRepository Product { get; }
        IProductBrandRepository ProductBrand { get; }
        IProductTypeRepository ProductType { get; }
      
        IDeliveryMethodRepository DeliveryMethod { get; }
        IOrderRepository Order { get; }

        IBasketRepository Basket { get; }





        Task<int> Save();
    }
}
