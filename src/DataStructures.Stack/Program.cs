using System;

namespace DataStructures.Stack
{
    public class Stack
    {
        private int[] elements;
        private int top;
        private int maxSize;

        public Stack(int size)
        {
            elements = new int[size];
            top = -1;
            maxSize = size;
        }

        public void Push(int item)
        {
            if (top == maxSize - 1)
            {
                Console.WriteLine("Stack is full.");
                return;
            }
            elements[++top] = item;
        }

        public int Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty.");
                throw new InvalidOperationException("Stack is empty.");
            }
            return elements[top--];
        }

        public int Peek()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty.");
                throw new InvalidOperationException("Stack is empty.");
            }
            return elements[top];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public void PrintStack()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty.");
                return;
            }
            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(elements[i]);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Stack stack = new Stack(5);

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Console.WriteLine("Stack after pushes:");
            stack.PrintStack();

            Console.WriteLine("Peek: " + stack.Peek());

            Console.WriteLine("Pop: " + stack.Pop());

            Console.WriteLine("Stack after pop:");
            stack.PrintStack();

            Console.WriteLine("Is stack empty? " + stack.IsEmpty());
        }
    }

}
