using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ex6
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong val;

        //Constructor
        public BitArray64(ulong number)
        {
            this.val = number;
        }

        // Indexer declaration
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index <= 63)
                {
                    // Check the bit at position index
                    if ((val & (1ul << index)) == 0)
                        return 0;
                    else
                        return 1;
                }
                else
                {
                    throw new IndexOutOfRangeException(
                    String.Format("Index {0} is invalid!", index));
                }
            }
            set
            {
                if (index < 0 || index > 63)
                    throw new IndexOutOfRangeException(
                       String.Format("Index {0} is invalid!", index));
                if (value < 0 || value > 1)
                    throw new ArgumentException(
                       String.Format("Value {0} is invalid!", value));

                // Clear the bit at position index
                val &= ~((ulong)(1 << index));
                // Set the bit at position index to value
                val |= (ulong)(value << index);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return this[i];
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            BitArray64 objAsBitArray64 = obj as BitArray64;

            return this.val == objAsBitArray64.val;
        }

        public override int GetHashCode()
        {
            return this.val.GetHashCode();
        }

        // Operators
        public static bool operator ==(BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return Object.Equals(bitArray1, bitArray1);
        }

        public static bool operator !=(BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return !Object.Equals(bitArray1, bitArray2);
        }
    }
}
