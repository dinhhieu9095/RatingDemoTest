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
                questionDTOs = this.UnitOfWork.GetItems<QuestionDTO, Question>(e=>e.ID == filterDTO.ID);
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
                var answer = UnitOfWork.GetItem<Answer>(e => e.ID == answerDTO.ID);
                if(answer!= null)
                {
                    answer = AutoMapper.Mapper.Map<Answer>(answerDTO);
                    UnitOfWork.Update<Answer>(answer);
                    UnitOfWork.Commit(tran);
                    rs = true;
                }
                else
                {
                    UnitOfWork.Insert<AnswerDTO, Answer>(answerDTO);
                    UnitOfWork.Commit(tran);
                    rs = true;
                }
                
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback(tran);
                Logging.LogError("Business-UpdateAnswer: ", ex);
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
