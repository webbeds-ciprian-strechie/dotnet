using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public class ClassRoomService : IClassRoomService
    {
        public Task<ClassRoom> Create(ClassRoom classRoom)
        {
            throw new NotImplementedException();
        }

        public Task<ClassRoom> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassRoom>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ClassRoom classRoom)
        {
            throw new NotImplementedException();
        }
    }
}
