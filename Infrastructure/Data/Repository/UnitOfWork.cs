

using System;
using System.Collections.Generic;
using Infrastructure.Data.Repository.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using Infrastructure.Data.Interfaces;

namespace Infrastructure.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        

        public UnitOfWork(DataContext dataContext)
        {
            
            _dataContext = dataContext;
            Product = new ProductRepository(_dataContext);
            ProductBrand = new ProductBrandRepository(_dataContext);
            ProductType = new ProductTypeRepository(_dataContext);          
            DeliveryMethod = new DeliveryMethodRepository(_dataContext);       
            Basket = new BasketRepository(_dataContext);
            //OrderRepository = new OrderRepository(BasketRepository, _dataContext);

        }

        public IProductRepository Product { get; set; }
        public IProductBrandRepository ProductBrand { get; set; }
        public IProductTypeRepository ProductType { get; set; }
        public IDeliveryMethodRepository DeliveryMethod { get; set; }
        public IOrderRepository Order { get; set; }
        public IBasketRepository Basket { get; set; }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        

        public async Task<int> Save()
        {
            return await _dataContext.SaveChangesAsync();
        }
        

    }
}
