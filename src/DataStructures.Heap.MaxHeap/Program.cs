using System;

namespace DataStructures.Heap.MaxHeap
{
    class Program
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
            heap[0] = int.MaxValue;
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

        private void MaxHeapify(int pos)
        {
            if (!IsLeaf(pos))
            {
                if (heap[pos] < heap[LeftChild(pos)] || heap[pos] < heap[RightChild(pos)])
                {
                    if (heap[LeftChild(pos)] > heap[RightChild(pos)])
                    {
                        Swap(pos, LeftChild(pos));
                        MaxHeapify(LeftChild(pos));
                    }
                    else
                    {
                        Swap(pos, RightChild(pos));
                        MaxHeapify(RightChild(pos));
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

            while (heap[current] > heap[Parent(current)])
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

        public void MaxHeap()
        {
            for (int pos = (size / 2); pos >= 1; pos--)
            {
                MaxHeapify(pos);
            }
        }

        public int Remove()
        {
            int popped = heap[FRONT];
            heap[FRONT] = heap[size--];
            MaxHeapify(FRONT);
            return popped;
        }

        public static void Main(string[] arg)
        {
            Console.WriteLine("The Max Heap is ");
            Program maxHeap = new Program(15);
            maxHeap.Insert(5);
            maxHeap.Insert(3);
            maxHeap.Insert(17);
            maxHeap.Insert(10);
            maxHeap.Insert(84);
            maxHeap.Insert(19);
            maxHeap.Insert(6);
            maxHeap.Insert(22);
            maxHeap.Insert(9);
            maxHeap.MaxHeap();

            maxHeap.Print();
            Console.WriteLine("The Max val is " + maxHeap.Remove());
        }
    }
}
