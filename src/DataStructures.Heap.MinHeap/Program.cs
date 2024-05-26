using System;

namespace DataStructures.Heap.MinHeap
{

    public class Program
    {
        private int[] heap;
        private int size;
        private int maxSize;

        private static int FRONT = 1;

        public Program(int maxSize)
        {
            this.maxSize = maxSize;
            this.size = 0;
            heap = new int[this.maxSize + 1];
            heap[0] = int.MinValue;
        }

        private int Parent(int pos)
        {
            return pos / 2;
        }

        private int LeftChild(int pos)
        {
            return (2 * pos);
        }

        private int RightChild(int pos)
        {
            return (2 * pos) + 1;
        }

        private bool IsLeaf(int pos)
        {
            return pos >= (size / 2) && pos <= size;
        }

        private void Swap(int fpos, int spos)
        {
            int tmp;
            tmp = heap[fpos];
            heap[fpos] = heap[spos];
            heap[spos] = tmp;
        }

        private void MinHeapify(int pos)
        {
            if (!IsLeaf(pos))
            {
                if (heap[pos] > heap[LeftChild(pos)] || heap[pos] > heap[RightChild(pos)])
                {
                    if (heap[LeftChild(pos)] < heap[RightChild(pos)])
                    {
                        Swap(pos, LeftChild(pos));
                        MinHeapify(LeftChild(pos));
                    }
                    else
                    {
                        Swap(pos, RightChild(pos));
                        MinHeapify(RightChild(pos));
                    }
                }
            }
        }

        public void Insert(int element)
        {
            if (size >= maxSize)
            {
                return;
            }
            heap[++size] = element;
            int current = size;

            while (heap[current] < heap[Parent(current)])
            {
                Swap(current, Parent(current));
                current = Parent(current);
            }
        }

        public void Print()
        {
            for (int i = 1; i <= size / 2; i++)
            {
                Console.Write(" PARENT : " + heap[i] + " LEFT CHILD : " + heap[2 * i] + " RIGHT CHILD :" + heap[2 * i + 1]);
                Console.WriteLine();
            }
        }

        public void MinHeap()
        {
            for (int pos = (size / 2); pos >= 1; pos--)
            {
                MinHeapify(pos);
            }
        }

        public int Remove()
        {
            int popped = heap[FRONT];
            heap[FRONT] = heap[size--];
            MinHeapify(FRONT);
            return popped;
        }

        public static void Main(string[] arg)
        {
            Console.WriteLine("The Min Heap is ");
            Program minHeap = new Program(15);
            minHeap.Insert(5);
            minHeap.Insert(3);
            minHeap.Insert(17);
            minHeap.Insert(10);
            minHeap.Insert(84);
            minHeap.Insert(19);
            minHeap.Insert(6);
            minHeap.Insert(22);
            minHeap.Insert(9);
            minHeap.MinHeap();

            minHeap.Print();
            Console.WriteLine("The Min val is " + minHeap.Remove());
        }
    }
}
