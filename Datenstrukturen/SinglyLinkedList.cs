using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Datenstrukturen
{
    public class SinglyLinkedList
    {
        public static Node InsertAtEnd(Node head, Person person)
        {
            Node newNode = new Node(person);
            if (head == null)
            {
                return newNode;
            }
            Node last = head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Next = newNode;
            return head;
        }
        public static Node SearchNode(Node head, string name)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Name == name)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
    }
}