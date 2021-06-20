using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PollSurveyApp.API.NET.Controllers
{
    public class SurveyController : Controller
    {
        // GET: PollData
        public ActionResult Index()
        {
            return View();
        }
    }
}