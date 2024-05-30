using System;

namespace DataStructures.Tree.SegmentTree
{
     class SegmentTree
    {
        private int[] tree;
        private int maxSize;
        private int height;

        public SegmentTree(int[] arr)
        {
            int n = arr.Length;
            height = (int)Math.Ceiling(Math.Log(n) / Math.Log(2));
            maxSize = 2 * (int)Math.Pow(2, height) - 1;
            tree = new int[maxSize];
            BuildTree(arr, 0, n - 1, 0);
        }

        private int BuildTree(int[] arr, int start, int end, int current)
        {
            if (start == end)
            {
                tree[current] = arr[start];
                return arr[start];
            }

            int mid = GetMid(start, end);
            tree[current] = BuildTree(arr, start, mid, current * 2 + 1) +
                            BuildTree(arr, mid + 1, end, current * 2 + 2);
            return tree[current];
        }

        private int GetMid(int start, int end)
        {
            return start + (end - start) / 2;
        }

        public int GetSum(int n, int qs, int qe)
        {
            if (qs < 0 || qe > n - 1 || qs > qe)
            {
                Console.WriteLine("Invalid Input");
                return -1;
            }
            return GetSumUtil(0, n - 1, qs, qe, 0);
        }

        private int GetSumUtil(int ss, int se, int qs, int qe, int current)
        {
            if (qs <= ss && qe >= se)
            {
                return tree[current];
            }
            if (se < qs || ss > qe)
            {
                return 0;
            }
            int mid = GetMid(ss, se);
            return GetSumUtil(ss, mid, qs, qe, 2 * current + 1) +
                   GetSumUtil(mid + 1, se, qs, qe, 2 * current + 2);
        }

        public void UpdateValue(int[] arr, int n, int i, int newValue)
        {
            if (i < 0 || i > n - 1)
            {
                Console.WriteLine("Invalid Input");
                return;
            }
            int diff = newValue - arr[i];
            arr[i] = newValue;
            UpdateValueUtil(0, n - 1, i, diff, 0);
        }

        private void UpdateValueUtil(int ss, int se, int i, int diff, int current)
        {
            if (i < ss || i > se)
            {
                return;
            }
            tree[current] = tree[current] + diff;
            if (se != ss)
            {
                int mid = GetMid(ss, se);
                UpdateValueUtil(ss, mid, i, diff, 2 * current + 1);
                UpdateValueUtil(mid + 1, se, i, diff, 2 * current + 2);
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 1, 3, 5, 7, 9, 11 };
            int n = arr.Length;
            SegmentTree segmentTree = new SegmentTree(arr);

            Console.WriteLine("Sum of values in given range = " +
                              segmentTree.GetSum(n, 1, 3));

            segmentTree.UpdateValue(arr, n, 1, 10);

            Console.WriteLine("Updated sum of values in given range = " +
                              segmentTree.GetSum(n, 1, 3));
        }
    }
}
