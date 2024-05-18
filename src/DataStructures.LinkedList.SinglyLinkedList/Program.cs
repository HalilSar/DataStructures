using System;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }
    class Program
    {
        private Node head;

        public Program()
        {
            head = null;
        }

        
        public void Append(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = newNode;
        }

        
        public void Prepend(int data)
        {
            Node newNode = new Node(data);
            newNode.next = head;
            head = newNode;
        }

        
        public void DeleteWithValue(int data)
        {
            if (head == null) return;

            if (head.data == data)
            {
                head = head.next;
                return;
            }

            Node current = head;
            while (current.next != null)
            {
                if (current.next.data == data)
                {
                    current.next = current.next.next;
                    return;
                }
                current = current.next;
            }
        }

        
        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data + " -> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }

        public static void Main(string[] args)
        {
            Program linkedList = new Program();

            linkedList.Append(10);
            linkedList.Append(20);
            linkedList.Append(30);
            linkedList.Prepend(5);

            Console.WriteLine("Linked List:");
            linkedList.PrintList();

            linkedList.DeleteWithValue(20);

            Console.WriteLine("After Deletion of 20:");
            linkedList.PrintList();
        }
    }
}
