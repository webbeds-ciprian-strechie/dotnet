using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Course_management.DataAccess.Entities
{
    public class ClassRoom
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CourseID { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
