using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2
{
    public interface IClock
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }

        BusinessDate Today { get; }
    }
}
