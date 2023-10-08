using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
                      
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductTypeConfiguration());
            builder.ApplyConfiguration(new ProductBrandConfiguration());         
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new DeliveryMethodConfiguration());
        
        }
    }
}
