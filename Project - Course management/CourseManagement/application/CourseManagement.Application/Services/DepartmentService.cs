using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public class DepartmentService : IDepartmentService

    {
        public Task<Department> Create(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<Department> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
