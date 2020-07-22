using CourseManagement.Domain.Dtos;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Infrastructure.Extensions
{
    public static class ClassRoomExtensions
    {
        public static ClassRoomCreateDto MapToClassRoomCreateDto(this ClassRoom classRoom)
        {
            return new ClassRoomCreateDto
            {
                Id = classRoom.Id,
                Name = classRoom.Name,
                CourseID = classRoom.CourseID
            };
        }

        public static ClassRoom MapAsNewEntity(this ClassRoomCreateDto classRoom)
        {
            return new ClassRoom
            {
                Id = classRoom.Id,
                Name = classRoom.Name,
                CourseID = classRoom.CourseID
            };
        }
    }
}
