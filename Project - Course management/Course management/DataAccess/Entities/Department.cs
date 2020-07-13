using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Course_management.DataAccess.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        public int? TeacherID { get; set; }

        public virtual Teacher Administrator { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}