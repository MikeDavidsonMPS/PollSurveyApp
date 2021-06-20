using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingData
{
    public class Employee
    {
        [Key]
        public int EmployId { get; set; }
    }
}
