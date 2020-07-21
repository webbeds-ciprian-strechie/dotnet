using CourseManagement.Domain.DataAccess;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;


        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Create(Student student)
        {
            var newChannel = await _studentRepository.Create(student);

            return newChannel;
        }

        public Task<Student> Get(int id)
        {
            return _studentRepository.Get(id);
        }

        public Task<Student> GetByCNP(string cnp)
        {
            return _studentRepository.GetByCNP(cnp);
        }

        public Task<Student> GetByName(string name)
        {
            return _studentRepository.GetByName(name);
        }

        public Task<IEnumerable<Student>> GetList(CancellationToken cancellationToken)
        {
            return _studentRepository.GetList(cancellationToken);
        }

        public Task<int> Update(Student student)
        {
            return _studentRepository.Update(student);
        }
        public Task<bool> Delete(int id)
        {
            return _studentRepository.Delete(id);
        }
    }
}
