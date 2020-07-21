using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public interface ITeacherService
    {
        Task<Teacher> Get(int id);
        Task<IEnumerable<Teacher>> GetList(CancellationToken cancellationToken);
        Task<Teacher> Create(Teacher teacher);
        Task<int> Update(Teacher teacher);

        Task<bool> Delete(int id);
    }
}
