using CustomLinkedList;
using Moq;
using System;
using Xunit;

namespace _8.Custom_Linked_List_Tests
{
    public class UnitTest1
    {

        DynamicList<int> target;

        const int NR_ELEMENTS = 5;
        public UnitTest1()
        {
            target = new DynamicList<int>();
            for (int i = 0; i < NR_ELEMENTS; i++)
            {
                target.Add(i);
            }
        }

        [Fact]
        public void TestIndexOf()
        {
            var firstElement = 0;
            Assert.Equal(firstElement, target.IndexOf(0));
        }

        [Fact]
        public void TestAddOperation()
        {
            target.Add(99);
            Assert.Equal(NR_ELEMENTS + 1, target.Count);
        }

        [Fact]
        public void TestRemoveOperation()
        {

            target.Remove(0);

            Assert.Equal(NR_ELEMENTS - 1, target.Count);

            Assert.Equal(-1, target.IndexOf(0));
        }

        [Fact]
        public void TestRemoveAtOperation()
        {
            target.RemoveAt(0);
            Assert.Equal(NR_ELEMENTS - 1, target.Count);

            Assert.Equal(-1, target.IndexOf(0));
        }

        [Fact]
        public void TestContains()
        {
            var newElement = 99;
            var elementNotContained = -99;
            target.Add(newElement);
            Assert.True(target.Contains(newElement));
            Assert.False(target.Contains(elementNotContained));
        }

        [Fact]
        public void TestIndex()
        {
            Assert.Equal(0, target[0]);
        }
    }
}
