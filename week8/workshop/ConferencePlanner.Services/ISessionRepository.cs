namespace ConferencePlanner.Services
{
    using System.Threading.Tasks;
    using Entities;

    public interface ISessionRepository
    {
        Task<Session> Get(int id);

        void Save(Session session);

        void Remove(int id);
    }
}
