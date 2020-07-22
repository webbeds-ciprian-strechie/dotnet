using CourseManagement.Domain.Dtos;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Infrastructure.Extensions
{
    public static class CourseExtensions
    {
        public static CourseCreateDto MapToCourseGetDto(this Course course)
        {
            return new CourseCreateDto
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits,
                DepartmentID = course.DepartmentID,
            };
        }

        public static Course MapAsNewEntity(this CourseCreateDto course)
        {
            return new Course
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits,
                DepartmentID = course.DepartmentID,
            };
        }
    }
}
