using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class SeedUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var appUser = new AppUser
             {

                
                DisplayName = "Steve",
                Email = "steve@test.com",
                UserName = "steve@test.com",
                NormalizedUserName = "STEVE@TEST.COM",
                NormalizedEmail = "STEVE@TEST.COM",
                FirstName = "Steve",
                LastName = "Stevenson",
                Street = "TestStreet",
                State = "TestState",
                City = "TestCity",
                ZipCode = "1111"
                



            };

            var passwordHasher = new PasswordHasher<AppUser>();

            appUser.PasswordHash = passwordHasher.HashPassword(appUser, "TestPa$$W0rd");


            builder.HasData(appUser);
        }














       

    }

}
