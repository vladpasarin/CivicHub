using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CivicHub.Models
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Cnp { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string SerieBuletin { get; set; }
        [Required]
        public string NumarBuletin { get; set; }
    }
}
