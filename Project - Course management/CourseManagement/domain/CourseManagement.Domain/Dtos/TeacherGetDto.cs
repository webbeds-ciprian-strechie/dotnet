using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseManagement.Domain.Dtos
{
    public class TeacherGetDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }

        public int CourseID { get; set; }

        public DateTime HireDate { get; set; }
    } 
}
