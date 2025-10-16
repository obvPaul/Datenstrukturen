using System;
using Common;

namespace Datenstrukturen
{
    public class SinglyLinkedList
    {
        public static Node<Person> InsertAtEnd(Node<Person>? head, Person person)
        {
            var newNode = new Node<Person>(person);
            if (head == null)
            {
                return newNode;
            }

            var last = head;
            while (last.Next != null)
            {
                last = last.Next;
            }

            last.Next = newNode;
            return head;
        }

        public static Node<Person>? SearchNode(Node<Person>? head, string name)
        {
            var current = head;
            while (current != null)
            {
                if (current.data.Name == name)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public static Node<Person> InsertBefore(Node<Person>? head, Person elementAfter, Person elementToInsert)
        {
            var newNode = new Node<Person>(elementToInsert);

            if (head == null)
            {
                return newNode;
            }

            if (head.data.Name == elementAfter.Name)
            {
                newNode.Next = head;
                return newNode;
            }

            var current = head;
            while (current.Next != null && current.Next.data.Name != elementAfter.Name)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                newNode.Next = current.Next;
                current.Next = newNode;
            }

            return head;
        }

        public static Node<Person> InsertAfter(Node<Person>? head, Person elementBefore, Person elementToInsert)
        {
            if (head == null)
            {
                return new Node<Person>(elementToInsert);
            }

            var current = head;
            while (current != null && current.data.Name != elementBefore.Name)
            {
                current = current.Next;
            }

            if (current != null)
            {
                var newNode = new Node<Person>(elementToInsert);
                newNode.Next = current.Next;
                current.Next = newNode;
            }

            return head;
        }
    }
}
