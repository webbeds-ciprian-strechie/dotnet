using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseManagement.Domain.Dtos
{
    public class EnrollmentCreateDto
    {
        public int EnrollmentID { get; set; }
        public Grade? Grade { get; set; }
    }
}
