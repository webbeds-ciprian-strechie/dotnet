using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public class OfficeAssignmentService : IOfficeAssignmentService
    {
        public Task<Department> Create(OfficeAssignment officeAssignment)
        {
            throw new NotImplementedException();
        }

        public Task<OfficeAssignment> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OfficeAssignment>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(OfficeAssignment officeAssignment)
        {
            throw new NotImplementedException();
        }
    }
}
