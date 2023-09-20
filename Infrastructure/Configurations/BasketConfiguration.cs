using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<UserBasket>
    {
        public void Configure(EntityTypeBuilder<UserBasket> builder)
        {
            builder.HasMany(x => x.Items)
                .WithOne(x => x.UserBasket)
                .HasForeignKey(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
    
}
