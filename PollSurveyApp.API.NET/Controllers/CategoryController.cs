using PollingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PollSurveyApp.API.NET.Controllers
{
    public class CategoryController : ApiController
    {
        // GET api/department/
        public IHttpActionResult Get()
        {
            return Ok(new[]
            {
                new {id = (int) CategoriesEnum.Admin, name = CategoriesEnum.Admin.ToString()},
                new {id = (int) CategoriesEnum.Personal, name = CategoriesEnum.Personal.ToString()},
                new {id = (int) CategoriesEnum.Client, name = CategoriesEnum.Client.ToString()},
            });
        }
    }
}