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
            this.AnswerOptions = new List<AnswerOptionModel>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public int ServiceID { get; set; }

        public List<AnswerOptionModel> AnswerOptions { get; set; }
        public ServiceModel Service { get; set; }
    }
}
