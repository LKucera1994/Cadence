using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Identity
{
    public class AppUser:IdentityUser
    {
        public string DisplayName { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
