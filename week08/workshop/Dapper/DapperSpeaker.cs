using ConferencePlanner.Data;
using ConferencePlanner.Entities;
using ConferencePlanner.Services;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperProj
{
    class DapperSpeaker : ISpeakerRepository
    {
        private SqlConnection connection;

        public DapperSpeaker(SqlConnection connection)
        {
            this.connection = connection;

        }

        public List<GroupedData> CountSessionPerSpeaker()
        {
            return this.connection.Query<GroupedData>("SELECT ss.SpeakerId,COUNT(*) AS Cnt FROM SessionSpeaker AS ss GROUP BY ss.SpeakerId;").ToList();

        }

        public Speaker Get(int id)
        {
            return this.connection.Query<Speaker>("SELECT * FROM Speakers WHERE Id = @SpeakerID;", new { SpeakerID = id }).First();
        }

        public IEnumerable<Session> GetAllSessions(int id)
        {
            return this.connection.Query<Session>("SELECT * FROM SessionSpeaker AS ss INNER JOIN Sessions AS s ON s.Id=ss.SessionId WHERE ss.SpeakerId = @SpeakerID;", new { SpeakerID = id }).ToList();
        }

        public long Save(Speaker speaker)
        {
            return this.connection.Insert(speaker);
        }

        public IEnumerable<Speaker> GetSpeakers()
        {
            return this.connection.Query<Speaker>("SELECT * FROM Speakers").ToList();
        }

        int ISpeakerRepository.CountSessionPerSpeaker()
        {
            throw new NotImplementedException();
        }

        public class GroupedData
        {
            public int SpeakerId { set; get; }
            public int Cnt { set; get; }
        }
    }
}
