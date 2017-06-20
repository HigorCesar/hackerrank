using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ctci_find_the_running_median
{
    internal class MaxBinaryHeap
    {
        private int[] values;
        private int lastItemIndex;
        internal MaxBinaryHeap(int size)
        {
            values = new int[size + 1];
            values[0] = 0;
            lastItemIndex = 0;
        }
        internal void Insert(int v)
        {
            if (lastItemIndex == values.Length - 1)
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
            var maxChild = MaxChild(index);
            if (values[index] < values[maxChild])
            {
                var temp = values[index];
                values[index] = values[maxChild];
                values[maxChild] = temp;
            }
            SiftDown(maxChild);
        }
        private int MaxChild(int index)
        {
            if (index * 2 + 1 > Size())
                return index * 2;
            else if (values[index * 2] > values[index * 2 + 1])
                return index * 2;
            else
                return index * 2 + 1;
        }
        internal int ExtractMax()
        {
            if (lastItemIndex == 0)
                throw new InvalidOperationException();

            var maxValue = values[1];
            values[1] = values[lastItemIndex];
            lastItemIndex--;
            SiftDown(1);
            return maxValue;
        }
        internal int Peek()
        {
            if (lastItemIndex == 0)
                throw new InvalidOperationException();
            return values[1];
        }

        public override string ToString()
        {
            return String.Join(" ", values.Select(x => x.ToString()));
        }
        public int Size() => lastItemIndex;
    }
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
            if (lastItemIndex == values.Length - 1)
                throw new InvalidOperationException("Out of space");

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
        private void SiftDown(int index)
        {
            if (index * 2 > lastItemIndex) return;
            var minChild = MinChild(index);
            if (values[index] > values[minChild])
            {
                var temp = values[index];
                values[index] = values[minChild];
                values[minChild] = temp;
            }
            SiftDown(minChild);
        }
        private int MinChild(int index)
        {
            if (index * 2 + 1 > Size())
                return index * 2;
            else if (values[index * 2] < values[index * 2 + 1])
                return index * 2;
            else
                return index * 2 + 1;
        }
        internal int ExtractMin()
        {
            if (lastItemIndex == 0)
                throw new InvalidOperationException();

            var minValue = values[1];
            values[1] = values[lastItemIndex];
            lastItemIndex--;
            SiftDown(1);
            return minValue;
        }

        public override string ToString()
        {
            return String.Join(" ", values.Skip(1).Take(lastItemIndex).Select(x => x.ToString()));
        }
        internal int Peek()
        {
            if (lastItemIndex == 0)
                throw new InvalidOperationException();
            return values[1];
        }
        public int Size() => lastItemIndex;
    }
    public class MedianHeap
    {
        private MaxBinaryHeap maxBinaryHeap;
        private MinBinaryHeap minBinaryHeap;

        public MedianHeap(int size)
        {
            maxBinaryHeap = new MaxBinaryHeap(size + 2);
            minBinaryHeap = new MinBinaryHeap(size + 2);
        }
        private bool IsEmpty() => maxBinaryHeap.Size() == minBinaryHeap.Size() && minBinaryHeap.Size() == 0;
        public double Median()
        {
            if (maxBinaryHeap.Size() == minBinaryHeap.Size())
                return (maxBinaryHeap.Peek() + minBinaryHeap.Peek()) / 2.0;
            else if (maxBinaryHeap.Size() > minBinaryHeap.Size())
                return maxBinaryHeap.Peek();
            else
                return minBinaryHeap.Peek();
        }
        public void Insert(int value)
        {
            if (IsEmpty())
                minBinaryHeap.Insert(value);
            else if (value > Median())
                minBinaryHeap.Insert(value);
            else
                maxBinaryHeap.Insert(value);

            if (minBinaryHeap.Size() > maxBinaryHeap.Size() + 1)
                maxBinaryHeap.Insert(minBinaryHeap.ExtractMin());
            else if (maxBinaryHeap.Size() > minBinaryHeap.Size() + 1)
                minBinaryHeap.Insert(maxBinaryHeap.ExtractMax());
        }
    }
}
