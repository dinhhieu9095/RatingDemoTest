using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemoTest.Business.DTO
{
    public class QuestionDTO
    {
        public QuestionDTO()
        {
            this.AnswerOptions = new List<AnswerOptionDTO>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public int ServiceID { get; set; }

        public List<AnswerOptionDTO> AnswerOptions { get; set; }
        public ServiceDTO Service { get; set; }
    }
}
