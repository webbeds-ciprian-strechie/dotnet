using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseManagement.Domain.Dtos
{
    public class StudentGetDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ModifiedBy { get; set; }
    } 
}
