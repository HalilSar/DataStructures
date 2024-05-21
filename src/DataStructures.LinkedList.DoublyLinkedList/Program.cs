using System;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class Node
    {
        public int data;
        public Node prev;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.prev = null;
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

       
        public void AddFirst(int data)
        {
            Node newNode = new Node(data);
            if (head != null)
            {
                head.prev = newNode;
                newNode.next = head;
            }
            head = newNode;
        }

       
        public void AddLast(int data)
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
            newNode.prev = current;
        }

    
        public void Delete(int data)
        {
            if (head == null) return;
            if (head.data == data)
            {
                head = head.next;
                if (head != null) head.prev = null;
                return;
            }
            Node current = head;
            while (current != null && current.data != data)
            {
                current = current.next;
            }
            if (current == null) return;
            if (current.next != null) current.next.prev = current.prev;
            if (current.prev != null) current.prev.next = current.next;
        }

     
        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
 
        public static void Main(string[] args)
        {
            Program dll = new Program();

            dll.AddFirst(10);
            dll.AddFirst(20);
            dll.AddLast(30);
            dll.AddLast(40);

            Console.WriteLine("Doubly Linked List:");
            dll.PrintList();

            dll.Delete(20);
            Console.WriteLine("After Deletion of 20:");
            dll.PrintList();
        }
    }
}
