using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemoTest.MVC
{
    public class QuestionModel
    {
        public QuestionModel()
        {
            this.Answers = new List<AnswerModel>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public int ServiceID { get; set; }

        public List<AnswerModel> Answers { get; set; }
        public ServiceModel Service { get; set; }
    }
}
