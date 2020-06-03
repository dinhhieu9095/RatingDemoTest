using AutoMapper;
using RatingDemoTest.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatingDemoTest.MVC
{
    public class MappingProfileModel : Profile
    {
        
        public MappingProfileModel()
        {
            CreateMap<AnswerDTO, AnswerModel>();
            CreateMap<QuestionDTO, QuestionModel>();
            CreateMap<ServiceDTO, ServiceModel>();
            CreateMap<UserDTO, UserModel>();
            CreateMap<FilterDTO, FilterModel>();

            CreateMap<AnswerDTO, AnswerModel>().ReverseMap();
            CreateMap<QuestionDTO, QuestionModel>().ReverseMap();
            CreateMap<ServiceDTO, ServiceModel>().ReverseMap();
            CreateMap<UserDTO, UserModel>().ReverseMap();
            CreateMap<FilterDTO, FilterModel>().ReverseMap();
        }
    }
}