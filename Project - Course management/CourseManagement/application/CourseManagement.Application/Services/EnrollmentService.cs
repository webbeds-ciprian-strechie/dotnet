using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        public Task<Department> Create(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }

        public Task<Enrollment> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Enrollment>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }
    }
}
