using System;

namespace DataStructures.Queue
{
    public class Queue
    {
        private int[] elements;
        private int front;
        private int rear;
        private int maxSize;
        private int currentSize;

        public Queue(int size)
        {
            elements = new int[size];
            front = 0;
            rear = -1;
            maxSize = size;
            currentSize = 0;
        }

        public void Enqueue(int item)
        {
            if (currentSize == maxSize)
            {
                Console.WriteLine("Queue is full.");
                return;
            }
            rear = (rear + 1) % maxSize;
            elements[rear] = item;
            currentSize++;
        }

        public int Dequeue()
        {
            if (currentSize == 0)
            {
                Console.WriteLine("Queue is empty.");
                throw new InvalidOperationException("Queue is empty.");
            }
            int item = elements[front];
            front = (front + 1) % maxSize;
            currentSize--;
            return item;
        }

        public int Peek()
        {
            if (currentSize == 0)
            {
                Console.WriteLine("Queue is empty.");
                throw new InvalidOperationException("Queue is empty.");
            }
            return elements[front];
        }

        public bool IsEmpty()
        {
            return currentSize == 0;
        }

        public void PrintQueue()
        {
            if (currentSize == 0)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }
            for (int i = 0; i < currentSize; i++)
            {
                int index = (front + i) % maxSize;
                Console.Write(elements[index] + " ");
            }
            Console.WriteLine();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Queue queue = new Queue(5);

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Console.WriteLine("Queue after enqueues:");
            queue.PrintQueue();

            Console.WriteLine("Peek: " + queue.Peek());

            Console.WriteLine("Dequeue: " + queue.Dequeue());

            Console.WriteLine("Queue after dequeue:");
            queue.PrintQueue();

            Console.WriteLine("Is queue empty? " + queue.IsEmpty());
        }
    }
}
