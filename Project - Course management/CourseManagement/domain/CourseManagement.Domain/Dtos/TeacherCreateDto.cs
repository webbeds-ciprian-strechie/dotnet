using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseManagement.Domain.Dtos
{
    public class TeacherCreateDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime HireDate { get; set; }

        public int CourseID { get; set; }

        public string ModifiedBy { get; set; }
    }
}
