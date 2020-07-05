using ConferencePlanner.Entities;
using ConferencePlanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferencePlanner.Data
{

    public class SessionRepository : ISessionRepository
    {
        private ApplicationDbContext context;

        public SessionRepository(ApplicationDbContext context)
        {
            this.context = context;

        }
        public Task<Session> Get(int id)
        {
            return Task.FromResult((Session)context.Sessions.Find(id));
        }

        public void Remove(int id)
        {
            Session session = context.Sessions.Find(id);
            context.Sessions.Remove((Data.Entities.Session)session);
        }

        public void Save(Session session)
        {
            Task.FromResult(context.Sessions.Add((Data.Entities.Session)session));
        }

        public List<Data.Entities.Session> GetByTitle(string title)
        {
            return context.Sessions.Where(s => s.Title == title).ToList();
        }
    }
}
