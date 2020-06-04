using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatingDemoTest.MVC
{
    public class AnswerOptionModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Nullable<int> QuestionID { get; set; }
        public Nullable<int> Point { get; set; }
        public string Icon { get; set; }

        public QuestionModel Question { get; set; }
    }
}