using AutoMapper;
using RatingDemoTest.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatingDemoTest.Business.DTO
{
    public class MappingProfileDTO : Profile
    {
        
        public MappingProfileDTO()
        {
            CreateMap<AnswerDTO, Answer>();
            CreateMap<QuestionDTO, Question>();
            CreateMap<ServiceDTO, Service>();
            CreateMap<UserDTO, User>();

            CreateMap<AnswerDTO, Answer>().ReverseMap();
            CreateMap<QuestionDTO, Question>().ReverseMap();
            CreateMap<ServiceDTO, Service>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}