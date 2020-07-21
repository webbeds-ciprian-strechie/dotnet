using CourseManagement.Domain.Dtos;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Infrastructure.Extensions
{
    public static class StudentExtensions
    {
        public static StudentGetDto MapToStudentGetDto(this Student student)
        {
            return new StudentGetDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate
            };
        }

        public static void SetFromStudentUpdateDto(this Student student, StudentUpdateDto studentUpdateDto, string modifiedBy)
        {
            student.FirstName = studentUpdateDto.FirstName;
            student.LastName = studentUpdateDto.LastName;
            student.EnrollmentDate = studentUpdateDto.EnrollmentDate;
            student.ModifiedBy = modifiedBy;
        }
    }
}
