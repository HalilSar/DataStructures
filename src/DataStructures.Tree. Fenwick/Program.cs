using System;

namespace DataStructures.Tree._Fenwick
{
    class Program
    {
        private int[] tree;
        private int maxSize;

        // Constructor to initialize the tree with a given size
        public Program(int size)
        {
            maxSize = size;
            tree = new int[maxSize + 1];
        }

        // Update the Fenwick Tree at a particular index with a given value
        public void Update(int index, int value)
        {
            index = index + 1; // Fenwick Tree is 1-indexed

            while (index <= maxSize)
            {
                tree[index] += value;
                index += index & (-index);
            }
        }

        // Get the prefix sum up to a particular index
        public int GetSum(int index)
        {
            int sum = 0;
            index = index + 1; // Fenwick Tree is 1-indexed

            while (index > 0)
            {
                sum += tree[index];
                index -= index & (-index);
            }
            return sum;
        }

        // Get the sum of the range [left, right]
        public int GetRangeSum(int left, int right)
        {
            return GetSum(right) - GetSum(left - 1);
        }

        public static void Main(string[] args)
        {
            int[] arr = { 3, 2, -1, 6, 5, 4, -3, 3, 7, 2, 3 };
            int n = arr.Length;
            Program fenwickTree = new Program(n);

            // Build the Fenwick Tree
            for (int i = 0; i < n; i++)
            {
                fenwickTree.Update(i, arr[i]);
            }

            Console.WriteLine("Sum of elements in arr[0..5] is " + fenwickTree.GetSum(5));
            Console.WriteLine("Sum of elements in arr[1..5] is " + fenwickTree.GetRangeSum(1, 5));

            // Update the value at index 3
            fenwickTree.Update(3, 3); // arr[3] = arr[3] + 3

            Console.WriteLine("Sum of elements in arr[0..5] after update is " + fenwickTree.GetSum(5));
        }
    }
}
