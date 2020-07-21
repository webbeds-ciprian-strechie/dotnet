using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Domain.DataAccess
{
    public interface ITeacherRepository
    {
        Task<Teacher> Create(Teacher teacher);
        Task<Teacher> Get(int id);
        Task<IEnumerable<Teacher>> GetList(CancellationToken cancellationToken);
        Task<int> Update(Teacher teacher);
        Task<Teacher> GetByName(string name);

        Task<bool> Delete(int id);
    }
}
