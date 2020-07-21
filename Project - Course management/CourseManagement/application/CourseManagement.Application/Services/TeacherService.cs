using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public class TeacherService : ITeacherService
    {
        public Task<Department> Create(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Teacher>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
