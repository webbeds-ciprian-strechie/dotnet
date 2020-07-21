using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagement.Domain.Entities
{
    public class OfficeAssignment : IAuditable
    {
        [Key]
        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }

        public string Location { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}