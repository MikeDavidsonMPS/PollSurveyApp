using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingModel
{
    public class SurveyDetail
    {
       
        public int SurveyId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SurveyTitle { get; set; }

        public DepartmentsEnum Department { get; set; }
 
        public CategoriesEnum Category { get; set; }

 
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
