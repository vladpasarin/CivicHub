using CivicHub.Entities;
using CivicHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Mapper
{
    public static class UserMapper
    {
        public static User ToUser(AuthenticationRequest request)
        {
            return new User
            {
                Mail = request.Mail,
                Password = request.Password
            };
        }

        public static User ToUserExtension(this AuthenticationRequest request)
        {
            return new User
            {
                Mail = request.Mail,
                Password = request.Password
            };
        }

        public static User ToUserExtension(this RegisterRequest request)
        {
            return new User
            {
                Mail = request.Mail,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
        }
    }
}
