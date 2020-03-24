using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IEnumerableExt
{
    internal static class MyIEnumerableExt
    {
        public static T Sum<T>(this IEnumerable<T> items)
        {
            dynamic sum = 0;
            foreach (dynamic item in items)
            {
                sum += item; ;
            }
            return sum;
        }

        public static T Prod<T>(this IEnumerable<T> items)
        {
            dynamic prod = 1;
            foreach (dynamic item in items)
            {
                prod *= item; ;
            }
            return prod;
        }

        public static T Min<T>(this IEnumerable<T> items) where T : System.IComparable
        {
            dynamic? min = null; ;
            foreach (dynamic item in items)
            {
                if (min == null)
                {
                    min = item;
                }
                else if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> items) where T : System.IComparable
        {
            dynamic? max = null; ;
            foreach (dynamic item in items)
            {
                if (max == null)
                {
                    max = item;
                }
                else if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }


        public static T Avg<T>(this IEnumerable<T> items) where T : System.IComparable
        {
            dynamic sum = 0;
            int cnt = 0;
            foreach (dynamic item in items)
            {
                sum += item;
                cnt++;
            }
            return sum / cnt;
        }
    }
}
