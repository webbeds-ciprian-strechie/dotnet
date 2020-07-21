using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public interface IOfficeAssignmentService
    {
        Task<OfficeAssignment> Get(int id);
        Task<IEnumerable<OfficeAssignment>> GetList();
        Task<Department> Create(OfficeAssignment officeAssignment);
        Task<int> Update(OfficeAssignment officeAssignment);
    }
}
