using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemoTest.Business.DTO
{
    public class ServiceDTO
    {
        public ServiceDTO()
        {
            this.Questions = new List<QuestionDTO>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }

        public List<QuestionDTO> Questions { get; set; }
    }
}
