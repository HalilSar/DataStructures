using System;

namespace DataStructures.Hash.CollisionResolutionTechniques.OpenAddressing
{
    class Program
    {
        private int size;
        private int[] keys;
        private string[] values;

        public Program(int size)
        {
            this.size = size;
            keys = new int[size];
            values = new string[size];
            for (int i = 0; i < size; i++)
            {
                keys[i] = -1; 
            }
        }

        public void Add(int key, string value)
        {
            int hash = key % size;
            while (keys[hash] != -1 && keys[hash] != key)
            {
                hash = (hash + 1) % size;
            }
            keys[hash] = key;
            values[hash] = value;
        }

        public string Get(int key)
        {
            int hash = key % size;
            while (keys[hash] != -1)
            {
                if (keys[hash] == key)
                {
                    return values[hash];
                }
                hash = (hash + 1) % size;
            }
            return null;
        }

        public static void Main(string[] args)
        {
            var hashTable = new Program(10);
            hashTable.Add(1, "One");
            hashTable.Add(11, "Eleven");
            hashTable.Add(21, "Twenty-One");

            Console.WriteLine(hashTable.Get(1));  // Output: One
            Console.WriteLine(hashTable.Get(11)); // Output: Eleven
            Console.WriteLine(hashTable.Get(21)); // Output: Twenty-One
        }
    }
}
