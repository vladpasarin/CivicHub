using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Models
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }
        public string Mail { get; set; }
        public string Token { get; set; }
    }
}
