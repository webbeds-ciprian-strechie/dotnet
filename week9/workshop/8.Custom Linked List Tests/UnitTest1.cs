using CustomLinkedList;
using Moq;
using System;
using Xunit;

namespace _8.Custom_Linked_List_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Test1Generic<int>();  // step 6
        }

        public void Test1Generic<T>()
        {
            T val = default(T);

            DynamicList<T> target = new DynamicList<T>(); // step 1
            for (int i = 0; i < 4; i++) // step 2
            {
                T newNode = val;
                target.Add(newNode);
            }
            int expected = 5; // step 3
            int actual;
            actual = target.Count; // step 4
            Assert.Equal(expected, actual); // step 5
        }
    }
}
