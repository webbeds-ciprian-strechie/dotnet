using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_management.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public Grade? Grade { get; set; }

    }
}
