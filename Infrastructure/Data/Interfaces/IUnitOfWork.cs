
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
        IBasketRepository Basket { get; }
        IOrderRepository Order { get; }
        
        





        Task<int> Save();
    }
}
