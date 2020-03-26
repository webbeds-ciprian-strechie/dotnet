using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Ex2
{
    public struct BusinessDate : IFormattable, IEquatable<BusinessDate>, IComparable<BusinessDate>, IXmlSerializable
    {

        private class BusinessDateFormatStringBuilder
        {
            private readonly StringBuilder builder;
            public BusinessDateFormatStringBuilder(string format)
            {
                builder = new StringBuilder(format);
            }
            public BusinessDateFormatStringBuilder EscapeFormatSpecifier(string formatSpecifier)
            {
                builder.Replace(formatSpecifier, "\\" + formatSpecifier);
                return this;
            }
            public override string ToString()
            {
                return builder.ToString();
            }
        }

        private DateTime internalDateTime;

        private const string Iso8601DateFormat = "yyyy-MM-dd";
        private const string Iso8601DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

        public int Day { get => internalDateTime.Day; }
        public int Month { get => internalDateTime.Month; }
        public int Year { get => internalDateTime.Year; }

        public BusinessDate(int y, int m, int d)
        {
            this.internalDateTime = new DateTime(y, m, d);
        }


        public static BusinessDate ParseFromIso8601String(string str)
        {
            DateTime d = DateTime.ParseExact(str, Iso8601DateFormat, CultureInfo.InvariantCulture);

            return new BusinessDate(d.Year, d.Month, d.Day);
        }
        public int CompareTo([AllowNull] BusinessDate other)
        {
            string currentStr = String.Join('-', this.Year, this.Month, this.Day);
            string otherStr = String.Join('-', other.Year, other.Month, other.Day);
            return String.Compare(currentStr, otherStr);
        }

        public bool Equals([AllowNull] BusinessDate other)
        {
            if (this.Day == other.Day && this.Month == other.Month && this.Year == other.Year)
            {
                return true;
            }

            return false;
        }



        public override string ToString()
        {
            return String.Join('-', this.Year, this.Month, this.Day);
        }

        public string ToString(string format)
        {
            return internalDateTime.ToString(format);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            var escapedFormat = EscapeTimeFormatSpecifiers(format == null ? Iso8601DateFormat : format);
            return internalDateTime.ToString(escapedFormat, formatProvider);
        }

        private static string EscapeTimeFormatSpecifiers(string format)
        {
            return new BusinessDateFormatStringBuilder(format).EscapeFormatSpecifier("h")
                .EscapeFormatSpecifier("H")
                .EscapeFormatSpecifier("m")
                .EscapeFormatSpecifier("s")
                .EscapeFormatSpecifier("f")
                .EscapeFormatSpecifier("z")
                .EscapeFormatSpecifier("F")
                .EscapeFormatSpecifier("t")
                .EscapeFormatSpecifier("K")
                .ToString();
        }

        public static bool operator ==(BusinessDate obj1, BusinessDate obj2)
        {

            return obj1.Equals(obj2);
        }

        public static bool operator !=(BusinessDate obj1, BusinessDate obj2)
        {

            return !obj1.Equals(obj2);
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }


}
