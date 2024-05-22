using System;

namespace DataStructures.LinkedList.CircularLinkedList
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
                head.next = head;  
                return;
            }

            Node current = head;
            while (current.next != head)
            {
                current = current.next;
            }
            current.next = newNode;
            newNode.next = head;
        }

        
        public void Prepend(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                head.next = head;  
                return;
            }

            Node current = head;
            while (current.next != head)
            {
                current = current.next;
            }
            current.next = newNode;
            newNode.next = head;
            head = newNode;
        }

        
        public void Delete(int data)
        {
            if (head == null) return;

            if (head.data == data)
            {
                if (head.next == head)
                {
                    head = null;
                    return;
                }

                Node current = head;
                while (current.next != head)
                {
                    current = current.next;
                }
                current.next = head.next;
                head = head.next;
                return;
            }

            Node prev = null;
            Node temp = head;

            do
            {
                if (temp.data == data)
                {
                    prev.next = temp.next;
                    return;
                }
                prev = temp;
                temp = temp.next;
            } while (temp != head);
        }

       
        public void PrintList()
        {
            if (head == null) return;

            Node current = head;
            do
            {
                Console.Write(current.data + " -> ");
                current = current.next;
            } while (current != head);
            Console.WriteLine("(head)");
        }

        // Ana fonksiyon
        public static void Main(string[] args)
        {
            Program cll = new Program();

            cll.Append(10);
            cll.Append(20);
            cll.Append(30);
            cll.Prepend(5);

            Console.WriteLine("Circular Linked List:");
            cll.PrintList();

            cll.Delete(20);
            Console.WriteLine("After Deletion of 20:");
            cll.PrintList();
        }
    }
}
