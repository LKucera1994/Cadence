

using System;
using System.Collections.Generic;
using Infrastructure.Data.Repository.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        }

        public IProductRepository Product { get; set; }
        public IProductBrandRepository ProductBrand { get; set; }
        public IProductTypeRepository ProductType { get; set; }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
        

    }
}
