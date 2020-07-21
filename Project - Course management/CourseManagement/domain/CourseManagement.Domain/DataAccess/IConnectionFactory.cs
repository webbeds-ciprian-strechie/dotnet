using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace CourseManagement.Domain.DataAccess
{
    public interface IConnectionFactory
    {
        public DbConnection Create();
    }
}
