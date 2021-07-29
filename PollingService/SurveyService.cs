using PollingData;
using PollingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingService
{
    public class SurveyService
    {
        private readonly string _userId;

        public SurveyService(string userId)
        {
            _userId = userId;
        }


        public bool CreateSurvey(SurveyCreate model)
        {
            var entity =
                new Survey()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    SurveyTitle = model.SurveyTitle,
                    Department = (PollingData.DepartmentsEnum)model.Department,
                    Category = (PollingData.CategoriesEnum)model.Category,
                    CreatedUtc = DateTimeOffset.Now,
                    ModifiedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PollResults.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SurveyModel> GetSurveys()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .PollResults
                    .Where(e => e.UserId == _userId)
                    .Select(e => new SurveyModel
                    {
                        SurveyId = e.SurveyId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        SurveyTitle = e.SurveyTitle,
                        Department = (PollingModel.DepartmentsEnum)e.Department,
                        Category = (PollingModel.CategoriesEnum)e.Category,
                        CreatedUtc = e.CreatedUtc,
                        ModifiedUtc = e.ModifiedUtc
                    });

                return query.ToArray();
            }
        }

        public SurveyDetail GetSurveyById(int _userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PollResults
                    .SingleOrDefault(e => e.SurveyId == _userId);

                return new SurveyDetail
                {
                    SurveyId = entity.SurveyId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    SurveyTitle = entity.SurveyTitle,
                    Department = (PollingModel.DepartmentsEnum)entity.Department,
                    Category = (PollingModel.CategoriesEnum)entity.Category,
                    CreatedUtc= entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc

                };
            }
        }
        public bool UpdateSurvey(SurveyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PollResults
                    .SingleOrDefault(e => e.UserId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.SurveyTitle = model.SurveyTitle;
                entity.Department = (PollingData.DepartmentsEnum)model.Department;
                entity.Department = (PollingData.DepartmentsEnum)model.Category;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                
                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteSurvey(int _userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PollResults
                    .Single(e => e.SurveyId == _userId);

                ctx.PollResults.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
