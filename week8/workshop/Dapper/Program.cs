using ConferencePlanner.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DapperProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dapper!");

            var ds = new DapperSpeaker(getDbConfig());


            var speakers = ds.GetSpeakers();
            foreach (var speaker in speakers)
            {
                Console.WriteLine(speaker.FullName);
            }

            var sessionPerSpeaker = ds.CountSessionPerSpeaker();
            foreach (var speaker in sessionPerSpeaker)
            {
                Console.WriteLine("SpeakerId {0} - {1} sessions", speaker.SpeakerId, speaker.Cnt);
            }

            var speaker2 = ds.Get(2);
            Console.WriteLine(speaker2.FullName);

            var speaker3 = new Speaker();
            speaker3.FullName = "Test Speaker99";
            speaker3.Bio = "asdasd asdasd";
            ds.Save(speaker3);

            var sessions = ds.GetAllSessions(2);
            foreach (Session session in sessions)
            {
                Console.WriteLine(session.Title + "[ID:" + session.Id + "]");
            }

        }

        protected static SqlConnection getDbConfig()
        {
            return new SqlConnection(@"data source=.\SQLExpress; database=ConferencePlanner; integrated security=SSPI");
        }
    }
}
