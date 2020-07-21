using CourseManagement.Domain.Dtos;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Infrastructure.Extensions
{
    public static class TecherExtensions
    {
        public static TeacherGetDto MapToTeacherGetDto(this Teacher teacher)
        {
            return new TeacherGetDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                HireDate = teacher.HireDate,
                CourseID = teacher.CourseID,
            };
        }

        public static void SetFromTeacherUpdateDto(this Teacher teacher, TeacherUpdateDto teacherUpdateDto, string modifiedBy)
        {
            teacher.FirstName = teacherUpdateDto.FirstName;
            teacher.LastName = teacherUpdateDto.LastName;
            teacher.HireDate = teacher.HireDate;
            teacher.CourseID = teacher.CourseID;
            teacher.ModifiedBy = modifiedBy;
        }
    }
}
