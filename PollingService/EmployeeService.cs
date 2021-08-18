using PollingData;
using PollingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingService
{
    public class EmployeeService
    {
        private readonly string _userId;

        public EmployeeService(string userId)
        {
            _userId = userId;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    new Employee()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Department = (PollingData.DepartmentsEnum)model.Department,
                        Email = model.Email
                    };

                ctx.EmployeeUsers.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }

        public IEnumerable<EmployeeModel> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .EmployeeUsers
                    .Where(e => e.UserId == _userId)
                    .Select(e => new EmployeeModel
                    {
                        EmployeeId =e.EmployeeId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Department = (PollingModel.DepartmentsEnum)e.Department,
                        Email = e.Email
                    });

                return query.ToArray();
            }
        }

        public EmployeeDetail GetEmployeeById(int _userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.
                    EmployeeUsers.Single(e => e.EmployeeId == _userId);
                return new EmployeeDetail
                {
                    EmployeeId = entity.EmployeeId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Department = (PollingModel.DepartmentsEnum)entity.Department,
                    Email = entity.Email,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc

                };
            }
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .EmployeeUsers
                    .Single(e => e.UserId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Department = (PollingData.DepartmentsEnum)model.Department;
                entity.Email = model.Email;
                entity.ModifiedUtc = model.ModifiedUtc;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmployee(int _userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.EmployeeUsers
                    .Single(e => e.EmployeeId == _userId);

                ctx.EmployeeUsers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
