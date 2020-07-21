using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public interface IEnrollmentService
    {

        Task<Enrollment> Get(int id);
        Task<IEnumerable<Enrollment>> GetList();
        Task<Department> Create(Enrollment enrollment);
        Task<int> Update(Enrollment enrollment);
    }
}
