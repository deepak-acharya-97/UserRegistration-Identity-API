using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; }
    }
}
