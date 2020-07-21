using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public interface ITeacherService
    {
        Task<Teacher> Get(int id);
        Task<IEnumerable<Teacher>> GetList();
        Task<Department> Create(Teacher teacher);
        Task<int> Update(Teacher teacher);
    }
}
