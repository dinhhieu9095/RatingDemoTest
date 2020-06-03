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
            this.Answers = new List<AnswerDTO>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public int ServiceID { get; set; }

        public List<AnswerDTO> Answers { get; set; }
        public ServiceDTO Service { get; set; }
    }
}
