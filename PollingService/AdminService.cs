using PollingData;
using PollingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingService
{
    public class AdminService
    {
        private readonly string _userId;
        public AdminService(string userId)
        {
            _userId = userId;

        }


        public bool CreateAdmin(AdminCreate model)
        {
            var entity =
                new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Department = (PollingData.DepartmentsEnum)model.Department,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AdminModel> GetSurveys()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Where(e => e.Id == _userId)
                    .Select(e => new AdminModel
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Department = (PollingModel.DepartmentsEnum)(PollingData.DepartmentsEnum)e.Department,
                        Email = e.Email,
                        CreatedUtc = e.CreatedUtc,
                        ModifiedUtc = e.ModifiedUtc
                    });

                return query.ToArray();
            }
        }
        public AdminDetails GetUserId(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .SingleOrDefault(e => e.Id == userId);
                return
                    new AdminDetails
                    {
                        Id = entity.Id,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        Department = (PollingModel.DepartmentsEnum)entity.Department,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdatePlan(AdminEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .SingleOrDefault(e => e.Id == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.Department = (PollingData.DepartmentsEnum)model.Department;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
