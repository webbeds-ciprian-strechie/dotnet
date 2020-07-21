using CourseManagement.Domain.DataAccess;
using CourseManagement.Domain.Entities;
using System;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace CourseManagement.Infrastructure.DataAccess
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger<StudentRepository> _logger;
        public StudentRepository(IConnectionFactory connectionFactory, ILogger<StudentRepository> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        public async Task<Student> Create(Student student)
        {
            using (var conn = _connectionFactory.Create())
            {
                await conn.OpenAsync().ConfigureAwait(false);

                await conn.ExecuteAsync(Queries.Student.Insert, new
                {
                    student.FirstName,
                    student.LastName,
                    student.CNP,
                    student.EnrollmentDate
                });

                return student;
            }
        }

        public async Task<Student> Get(int id)
        {
            using (var conn = _connectionFactory.Create())
            {
                await conn.OpenAsync().ConfigureAwait(false);

                return await conn.QueryFirstOrDefaultAsync<Student>(@$"
                {Queries.Student.SelectAll}
                WHERE Id = @Id", new
                {
                    Id = id
                });
            }
        }

        public async Task<Student> GetByCNP(string cnp)
        {
            using (var conn = _connectionFactory.Create())
            {
                await conn.OpenAsync().ConfigureAwait(false);

                return await conn.QueryFirstOrDefaultAsync<Student>(@$"
                {Queries.Student.SelectAll}
                WHERE CNP = @CNP", new
                {
                    CNP = cnp
                });
            }
        }

        public async Task<Student> GetByName(string name)
        {
            using (var conn = _connectionFactory.Create())
            {
                await conn.OpenAsync().ConfigureAwait(false);

                return await conn.QueryFirstOrDefaultAsync<Student>(@$"
                {Queries.Student.SelectAll}
                WHERE FirstName = @FirstName", new
                {
                    FirstName = name
                });
            }
        }

        public async Task<IEnumerable<Student>> GetList(CancellationToken cancellationToken)
        {
            using (var conn = _connectionFactory.Create())
            {
                await conn.OpenAsync(cancellationToken).ConfigureAwait(false);

                var builder = new SqlBuilder();
                var sql = builder.AddTemplate($"{Queries.Student.SelectAll} /**where**/");


                return await conn.QueryAsync<Student>(sql.RawSql, sql.Parameters);
            }
        }

        public async Task<int> Update(Student student)
        {
            using (var conn = _connectionFactory.Create())
            {
                await conn.OpenAsync().ConfigureAwait(false);

                return await conn.ExecuteAsync(Queries.Student.Update, new
                {
                    student.FirstName,
                    student.LastName,
                    student.CNP,
                    student.EnrollmentDate,
                    student.Id 
                });
            }
        }

        public async Task<bool> Delete(int id)
        {
            using var conn = _connectionFactory.Create();
            try
            {
                await conn.OpenAsync().ConfigureAwait(false);
                await conn.ExecuteAsync($"{Queries.Student.Delete}", new
                {
                    Id = id
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete Student SQL Error: " + ex.Message);
                throw ex;
            }

            return true;
        }
    }
}
