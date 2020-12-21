using AutoMapper;
using CivicHub.Dtos;
using CivicHub.Entities;
using CivicHub.Interfaces;
using CivicHub.IServices;
using CivicHub.Mapper;
using CivicHub.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CivicHub.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepostiory;
        private readonly IIssueRepository _issueRepository;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings, IMapper mapper, IIssueRepository issueRepository)
        {
            this._userRepostiory = userRepository;
            this._appSettings = appSettings.Value;
            this._issueRepository = issueRepository;
            _mapper = mapper;
        }

        public bool Register(RegisterRequest request)
        {
            var entity = new User
            {
                Mail = request.Mail,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateRegistered = DateTime.Now
            };

            _userRepostiory.Create(entity);
            return _userRepostiory.SaveChanges();
        }

        public List<UserDto> GetAll()
        {
            var registeredUsersDtos = _mapper.Map<List<UserDto>>(_userRepostiory.GetAll());

            foreach (UserDto user in registeredUsersDtos)
            {
                user.Issues = _mapper.Map<List<IssueDto>>(_issueRepository.FindByUserIdAsync(user.Id).Result);
            }

            return registeredUsersDtos;
        }

        public UserDto GetById(Guid id)
        {
            var userDto = _mapper.Map<UserDto>(_userRepostiory.FindById(id));

            userDto.Issues = _mapper.Map<List<IssueDto>>(_issueRepository.FindByUserIdAsync(userDto.Id).Result);

            return userDto;
        }
        
        public AuthenticationResponse Login(AuthenticationRequest request)
        {
            // find user
            var user = _userRepostiory.GetByUserAndPassword(request.Mail, request.Password);
            if (user == null)
                return null;

            // attach token
            var token = GenerateJwtForUser(user);

            // return user & token
            return new AuthenticationResponse
            {
                Id = user.Id,
                Mail = user.Mail,
                Token = token
            };
        }

        private string GenerateJwtForUser(User user)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
