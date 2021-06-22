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
        private readonly Guid _userId;

        public EmployeeService(Guid userId)
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
                        OwnerId = _userId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Department = model.Department,
                        Email = model.Email
                    };

                ctx.EmployUsers.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }

        public IEnumerable<EmployeeModel> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .EmployUsers
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new EmployeeModel
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Department = e.Department,
                        Email = e.Email
                    });

                return query.ToArray();
            }
        }

        public EmployeeDetail GetEmployeeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.EmployUsers.Single(e => e.EmployId == id && e.OwnerId == _userId);

                return new EmployeeDetail
                {
                    EmployId = entity.EmployId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Department = entity.Department,
                    Email = entity.Email
                
                };
            }
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .EmployUsers
                    .Single(e => e.EmployId == model.EmployId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Department = model.Department;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.EmployUsers.Single(e => e.EmployId == id && e.OwnerId == _userId);

                ctx.EmployUsers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
