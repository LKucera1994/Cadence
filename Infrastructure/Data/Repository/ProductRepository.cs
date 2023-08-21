using Core.Entities;
using Infrastructure.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private  DataContext dataContext;
        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task Update(Product product)
        {
            var productFromDb = dataContext.Products.FirstOrDefault(x=> x.Id == product.Id);

            if(productFromDb != null)
            {

                productFromDb.Name = product.Name;
                productFromDb.Price = product.Price;
                productFromDb.ProductType = product.ProductType;
                productFromDb.ProductTypeId = product.ProductTypeId;
                productFromDb.ProductBrand = product.ProductBrand;
                productFromDb.ProductBrandId = product.ProductBrandId;
                productFromDb.Description = product.Description;

                if (product.PhotoUrl != null)
                {
                    productFromDb.PhotoUrl = product.PhotoUrl;

                }
 

            }

        }
    }
}
