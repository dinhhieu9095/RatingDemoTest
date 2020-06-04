using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemoTest.Business.DTO
{
    public class AnswerOptionDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Nullable<int> QuestionID { get; set; }
        public Nullable<int> Point { get; set; }
        public string Icon { get; set; }

        public virtual QuestionDTO Question { get; set; }
    }
}
