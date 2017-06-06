using System;
using System.Collections.Generic;
using System.Linq;

namespace ctci_find_the_running_median
{
    internal class MinBinaryHeap
    {
        private int[] values;
        private int lastItemIndex;
        public MinBinaryHeap(int size)
        {
            values = new int[size + 1];
            values[0] = 0;
            lastItemIndex = 0;
        }

        internal void Insert(int value)
        {
            lastItemIndex++;
            values[lastItemIndex] = value;
            SiftUp(lastItemIndex);
        }
         internal void SiftUp(int currentIndex)
        {
            if (currentIndex == 1) return;
            var parentIndex = currentIndex % 2 == 0 ? currentIndex / 2 : (currentIndex - 1) / 2;
            if (values[currentIndex] < values[parentIndex])
            {
                var temp = values[parentIndex];
                values[parentIndex] = values[currentIndex];
                values[currentIndex] = temp;
                SiftUp(parentIndex);
            }
        }
        internal void SiftDownx(int currentIndex)
        {
            if(currentIndex * 2 >= lastItemIndex) return;
            var childIndex = 0;
            if(values[currentIndex] > values[currentIndex * 2 +1])
                childIndex = currentIndex *2 + 1;
            else
                childIndex = currentIndex * 2;
            if(values[currentIndex] > values[childIndex]){
                var temp = values[currentIndex];
                values[currentIndex] = values[childIndex];
                values[childIndex] = temp;
                
            }
            SiftDown(childIndex);
        }
        internal void SiftDown(int currentIndex)
        {
            if(currentIndex * 2 > lastItemIndex) return;
            var childIndex = 0;
            if(values[currentIndex] > values[currentIndex * 2])
                childIndex = currentIndex * 2;
            else
                childIndex = currentIndex * 2 +1;
            if(values[currentIndex] > values[childIndex]){
                var temp = values[currentIndex];
                values[currentIndex] = values[childIndex];
                values[childIndex] = temp;
                SiftDown(childIndex);
            }
                
        }
        internal int ExtractMin()
        {
            var minValue = values[1];
            values[1] = values[lastItemIndex];
            lastItemIndex-=1;
            SiftDown(1);
            return minValue;
        }


        public override string ToString()
        {
            return String.Join(" ", values.Skip(1).Take(lastItemIndex).Select(x => x.ToString()));
        }
        internal int Peek()
        {
            return values[1];
        }
    }
}