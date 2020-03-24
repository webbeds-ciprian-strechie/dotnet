using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4
{
    class RangeException<T> : Exception
    {
        private static readonly string DefaultMessage = "Invalid range";
        public T RangeStart { get; set; }
        public T RangeEnd { get; set; }

        public RangeException() : base(DefaultMessage) { }
        public RangeException(string message) : base(message) { }
        public RangeException(string message, System.Exception innerException) : base(message, innerException) { }

        public RangeException(T rangeStart, T rangeEnd) : base(DefaultMessage)
        {
            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
        }
    }
}
