using CourseManagement.Domain.Dtos;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Infrastructure.Extensions
{
    public static class StudentCreateDtoExtensions
    {
        public static Student MapToStudent(this StudentCreateDto studentCreateDto, string modifiedBy)
        {
            return new Student
            {
                FirstName = studentCreateDto.FirstName,
                CNP = studentCreateDto.CNP,
                EnrollmentDate = studentCreateDto.EnrollmentDate,
                ModifiedBy = modifiedBy
            };
        }
    }
}
