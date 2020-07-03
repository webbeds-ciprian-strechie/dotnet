using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Course_management.Data.Entities
{
    public class Student
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
        public int YearOfStudy { get; set; }
    }
}
