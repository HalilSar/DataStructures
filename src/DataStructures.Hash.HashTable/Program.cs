using System;
using System.Collections.Generic;
namespace DataStructures.Hash.HashTable
{
    class HashTable<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValuePair<K, V>>[] items;

        public HashTable(int size)
        {
            this.size = size;
            items = new LinkedList<KeyValuePair<K, V>>[size];
        }

        protected int GetArrayPosition(K key)
        {
            int hash = key.GetHashCode();
            int position = hash % size;
            return Math.Abs(position);
        }

        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValuePair<K, V> pair in linkedList)
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
            return default(V);
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> linkedList = GetLinkedList(position);
            KeyValuePair<K, V> item = new KeyValuePair<K, V>(key, value);
            linkedList.AddLast(item);
        }

        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValuePair<K, V> foundItem = default(KeyValuePair<K, V>);
            foreach (KeyValuePair<K, V> pair in linkedList)
            {
                if (pair.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = pair;
                }
            }

            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }

        protected LinkedList<KeyValuePair<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValuePair<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValuePair<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(5);
            hashTable.Add("one", 1);
            hashTable.Add("two", 2);
            hashTable.Add("three", 3);

            Console.WriteLine("Value for 'one': " + hashTable.Get("one"));
            Console.WriteLine("Value for 'two': " + hashTable.Get("two"));

            hashTable.Remove("two");

            Console.WriteLine("Value for 'two' after removal: " + hashTable.Get("two"));
        }
    }
}