using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseManagement.Domain.Dtos
{
    public class ClassRoomCreateDto : IAuditable
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CourseID { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
