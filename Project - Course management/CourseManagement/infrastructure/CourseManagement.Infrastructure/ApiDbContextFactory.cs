using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CourseManagement.Infrastructure
{
    public class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            // todo, this should be as configuration
            var connectionString = "Server=.\\SQLEXPRESS;Initial Catalog=CourseManagement;Integrated Security=True";

            var builder = new DbContextOptionsBuilder<ApiDbContext>();

            builder.UseSqlServer(connectionString);

            return new ApiDbContext(builder.Options);
        }
    }
}
