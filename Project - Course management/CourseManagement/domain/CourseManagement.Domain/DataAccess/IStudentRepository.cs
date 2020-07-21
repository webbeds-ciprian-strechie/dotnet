using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Domain.DataAccess
{
    public interface IStudentRepository
    {
        Task<Student> Create(Student student);
        Task<Student> Get(int id);
        Task<IEnumerable<Student>> GetList(CancellationToken cancellationToken);
        Task<int> Update(Student student);
        Task<Student> GetByName(string name);
        Task<Student> GetByCNP(string cnp);
        Task<bool> Delete(int id);
    }
}
