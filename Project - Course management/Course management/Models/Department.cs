using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Course_management.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        //public int? TeacherID { get; set; }

    }
}