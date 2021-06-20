using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingData
{
    public class Survey
    {
        [Key]
        public int DataId { get; set; }
    }
}
