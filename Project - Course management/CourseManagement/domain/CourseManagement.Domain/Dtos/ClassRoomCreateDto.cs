using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseManagement.Domain.Dtos
{
    public class ClassRoomCreateDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LasttName { get; set; }

        [Required]
        [StringLength(13)]
        public DateTime CNP { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }
    }
}
