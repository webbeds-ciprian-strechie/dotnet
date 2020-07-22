using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseManagement.Domain.Dtos
{
    public class OfficeAssignmentCreateDto : IAuditable
    {
        public int TeacherID { get; set; }

        [StringLength(50)]
        public string Location { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
