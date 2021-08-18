using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingModel
{
    public class EmployeeEdit
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DepartmentsEnum Department { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
