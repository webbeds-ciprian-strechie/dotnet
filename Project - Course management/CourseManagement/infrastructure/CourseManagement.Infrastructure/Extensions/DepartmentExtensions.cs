using CourseManagement.Domain.Dtos;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Infrastructure.Extensions
{
    public static class DepartmentExtensions
    {
        public static DepartmentCreateDto MapToDepartmentGetDto(this Department department)
        {
            return new DepartmentCreateDto
            {
                DepartmentID = department.Id,
                Name = department.Name,
                Budget = department.Budget
            };
        }

        public static Department MapAsNewEntity(this DepartmentCreateDto department)
        {
            return new Department
            {
                Id = department.DepartmentID,
                Name = department.Name,
                Budget = department.Budget
            };
        }
    }
}
