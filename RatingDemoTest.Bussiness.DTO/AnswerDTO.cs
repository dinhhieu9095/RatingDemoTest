using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemoTest.Business.DTO
{
    public class AnswerDTO
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public double Point { get; set; }
        public int QuestionID { get; set; }
        public int UserID { get; set; }

        public QuestionDTO Question { get; set; }
        public UserDTO User { get; set; }
    }
}
