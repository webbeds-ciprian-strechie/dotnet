using CourseManagement.Domain.DataAccess;
using CourseManagement.Domain.Entities;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.DataAccess
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger<TeacherRepository> _logger;
        public TeacherRepository(IConnectionFactory connectionFactory, ILogger<TeacherRepository> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        public async Task<Teacher> Create(Teacher teacher)
        {
            using (var conn = _connectionFactory.Create())
            {
                await conn.OpenAsync().ConfigureAwait(false);

                await conn.ExecuteAsync(Queries.Teacher.Insert, new
                {
                    teacher.FirstName,
                    teacher.LastName,
                    teacher.CourseID,
                    teacher.HireDate
                });

                return teacher;
            }
        }

        public async Task<Teacher> Get(int id)
        {
            using (var conn = _connectionFactory.Create())
            {
                await conn.OpenAsync().ConfigureAwait(false);

                return await conn.QueryFirstOrDefaultAsync<Teacher>(@$"
                {Queries.Teacher.SelectAll}
                WHERE Id = @Id", new
                {
                    Id = id
                });
            }
        }


        public async Task<Teacher> GetByName(string name)
        {
            using (var conn = _connectionFactory.Create())
            {
                await conn.OpenAsync().ConfigureAwait(false);

                return await conn.QueryFirstOrDefaultAsync<Teacher>(@$"
                {Queries.Teacher.SelectAll}
                WHERE FirstName = @FirstName", new
                {
                    FirstName = name
                });
            }
        }

        public async Task<IEnumerable<Teacher>> GetList(CancellationToken cancellationToken)
        {
            using (var conn = _connectionFactory.Create())
            {
                await conn.OpenAsync(cancellationToken).ConfigureAwait(false);

                var builder = new SqlBuilder();
                var sql = builder.AddTemplate($"{Queries.Teacher.SelectAll} /**where**/");


                return await conn.QueryAsync<Teacher>(sql.RawSql, sql.Parameters);
            }
        }

        public async Task<int> Update(Teacher teacher)
        {
            using (var conn = _connectionFactory.Create())
            {
                await conn.OpenAsync().ConfigureAwait(false);

                return await conn.ExecuteAsync(Queries.Teacher.Update, new
                {
                    teacher.FirstName,
                    teacher.LastName,
                    teacher.CourseID,
                    teacher.HireDate,
                    teacher.Id
                });
            }
        }

        public async Task<bool> Delete(int id)
        {
            using var conn = _connectionFactory.Create();
            try
            {
                await conn.OpenAsync().ConfigureAwait(false);
                await conn.ExecuteAsync($"{Queries.Teacher.Delete}", new
                {
                    Id = id
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete Teacher SQL Error: " + ex.Message);
                throw ex;
            }

            return true;
        }
    }
}

