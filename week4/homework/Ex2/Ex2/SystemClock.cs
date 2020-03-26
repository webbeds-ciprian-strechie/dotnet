using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2
{
    public class SystemClock : IClock
    {

        public DateTime Now { get => DateTime.Now; }

        public DateTime UtcNow { get => DateTime.UtcNow; }

        public BusinessDate Today { get => new BusinessDate(Now.Year, Now.Month, Now.Day); }
    }
}
