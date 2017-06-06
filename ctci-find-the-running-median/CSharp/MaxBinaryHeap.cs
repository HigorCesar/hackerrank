using System;
using System.Collections.Generic;
using System.Linq;

namespace ctci_find_the_running_median
{
    internal class MaxBinaryHeap
    {
        private int[] values;
        private int lastItemIndex;
        internal MaxBinaryHeap(int size)
        {
            values = new int[size+1];
            values[0] = 0;
            lastItemIndex = 0;
        }
        internal void Insert(int v)
        {
            if(lastItemIndex == values.Length -1) 
                throw new InvalidOperationException("Out of space");

            lastItemIndex++;
            values[lastItemIndex] = v;
            SiftUp(lastItemIndex);
        }
        private void SiftUp(int lastItemIndex)
        {
            //The first item is filled with 0, in fact the structure starts from 1
            if (lastItemIndex == 1) return;
            var parentIndex = lastItemIndex % 2 == 0 ? lastItemIndex / 2 : (lastItemIndex - 1) / 2;
            if (values[lastItemIndex] > values[parentIndex])
            {
                var temp = values[parentIndex];
                values[parentIndex] = values[lastItemIndex];
                values[lastItemIndex] = temp;
                SiftUp(parentIndex);
            }
        }
        private void SiftDown(int index)
        {
            if (index * 2 > lastItemIndex) return;
            var childIndex = 0;
            if(index * 2  + 1 < lastItemIndex && values[index * 2 + 1] > values[index])
                childIndex = index * 2  + 1;
            else
                childIndex = index * 2;
            
            if(values[index] < values[childIndex]){
                var temp = values[index];
                values[index] = values[childIndex];
                values[childIndex] = temp;
            }
            SiftDown(childIndex);
        }
        internal int ExtractMax()
        {
            if(lastItemIndex == 0)
                throw new InvalidOperationException();

            var maxValue = values[1];
            values[1] = values[lastItemIndex];
            lastItemIndex--;
            SiftDown(1);
            return maxValue;
        }
        internal int Peek()
        {
            if(lastItemIndex == 0)
                throw new InvalidOperationException();
            return values[1];
        }

        public override string ToString(){
            return String.Join(" ", values.Select(x=> x.ToString()));
        }
    }
}