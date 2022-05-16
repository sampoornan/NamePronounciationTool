using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NamePronunciation.Entities
{
    [Table("tblEmployee")]
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public string AudioPath { get; set; }

    }
}
