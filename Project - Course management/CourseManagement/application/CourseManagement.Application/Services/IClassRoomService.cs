using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Application.Services
{
    public interface IClassRoomService
    {
        Task<ClassRoom> Get(int id);
        Task<IEnumerable<ClassRoom>> GetList();
        Task<ClassRoom> Create(ClassRoom classRoom);
        Task<int> Update(ClassRoom classRoom);
    }
}
