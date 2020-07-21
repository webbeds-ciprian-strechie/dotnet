using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseManagement.Domain.Dtos
{
    public class OfficeAssignmentCreateDto
    {
        public int TeacherID { get; set; }

        [StringLength(50)]
        public string Location { get; set; }
    }
}
