using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemoTest.MVC
{
    public class ServiceModel
    {
        public ServiceModel()
        {
            this.Questions = new List<QuestionModel>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }

        public List<QuestionModel> Questions { get; set; }
    }
}
