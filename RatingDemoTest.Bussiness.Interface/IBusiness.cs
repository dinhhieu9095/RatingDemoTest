using RatingDemoTest.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemoTest.Business.Interface
{
    public interface IBusiness
    {
        IList<ServiceDTO> GetServices();
        IList<QuestionDTO> GetQuestionByServiceID(FilterDTO filterDTO);
        IList<AnswerDTO> GetAnswers(FilterDTO filterDTO);
        bool SaveAnswer(AnswerDTO answerDTO);
        bool UpdateAnswer(AnswerDTO answerDTO);
        bool InsertAnswer(AnswerDTO answerDTO);
        UserDTO GetUser(FilterDTO filterDTO);
    }
}
