using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_management.DataAccess.Entities
{
    public class OfficeAssignment
    {
        [Key]
        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }

        public string Location { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}