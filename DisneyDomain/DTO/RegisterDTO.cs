using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyDomain.DTO
{
    public class RegisterDTO
    {
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required]
        public string Email { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
    }
}
