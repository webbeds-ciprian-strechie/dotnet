using CourseManagement.Domain.Dtos;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Infrastructure.Extensions
{
    public static class TeacherCreateDtoExtensions
    {
        public static Teacher MapToTeacher(this TeacherCreateDto teacherCreateDto, string modifiedBy)
        {
            return new Teacher
            {
                FirstName = teacherCreateDto.FirstName,
                LastName = teacherCreateDto.LastName,
                HireDate = teacherCreateDto.HireDate,
                CourseID = teacherCreateDto.CourseID,
                ModifiedBy = modifiedBy
            };
        }
    }
}
