using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public interface IStudentService
    {
        Task<Student> Create(Student student);
        Task<Student> Get(int id);
        Task<Student> GetByName(string name);

        Task<Student> GetByCNP(string cnp);
        Task<IEnumerable<Student>> GetList(CancellationToken cancellationToken);
        Task<int> Update(Student student);

        Task<bool> Delete(int id);
    }
}
