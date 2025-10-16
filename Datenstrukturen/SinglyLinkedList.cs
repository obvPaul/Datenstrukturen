using System;
using Common;

namespace Datenstrukturen
{
    public class SinglyLinkedList
    {
        private Node<Person>? head = null;

        public Node<Person> InsertAtEnd(Person person)
        {
            var newNode = new Node<Person>(person);
            if (head == null)
            {
                head = newNode;
                return head;
            }

            var last = head;
            while (last.Next != null)
            {
                last = last.Next;
            }

            last.Next = newNode;
            return head;
        }

        public Node<Person>? SearchNode(string name)
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

        public Node<Person> InsertBefore(Person elementAfter, Person elementToInsert)
        {
            var newNode = new Node<Person>(elementToInsert);

            if (head == null)
            {
                head = newNode;
                return head;
            }

            if (head.data.Name == elementAfter.Name)
            {
                newNode.Next = head;
                head = newNode;
                return head;
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

        public Node<Person> InsertAfter(Person elementBefore, Person elementToInsert)
        {
            if (head == null)
            {
                head = new Node<Person>(elementToInsert);
                return head;
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

        public Node<Person>? GetHead()
        {
            return head;
        }
    }
}