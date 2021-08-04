using PollingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PollSurveyApp.API.NET.Controllers
{
    public class DepartmentController : ApiController
    {
        // GET api/department/
        public IHttpActionResult Get()
        {
            return Ok(new[]
            {
                new {id = (int) DepartmentsEnum.Accounting, name = DepartmentsEnum.Accounting.ToString()},
                new {id = (int) DepartmentsEnum.AccountsReceivable, name = DepartmentsEnum.AccountsReceivable.ToString()},
                new {id = (int) DepartmentsEnum.HumanResource, name = DepartmentsEnum.HumanResource.ToString()},
                new {id = (int) DepartmentsEnum.ShippingReceiving, name = DepartmentsEnum.ShippingReceiving.ToString()}
            });
        }
    }
}