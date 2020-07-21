using CourseManagement.Domain.DataAccess;
using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;


        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher> Create(Teacher teacher)
        {
            var newChannel = await _teacherRepository.Create(teacher);

            return newChannel;
        }

        public Task<Teacher> Get(int id)
        {
            return _teacherRepository.Get(id);
        }

        public Task<Teacher> GetByName(string name)
        {
            return _teacherRepository.GetByName(name);
        }

        public Task<IEnumerable<Teacher>> GetList(CancellationToken cancellationToken)
        {
            return _teacherRepository.GetList(cancellationToken);
        }

        public Task<int> Update(Teacher teacher)
        {
            return _teacherRepository.Update(teacher);
        }
        public Task<bool> Delete(int id)
        {
            return _teacherRepository.Delete(id);
        }
    }
}
