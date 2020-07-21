using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseManagement.Domain.Dtos
{
    public class StudentCreateDto
    {
        [Required]
        [StringLength(100)]
        [RegularExpression("^[A-Za-z0-9- ]+$")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression("^[A-Za-z0-9- ]+$")]
        public string LastName { get; set; }

        [Required]
        [StringLength(13)]
        public string CNP { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }
    }
}
