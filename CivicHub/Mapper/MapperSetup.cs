using AutoMapper;
using CivicHub.Dtos;
using CivicHub.Entities;
using CivicHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Mapper
{
    public class MapperSetup : Profile
    {

        public MapperSetup()
        {
            CreateMap<Issue, IssueDto>();
            CreateMap<IssueDto, Issue>();
            CreateMap<IssueState, IssueStateDto>();
            CreateMap<IssueStateDto, IssueState>();
            CreateMap<IssueStateCommentDto, IssueStateDto>();
        }

        //public static User ToUser(AuthenticationRequest request)
        //{
        //    return new User
        //    {
        //        Mail = request.Mail,
        //        Password = request.Password
        //    };
        //}

        //public static User ToUserExtension(this AuthenticationRequest request)
        //{
        //    return new User
        //    {
        //        Mail = request.Mail,
        //        Password = request.Password
        //    };
        //}

        //public static User ToUserExtension(this RegisterRequest request)
        //{
        //    return new User
        //    {
        //        Mail = request.Mail,
        //        Password = request.Password,
        //        FirstName = request.FirstName,
        //        LastName = request.LastName
        //    };
        //}
    }
}
