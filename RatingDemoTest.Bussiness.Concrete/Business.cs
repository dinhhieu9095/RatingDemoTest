using RatingDemoTest.Business.DTO;
using RatingDemoTest.Business.Interface;
using RatingDemoTest.Log;
using RatingDemoTest.Repository.Entities;
using RatingDemoTest.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemoTest.Business.Concrete
{
    public class Business : IBusiness
    {
        #region Properties
        protected IUnitOfWork UnitOfWork { get; set; }

        #endregion

        #region Constructors
        public Business(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        #endregion
        #region Methods
        public IList<ServiceDTO> GetServices()
        {
            IList<ServiceDTO> serviceDTOs = new List<ServiceDTO>();
            try
            {
                serviceDTOs = this.UnitOfWork.GetItems<ServiceDTO, Service>();
            }
            catch (Exception ex)
            {
                Logging.LogError("Business-GetServices: ", ex);
            }
            return serviceDTOs;
        }

        public IList<QuestionDTO> GetQuestionByServiceID(FilterDTO filterDTO)
        {
            IList<QuestionDTO> questionDTOs = new List<QuestionDTO>();
            try
            {
                questionDTOs = this.UnitOfWork.GetQueryable<Question>().Where(e=>e.ServiceID == filterDTO.ID)
                    .Select(e=> new QuestionDTO() {
                        ID = e.ID,
                        ServiceID = e.ServiceID,
                        Title = e.Title,
                        AnswerOptions = e.AnswerOptions.Select(a=> new AnswerOptionDTO {
                            ID = a.ID,
                            Icon = a.Icon,
                            Point = a.Point,
                            QuestionID = a.QuestionID,
                            Title = a.Title
                        }).ToList()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Logging.LogError("Business-GetQuestionByServiceID: ", ex);
            }
            return questionDTOs;
        }

        public IList<AnswerDTO> GetAnswers(FilterDTO filterDTO)
        {
            IList<AnswerDTO> answerDTOs = new List<AnswerDTO>();
            try
            {
                answerDTOs = this.UnitOfWork.GetItems<AnswerDTO, Answer>(e => e.QuestionID == filterDTO.ID && e.UserID == filterDTO.UserID);
            }
            catch (Exception ex)
            {
                Logging.LogError("Business-GetAnswers: ", ex);
            }
            return answerDTOs;
        }
        public bool SaveAnswer(AnswerDTO answerDTO)
        {
            bool rs = false;
            var tran = UnitOfWork.BeginTransaction();
            try
            {
                var answer = UnitOfWork.GetItem<Answer>(e => e.QuestionID == answerDTO.QuestionID && e.UserID == answerDTO.UserID);
                if(answer!= null)
                {
                    answer.Point = answerDTO.Point;
                    answer.QuestionID= answerDTO.QuestionID;
                    answer.UserID = answerDTO.UserID;
                    answer.Comment = answerDTO.Comment;
                    UnitOfWork.Update<Answer>(answer);
                    UnitOfWork.Commit(tran);
                    rs = true;
                }
                else
                {
                    answer = UnitOfWork.InsertWidthResult<AnswerDTO, Answer>(answerDTO);
                    UnitOfWork.Commit(tran);
                    rs = true;
                }
                Logging.LogInfo(answer.QuestionID + "       " + answer.Point + "        " + answerDTO.Comment + "       " + DateTime.Now.ToString("dd/MM/yyy HH:mm:ss"));
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback(tran);
                Logging.LogError("Business-SaveAnswer: ", ex);
            }
            return rs;
        }
        public bool UpdateAnswer(AnswerDTO answerDTO)
        {
            bool rs = false;
            var tran = UnitOfWork.BeginTransaction();
            try
            {
                UnitOfWork.Update<AnswerDTO, Answer>(answerDTO);
                UnitOfWork.Commit(tran);
                rs = true;
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback(tran);
                Logging.LogError("Business-UpdateAnswer: ", ex);
            }
            return rs;
        }
        public bool InsertAnswer(AnswerDTO answerDTO)
        {
            bool rs = false;
            var tran = UnitOfWork.BeginTransaction();
            try
            {
                UnitOfWork.Insert<AnswerDTO, Answer>(answerDTO);
                UnitOfWork.Commit(tran);
                rs = true;
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback(tran);
                Logging.LogError("Business-UpdateAnswer: ", ex);
            }
            return rs;
        }
        public UserDTO GetUser(FilterDTO filterDTO)
        {
            UserDTO userDTO = null;
            try
            {
                userDTO = this.UnitOfWork.GetItem<UserDTO, User>(e => e.PassWord == filterDTO.PassCode);
            }
            catch (Exception ex)
            {
                Logging.LogError("Business-GetUser: ", ex);
            }
            return userDTO;
        }
        #endregion

    }
}
