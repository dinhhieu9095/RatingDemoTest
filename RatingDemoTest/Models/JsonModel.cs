using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatingDemoTest.MVC
{
    public class JsonModel
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}