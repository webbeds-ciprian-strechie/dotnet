using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public interface ICourseService
    {
        Task<Course> Get(int id);
        Task<IEnumerable<Course>> GetList();
        Task<Course> Create(Course course);
        Task<int> Update(Course course);
    }
}
