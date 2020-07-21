using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Infrastructure.DataAccess
{
    class Queries
    {
        public static class Student
        {
            public const string Insert = @"
                INSERT INTO Students
                (
                    FirstName,
                    LastName,
                    CNP,
                    EnrollmentDate
                )
                VALUES
                (
                    @FirstName,
                    @LastName,
                    @CNP,
                    @EnrollmentDate
                );";

            public const string SelectAll = @"
                SELECT
                    Id,
                    FirstName, 
                    LastName, 
                    CNP, 
                    EnrollmentDate
                FROM Students";

            public const string Update = @"
                UPDATE Students
                SET
                    FirstName = @FirstName,
                    LastName = @LastName,
                    CNP = @CNP,
                    EnrollmentDate = @EnrollmentDate
                WHERE Id = @Id;";

            public const string Delete = @"DELETE FROM Students WHERE Id = @Id";

        }

        public static class Teacher
        {
            public const string Insert = @"
                INSERT INTO Teachers
                (
                    FirstName,
                    LastName,
                    CourseId,
                    HireDate
                )
                VALUES
                (
                    @FirstName,
                    @LastName,
                    @CourseId,
                    @HireDate
                );";

            public const string SelectAll = @"
                SELECT
                    Id,
                    FirstName, 
                    LastName, 
                    CourseId, 
                    HireDate
                FROM Teachers";

            public const string Update = @"
                UPDATE Teachers
                SET
                    FirstName = @FirstName,
                    LastName = @LastName,
                    CourseId = @CourseId,
                    HireDate = @HireDate
                WHERE Id = @Id;";

            public const string Delete = @"DELETE FROM Teachers WHERE Id = @Id";

        }
    }
}
