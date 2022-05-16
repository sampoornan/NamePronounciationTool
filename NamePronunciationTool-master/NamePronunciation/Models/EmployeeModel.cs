using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamePronunciation.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string AudioPath { get; set; }
    }
}
