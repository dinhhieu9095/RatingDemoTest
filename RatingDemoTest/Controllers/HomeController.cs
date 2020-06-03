using AutoMapper;
using RatingDemoTest.Business.DTO;
using RatingDemoTest.Business.Interface;
using RatingDemoTest.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RatingDemoTest.MVC
{
    public class HomeController : Controller
    {
        private IBusiness Business;

        public UserDTO UserContext
        {
            get
            {

                return Session["Session_AccountInfo"] as UserDTO;
            }
            set { Session["Session_AccountInfo"] = value; }
        }
        public HomeController(IBusiness business)
        {
            this.Business = business;
        }

        public ActionResult Index()
        {
            var services = Business.GetServices();
            return View();
        }
        [HttpGet]
        public JsonResult GetServices()
        {
            JsonModel model = new JsonModel();
            try
            {
                List<ServiceModel> serviceModels = new List<ServiceModel>();
                IList<ServiceDTO> serviceDTOs = new List<ServiceDTO>();
                serviceDTOs = this.Business.GetServices();
                serviceModels = AutoMapper.Mapper.Map<List<ServiceModel>>(serviceDTOs);
                model = new JsonModel()
                {
                    Result = true,
                    Data = serviceModels
                };
            }
            catch (Exception ex)
            {
                Logging.LogError("HomeController - GetServices: ", ex);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetQuestions(FilterModel filterModel)
        {
            JsonModel model = new JsonModel();
            try
            {
                FilterDTO filterDTO = Mapper.Map<FilterDTO>(filterModel);

                UserDTO userDTO = this.Business.GetUser(filterDTO);
                if (userDTO == null)
                {
                    model = new JsonModel()
                    {
                        Result = false,
                        Message = "Vui lòng kiểm tra mật khẩu"
                    };
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                UserContext = userDTO;

                List<QuestionModel> questionModels = new List<QuestionModel>();
                IList<QuestionDTO> questionDTOs = new List<QuestionDTO>();
                questionDTOs = this.Business.GetQuestionByServiceID(filterDTO);
                questionModels = Mapper.Map<List<QuestionModel>>(questionDTOs);
                model = new JsonModel() {
                    Result = true,
                    Data = questionModels
                };
            }
            catch (Exception ex)
            {
                Logging.LogError("HomeController - GetQuestions: ", ex);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Login(FilterModel filterModel)
        {
            JsonModel model = new JsonModel();
            try
            {
                FilterDTO filterDTO = Mapper.Map<FilterDTO>(filterModel);

                UserDTO userDTO = this.Business.GetUser(filterDTO);
                if (userDTO == null)
                {

                    model = new JsonModel()
                    {
                        Result = false,
                        Message = "Vui lòng kiểm tra mật khẩu"
                    };
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                UserContext = userDTO;
                model = new JsonModel()
                {
                    Result = true,
                };
            }
            catch (Exception ex)
            {
                Logging.LogError("HomeController - ConfirmPassCode: ", ex);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult LogOut(FilterModel filterModel)
        {
            JsonModel model = new JsonModel();
            try
            {
                FilterDTO filterDTO = Mapper.Map<FilterDTO>(filterModel);
                UserDTO userDTO = this.Business.GetUser(filterDTO);
                if (userDTO == null)
                {

                    model = new JsonModel()
                    {
                        Result = false,
                        Message = "Vui lòng kiểm tra mật khẩu"
                    };
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                UserContext = null;
                model = new JsonModel()
                {
                    Result = true,
                };
            }
            catch (Exception ex)
            {
                Logging.LogError("HomeController - ConfirmPassCode: ", ex);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult SaveAnswer(AnswerModel answerModel)
        {
            JsonModel model = new JsonModel();
            try
            {
                AnswerDTO answerDTO = Mapper.Map<AnswerDTO>(answerModel);
                bool rs = this.Business.SaveAnswer(answerDTO);
                model = new JsonModel()
                {
                    Result = rs,
                };
            }
            catch (Exception ex)
            {
                Logging.LogError("HomeController - SaveAnswer: ", ex);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        
    }
}