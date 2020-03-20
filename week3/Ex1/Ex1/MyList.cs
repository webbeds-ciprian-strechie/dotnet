using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ex1
{
    class MyList<T> : ICollection, IEnumerable,  IStructuralComparable, IStructuralEquatable, ICloneable
    {
        private T[] data;

        public int Count => ((ICollection)data).Count;

        public bool IsSynchronized => data.IsSynchronized;

        public object SyncRoot => data.SyncRoot;

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MyList(int dimension)
        {
            this.data = new T[dimension];
        }

        public void Add(T elem)
        {
            data[data.Length] = elem;
        }

        public void Remove(T value)
        {
            T[] tmp = new T[data.Length - 1];
            for (var i = 0; i < data.Length; i++)
            {
                if (data[i].Equals(value))
                {
                    continue;
                }
                tmp[tmp.Length] = data[i];
            }

            data = tmp;
        }

        public T Find(T elem)
        {
            return Array.Find(this.data, (el) => el.Equals(elem));
        }

        public void Clear()
        {
            Array.Clear(data, 0, data.Length - 1);
        }

        public bool Contains(T value)
        {
            return Array.Exists(data, (el) => el.Equals(value));
        }

        public int IndexOf(T value)
        {
            return Array.IndexOf(data, value);
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > data.Length + 1)
            {
                throw new ArgumentOutOfRangeException("Invalid index!");
            }

            T[] tmp = new T[data.Length + 1];

            for (var i = 0; i < data.Length; i++)
            {
                if (i == index)
                {
                    tmp[tmp.Length] = value;
                    tmp[tmp.Length] = data[i];
                }
                else
                {
                    tmp[tmp.Length] = data[i];
                }
               
            }

            data = tmp;
        }


        public void RemoveAt(int index)
        {
            if (index < 0 || index >= data.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid index!");
            }

            T[] tmp = new T[data.Length - 1];
            for (var i = 0; i < data.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }
                tmp[tmp.Length] = data[i];
            }

            data = tmp;
        }


        public void CopyTo(Array array, int index)
        {
            data.CopyTo(array, index);
        }



        /*
         * Implementations
         */

        public IEnumerator GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public object Clone()
        {
            return data.Clone();
        }

        public bool Equals(object other, IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)data).Equals(other, comparer);
        }

        public int GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)data).GetHashCode(comparer);
        }

        public int CompareTo(object other, IComparer comparer)
        {
            return ((IStructuralComparable)data).CompareTo(other, comparer);
        }
    }
}
