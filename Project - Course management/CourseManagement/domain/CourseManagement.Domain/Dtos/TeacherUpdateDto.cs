using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseManagement.Domain.Dtos
{
    public class TeacherUpdateDto
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
        public string CourseId { get; set; }

        [Required]
        public DateTime HireDate { get; set; }
    }
}
