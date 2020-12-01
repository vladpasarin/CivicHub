using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Models
{
    public class AuthenticationRequest
    {
        [Required]
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
