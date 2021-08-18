using Microsoft.AspNet.Identity;
using PollingModel;
using PollingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace PollSurveyApp.API.NET.Controllers
{
    [Authorize]
    public class AdminController : ApiController
    {
        private AdminService CreateAdminService()
        {
            var id = User.Identity.GetUserId();
            var adminDetail = new AdminService(id.ToString());
            return adminDetail;
        }

        [HttpPost]
        public IHttpActionResult PostAdminCreate(AdminCreate adminCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var adminService = CreateAdminService();
            if (!adminService.CreateAdmin(adminCreate))
                return InternalServerError();
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetAllAdmin()
        {
            AdminService adminService = CreateAdminService();
            var users = adminService.GetSurveys();
            return Ok(users);
        }

        [HttpGet]
        public IHttpActionResult GetAppUserId(string id)
        {
            AdminService adminService = CreateAdminService();
            var adminDetail = adminService.GetUserId(id);
            return Ok(adminDetail);
        }

        [HttpPut]
        public IHttpActionResult UpdatePlan(AdminEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAdminService();
            if (!service.UpdatePlan(model))
                return InternalServerError();
            return Ok();
        }


    }
}