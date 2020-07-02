using ConferencePlanner.Data;
using ConferencePlanner.Entities;
using ConferencePlanner.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DapperProj
{
    class DapperSpeaker : ISpeakerRepository
    {
        private ApplicationDbContext context;

        public DapperSpeaker(ApplicationDbContext context)
        {
            this.context = context;

        }

        public int CountSessionPerSpeaker()
        {
            throw new NotImplementedException();
            
        }

        public Speaker Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Session> GetAllSessions(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Speaker speaker)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Speaker> GetSpeakers()
        {
            return context.Query<Speaker>("SELECT * FROM Speakers").ToList();
        }
    }
}
