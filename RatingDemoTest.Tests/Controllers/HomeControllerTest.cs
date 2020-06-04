using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RatingDemoTest;
using RatingDemoTest.Business.Interface;
using RatingDemoTest.Business.Concrete;
using RatingDemoTest.MVC;
using RatingDemoTest.Repository.Interface;
using RatingDemoTest.Repository.EF;
using RatingDemoTest.Business.DTO;
using RatingDemoTest.Repository.Entities;
using AutoMapper;

namespace RatingDemoTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void GetQuestions()
        {
            // Arrange
            Mapper.Initialize(x => {
                x.AddProfile<MappingProfileModel>();
                x.AddProfile<MappingProfileDTO>();
            });
            RatingDemoTestEntities ratingDemoTestEntities = new RatingDemoTestEntities();
            IUnitOfWork unitOfWork = new UnitOfWork(ratingDemoTestEntities);
            IBusiness Business = new Business.Concrete.Business(unitOfWork);

            // Act
            FilterDTO filterDTO = new FilterDTO
            {
                PassCode = "P@ssw0rd"
            };
            var result = Business.GetUser(filterDTO);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SaveAnswer()
        {
            // Arrange
            Mapper.Initialize(x => {
                x.AddProfile<MappingProfileModel>();
                x.AddProfile<MappingProfileDTO>();
            });
            RatingDemoTestEntities ratingDemoTestEntities = new RatingDemoTestEntities();
            IUnitOfWork unitOfWork = new UnitOfWork(ratingDemoTestEntities);
            IBusiness Business = new Business.Concrete.Business(unitOfWork);

            // Act
            AnswerDTO answerDTO = new AnswerDTO
            {
                QuestionID = 1,
                Comment = "Comment",
                Point = 4,
                UserID = 1
            };
            bool result = Business.SaveAnswer(answerDTO);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
