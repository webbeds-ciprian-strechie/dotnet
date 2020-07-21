using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public class CourseService : ICourseService
    {
        public Task<Course> Create(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<Course> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
