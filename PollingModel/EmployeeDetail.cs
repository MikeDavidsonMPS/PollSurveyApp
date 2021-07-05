using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingModel
{
    public class EmployeeDetail
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DepartmentsEnum Department { get; set; }
        [EmailAddress]
        public string Email { get; set; }

   
        public DateTimeOffset? CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
