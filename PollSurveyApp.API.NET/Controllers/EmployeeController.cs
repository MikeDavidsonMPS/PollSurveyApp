using Microsoft.AspNet.Identity;
using PollingModel;
using PollingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace PollSurveyApp.API.NET.Controllers
{
   
    public class EmployeeController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Post(EmployeeCreate employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEmployeeService();
            if (!service.CreateEmployee(employee))
                return InternalServerError();
            return Ok("You have created new Employee ");
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employee = employeeService.GetEmployees();
            return Ok(employee);
        }
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            EmployeeService empolyeeService = CreateEmployeeService();

            var employee = empolyeeService.GetEmployeeById(id);

            return Ok(employee);
        }
        [HttpPut]
        public IHttpActionResult Update(EmployeeEdit employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateEmployeeService();

            if (!service.UpdateEmployee(employee))
            {
                return InternalServerError();
            }

            return Ok("Employee has been updated!");
        }
        [HttpPut]
        public IHttpActionResult Delete(int employeeId)
        {
            var service = CreateEmployeeService();

            if (!service.DeleteEmployee(employeeId))
            {
                return InternalServerError();
            }
            return Ok("Employee has been deleted!");
        }


        private EmployeeService CreateEmployeeService()
        {
            var userId = User.Identity.GetUserId();
            var noteService = new EmployeeService(userId);

            return noteService;
        }

    }
}