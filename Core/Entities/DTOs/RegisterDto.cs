using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{10,}$",
        ErrorMessage = "Password must have at least 10 Characters, 1 Uppercase letter, 1 Lowercase letter, 1 Digit and 1 non-alphanumeric character")]
        public string Password { get; set; }
        [Required] 
        public string DisplayName { get; set; }
    }
}
