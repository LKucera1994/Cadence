

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
        private readonly IConnectionMultiplexer _database;
        private bool _disposed;
        


        public UnitOfWork(DataContext dataContext, IConnectionMultiplexer database)
        {
            
            _dataContext = dataContext;
            _database = database;
            
            Product = new ProductRepository(_dataContext);
            ProductBrand = new ProductBrandRepository(_dataContext);
            ProductType = new ProductTypeRepository(_dataContext);          
            DeliveryMethod = new DeliveryMethodRepository(_dataContext);
            Basket = new BasketRepository(redis: _database);
            Order = new OrderRepository(Basket, _dataContext);
            
            
            
            
            

        }

        

        public IProductRepository Product { get; set; }
        public IProductBrandRepository ProductBrand { get; set; }
        public IProductTypeRepository ProductType { get; set; }
        public IDeliveryMethodRepository DeliveryMethod { get; set; }
        public IOrderRepository Order { get; set; }

        public IBasketRepository Basket { get; set; }

        

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if(disposing)
                {
                    _dataContext.Dispose();
                }
            }
        }
        

        public void Dispose()
        {
            _dataContext.Dispose();
            GC.SuppressFinalize(this);
        }

        

        

        public async Task<int> Save()
        {
            return await _dataContext.SaveChangesAsync();
        }
        

    }
}
