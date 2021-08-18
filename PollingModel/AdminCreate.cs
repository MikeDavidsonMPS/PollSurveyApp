using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingModel
{
    public enum DepartmentsEnum
    {
        HumanResource = 1,
        Accounting,
        AccountsReceivable,
        ShippingReceiving
    }
    public enum CategoriesEnum
    {
        Admin = 1,
        Personal,
        Client
    }
    public class AdminCreate
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DepartmentsEnum Department { get; set; }
    }
}

