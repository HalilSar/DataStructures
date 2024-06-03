using System;
using System.Collections.Generic;

namespace DataStructures.Hash.CollisionResolutionTechniques.Chaining
{
    class Program
    {
        private int size;
        private LinkedList<KeyValuePair<int, string>>[] table;

        public Program(int size)
        {
            this.size = size;
            table = new LinkedList<KeyValuePair<int, string>>[size];
            for (int i = 0; i < size; i++)
            {
                table[i] = new LinkedList<KeyValuePair<int, string>>();
            }
        }

        public void Add(int key, string value)
        {
            int hash = key % size;
            var kvp = new KeyValuePair<int, string>(key, value);
            table[hash].AddLast(kvp);
        }

        public string Get(int key)
        {
            int hash = key % size;
            foreach (var kvp in table[hash])
            {
                if (kvp.Key == key)
                {
                    return kvp.Value;
                }
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
