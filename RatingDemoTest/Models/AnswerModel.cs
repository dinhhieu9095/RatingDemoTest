using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemoTest.MVC
{
    public class AnswerModel
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public double Point { get; set; }
        public int QuestionID { get; set; }
        public int UserID { get; set; }

        public QuestionModel Question { get; set; }
        public UserModel User { get; set; }
    }
}
