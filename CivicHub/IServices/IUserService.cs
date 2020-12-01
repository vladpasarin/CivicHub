using CivicHub.Entities;
using CivicHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    public interface IUserService
    {
        User GetById(int id);
        List<User> GetAll();
        bool Register(RegisterRequest request);
        AuthenticationResponse Login(AuthenticationRequest request);
    }
}
