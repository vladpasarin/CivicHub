using CivicHub.Dtos;
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
        UserDto GetById(Guid id);
        List<UserDto> GetAll();
        bool Register(RegisterRequest request);
        AuthenticationResponse Login(AuthenticationRequest request);
        User AddPoints(Guid userId, int numberOfPoints);
        User UsePoints(Guid userId, int numberOfPoints);
        List<User> getUsersTop();
    }
}
