using System;
using System.Collections.Generic;
using System.Text;
using CourseManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Infrastructure
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ClassRoom> ClassRooms { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Carson",
                    LastName = "Alexander",
                    CNP = "111111111111111",
                    EnrollmentDate = DateTime.Parse("2018-09-01")
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Meredith",
                    LastName = "Alonso",
                    CNP = "111111111111112",
                    EnrollmentDate = DateTime.Parse("2017-09-01")
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Arturo",
                    LastName = "Anand",
                    CNP = "111111111111113",
                    EnrollmentDate = DateTime.Parse("2019-09-01")
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Gytis",
                    LastName = "Barzdukas",
                    CNP = "111111111111114",
                    EnrollmentDate = DateTime.Parse("2019-09-01")
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Yan",
                    LastName = "Li",
                    CNP = "111111111111115",
                    EnrollmentDate = DateTime.Parse("2019-09-01")
                },
                new Student
                {
                    Id = 6,
                    FirstName = "Peggy",
                    LastName = "Justice",
                    CNP = "111111111111116",
                    EnrollmentDate = DateTime.Parse("2018-09-01")
                },
                new Student
                {
                    Id = 7,
                    FirstName = "Laura",
                    LastName = "Norman",
                    CNP = "111111111111117",
                    EnrollmentDate = DateTime.Parse("2016-09-01")
                },
                new Student
                {
                    Id = 8,
                    FirstName = "Nino",
                    LastName = "Olivetto",
                    CNP = "111111111111118",
                    EnrollmentDate = DateTime.Parse("2019-09-01")
                });


            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Title = "Chemistry",
                    Credits = 3,
                    DepartmentID = 3,
                },
                new Course
                {
                    Id = 2,
                    Title = "Microeconomics",
                    Credits = 3,
                    DepartmentID = 4
                },
                new Course
                {
                    Id = 3,
                    Title = "Macroeconomics",
                    Credits = 3,
                    DepartmentID = 4
                },
                new Course
                {
                    Id = 4,
                    Title = "Calculus",
                    Credits = 4,
                    DepartmentID = 2
                },
                new Course
                {
                    Id = 5,
                    Title = "Trigonometry",
                    Credits = 4,
                    DepartmentID = 2
                },
                new Course
                {
                    Id = 6,
                    Title = "Composition",
                    Credits = 3,
                    DepartmentID = 1
                },
                new Course
                {
                    Id = 7,
                    Title = "Music",
                    Credits = 4,
                    DepartmentID = 1
                },
                new Course
                {
                    Id = 8,
                    Title = "Literature",
                    Credits = 4,
                    DepartmentID = 1
                });

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    FirstName = "Kim",
                    LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11"),
                    CourseID = 2
                },
                new Teacher
                {
                    Id = 2,
                    FirstName = "Fadi",
                    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06"),
                    CourseID = 3
                },
                new Teacher
                {
                    Id = 3,
                    FirstName = "Roger",
                    LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01"),
                    CourseID = 4
                },
                new Teacher
                {
                    Id = 4,
                    FirstName = "Candace",
                    LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15"),
                    CourseID = 5
                }
                ,
                new Teacher
                {
                    Id = 5,
                    FirstName = "Fakhouri",
                    LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12"),
                    CourseID = 6
                }
                ,
                new Teacher
                {
                    Id = 6,
                    FirstName = "Roger",
                    LastName = "Kim",
                    HireDate = DateTime.Parse("2004-02-12"),
                    CourseID = 7
                },
                new Teacher
                {
                    Id = 7,
                    FirstName = "Abercrombie",
                    LastName = "Nino",
                    HireDate = DateTime.Parse("2004-02-12"),
                    CourseID = 8
                });

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "English",
                    Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01")
                },
                new Department
                {
                    Id = 2,
                    Name = "Mathematics",
                    Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01")
                },
                new Department
                {
                    Id = 3,
                    Name = "Engineering",
                    Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01")
                },
                new Department
                {
                    Id = 4,
                    Name = "Economics",
                    Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01")
                });



            modelBuilder.Entity<OfficeAssignment>().HasData(
                new OfficeAssignment
                {
                    TeacherID = 1,
                    Location = "Smith 17"
                },
                new OfficeAssignment
                {
                    TeacherID = 2,
                    Location = "Gowan 27"
                },
                new OfficeAssignment
                {
                    TeacherID = 3,
                    Location = "Thompson 304"
                });

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    Id = 1,
                    StudentID = 1,
                    CourseID = 1,
                    Grade = Grade.A
                },
                 new Enrollment
                 {
                     Id = 2,
                     StudentID = 1,
                     CourseID = 2,
                     Grade = Grade.C
                 },
                 new Enrollment
                 {
                     Id = 3,
                     StudentID = 1,
                     CourseID = 2,
                     Grade = Grade.B
                 },
                 new Enrollment
                 {
                     Id = 4,
                     StudentID = 2,
                     CourseID = 3,
                     Grade = Grade.B
                 },
                 new Enrollment
                 {
                     Id = 5,
                     StudentID = 2,
                     CourseID = 2,
                     Grade = Grade.B
                 },
                 new Enrollment
                 {
                     Id = 6,
                     StudentID = 2,
                     CourseID = 4,
                     Grade = Grade.B
                 },
                 new Enrollment
                 {
                     Id = 7,
                     StudentID = 3,
                     CourseID = 2
                 },
                 new Enrollment
                 {
                     Id = 8,
                     StudentID = 3,
                     CourseID = 4,
                     Grade = Grade.B
                 },
                new Enrollment
                {
                    Id = 9,
                    StudentID = 4,
                    CourseID = 2,
                    Grade = Grade.B
                },
                 new Enrollment
                 {
                     Id = 10,
                     StudentID = 5,
                     CourseID = 3,
                     Grade = Grade.B
                 },
                 new Enrollment
                 {
                     Id = 11,
                     StudentID = 6,
                     CourseID = 1,
                     Grade = Grade.B
                 });
        }
    }
}
