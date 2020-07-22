using CourseManagement.Domain.Dtos;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Infrastructure.Extensions
{
    public static class EnrollmentExtensions
    {

        public static EnrollmentCreateDto MapToEnrollmentGetDto(this Enrollment ernrollment)
        {
            return new EnrollmentCreateDto
            {
                Id = ernrollment.Id,
                StudentID = ernrollment.StudentID,
                Grade = ernrollment.Grade,
            };
        }

        public static Enrollment MapAsNewEntity(this EnrollmentCreateDto model)
        {
            return new Enrollment
            {
                Id = model.Id,
                StudentID = model.StudentID,
                Grade = model.Grade
            };
        }
    }
}
