using Microsoft.AspNet.Identity;
using PollingModel;
using PollingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace PollSurveyApp.API.NET.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
    
        public IHttpActionResult Get()
        {
            EmployeeService employeeService = CreateEmployeeService();

            var employee = employeeService.GetEmployees();

            return Ok(employee);
        }
        public IHttpActionResult Post(EmployeeCreate employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateEmployeeService();

            if (!service.CreateEmployee(employee))
            {
                return InternalServerError();
            }

            return Ok("You have created new Employee ");
        }

        public IHttpActionResult Get(int id)
        {
            EmployeeService empolyeeService = CreateEmployeeService();

            var employee = empolyeeService.GetEmployeeById(id);

            return Ok(employee);
        }

        public IHttpActionResult Put(EmployeeEdit employee)
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

        public IHttpActionResult Delete(int id)
        {
            var service = CreateEmployeeService();

            if (!service.DeleteEmployee(id))
            {
                return InternalServerError();
            }
            return Ok("Employee has been deleted!");
        }
        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new EmployeeService(userId);

            return noteService;
        }
    }
}