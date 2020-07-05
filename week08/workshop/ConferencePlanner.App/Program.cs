namespace ConferencePlanner.App
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using ConferencePlanner.Data.Entities;
    using Data;
    using Microsoft.EntityFrameworkCore;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var context = new ApplicationDbContext();

            //Ex01.Run(context);
            // Ex03.Run(context);
            //Ex06.Run(context);
            Ex07.Run(context);
        }
    }

    internal class Ex01
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // write a simple query to validate ApplicationDbContext

            var atandee = context.Attendees.Add(new Attendee
            {

                FirstName = "Attendee13",
                LastName = "dadas",
                UserName = "user13",
                EmailAddress = "asdqwe@mail.com",
                DateOfBirth = new DateTime(1985, 12, 24)
            });
            context.SaveChanges();
            context.Tracks.Add(new Track { Name = "Track13" });

            context.SaveChanges();
        }
    }

    internal class Ex02
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // on Tracks table, add PHP, C# tracks with a seed
            // update ApplicationDbContext to run a seed
        }
    }

    internal class Ex03
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // on Attendee model, add a new property, date of birth
            // add a migration, run the migration
            // insert then read a Attendee

            var atandee = context.Attendees.Add(new Attendee
            {

                FirstName = "Attendee24",
                LastName = "Test",
                UserName = "User24",
                EmailAddress = "asdqwede@mail.com",
                DateOfBirth = new DateTime(1990, 12, 12)
            });
            context.SaveChanges();

            var atandeeFromDb = context.Attendees
                    .Where(b => b.UserName == "User24")
                    .First();

            Console.WriteLine(atandeeFromDb.Id);
        }
    }

    internal class Ex04
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // have a look on ConferencePlanner.Services and ISessionRepository
            // implement the repository inside the Data project
            // use the repository here in order to read 

            SessionRepository sr = new SessionRepository(context);
            sr.Save(new Entities.Session { Title = "PHP Conf", TrackId = 13 });

        }
    }

    internal class Ex05
    {
        // todo
        // rename the Speaker.Name to Speaker.FullName
        // you should add a migration
    }

    internal class Ex06
    {
        public static void Run(ApplicationDbContext context)
        {
            // todo
            // all Sessions that title contains ".NET"
            SessionRepository sr = new SessionRepository(context);
            var sessions = sr.GetByTitle(".NET");
            foreach (Session session in sessions)
            {
                Console.WriteLine(session.Title + "[ID:" + session.Id + "]");
            }

            // number of sessions for each speaker
            var query = context.SessionSpeaker.GroupBy(s => s.SpeakerId)
                               .Select(e => new { e.Key, Count = e.Count() })
                               .ToDictionary(e => e.Key, e => e.Count);
            foreach (var sessionSpeaker in query)
            {
                Console.WriteLine("Speaker {0} = {1} sessions", sessionSpeaker.Key, sessionSpeaker.Value);
            }

            // number of tracks per session
            var query2 = context.Sessions.GroupBy(s => s.TrackId)
                   .Select(e => new { e.Key, Count = e.Count() })
                   .ToDictionary(e => e.Key, e => e.Count);
            foreach (var sessionSpeaker in query2)
            {
                Console.WriteLine("Session {0} = {1} tracks", sessionSpeaker.Key, sessionSpeaker.Value);
            }

            // all tracks for each session
            DbSet<Session> sessions2 = context.Sessions;
            DbSet<Track> traks = context.Tracks;

            var query3 =
                sessions2.Join(
                    traks,
                    session => session.TrackId,
                    track => track.Id,
                    (session, track) => new
                    {
                        SessionID = session.Id,
                        TrackName = track.Name,
                    });

            foreach (var sessionTraks in query3)
            {
                Console.WriteLine("SessionID: {0}  TrackName: {1} ", sessionTraks.SessionID, sessionTraks.TrackName);
            }
        }
    }

    internal class Ex07
    {
        public static void Run(ApplicationDbContext context)
        {
            // todo
            // get all sessions for one speaker
            var speakerId = 2;

            var query2 = context.SessionSpeaker
                .Where(s => s.SpeakerId == speakerId)
                .Include(s => s.Session);

            foreach (var sessionSpeaker in query2)
            {
                Console.WriteLine(sessionSpeaker.Session.Title);
            }
        }
    }

    internal class Ex08
    {
        public static void Run()
        {
            // todo
            // create a separate project for dapper
            // implement the ISpeakerRepository using dapper
        }
    }

    internal class Ex09
    {
        public static void Run()
        {
            // todo
            // create view
            /*
               create view AllSessionsAndSpeakersView as
               select ses.Title, sp.Name, ses.StartTime from Sessions ses
               join SessionSpeaker ss on ses.Id = ss.SessionId
               join Speakers sp on sp.Id = ss.SpeakerId
            */

            // use the view from Dapper
            // display all information at console
        }
    }

    internal class Ex10
    {
        public static void Run()
        {
            // todo
            // use Dapper Plus
            // bulk insert 10 attendees
        }
    }
}
