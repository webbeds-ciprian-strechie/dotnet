using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public interface IDepartmentService
    {
        Task<Department> Get(int id);
        Task<IEnumerable<Department>> GetList();
        Task<Department> Create(Department department);
        Task<int> Update(Department department);
    }
}
