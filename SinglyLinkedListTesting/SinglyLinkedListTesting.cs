using NUnit.Framework;
using Common;
using Datenstrukturen;

namespace SinglyLinkedListTesting
{
    public class Tests
    {
        private Node<Person>? head;

        [SetUp]
        public void Setup()
        {
            head = null;
        }

        [Test]
        public void InsertAtEnd_ShouldInsertNodesCorrectly()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");

            head = SinglyLinkedList.InsertAtEnd(head, p1);
            head = SinglyLinkedList.InsertAtEnd(head, p2);

            Assert.That(head.data.Name, Is.EqualTo("Onur"));
            Assert.That(head.Next.data.Name, Is.EqualTo("Maurice"));
        }

        [Test]
        public void SearchNode_ShouldFindExistingNode()
        {
            var p1 = new Person(new DateTime(2008, 7, 1), "weiblich", "Maylin");
            var p2 = new Person(new DateTime(2008, 6, 11), "weiblich", "Sally");

            head = SinglyLinkedList.InsertAtEnd(head, p1);
            head = SinglyLinkedList.InsertAtEnd(head, p2);

            var found = SinglyLinkedList.SearchNode(head, "Sally");
            Assert.That(found, Is.Not.Null);
            Assert.That(found.data.Name, Is.EqualTo("Sally"));
        }

        [Test]
        public void SearchNode_ShouldReturnNull_WhenNotFound()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            head = SinglyLinkedList.InsertAtEnd(head, p1);

            var found = SinglyLinkedList.SearchNode(head, "Gabriel");
            Assert.That(found, Is.Null);
        }

        [Test]
        public void InsertBefore_ShouldInsertNodeBeforeSpecifiedElement()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");
            var p3 = new Person(new DateTime(2008, 7, 1), "weiblich", "Maylin");

            head = SinglyLinkedList.InsertAtEnd(head, p1);
            head = SinglyLinkedList.InsertAtEnd(head, p2);

            head = SinglyLinkedList.InsertBefore(head, p2, p3);

            Assert.That(head.Next.data.Name, Is.EqualTo("Maylin"));
            Assert.That(head.Next.Next.data.Name, Is.EqualTo("Maurice"));
        }

        [Test]
        public void InsertBefore_ShouldInsertAtHead_WhenElementAfterIsFirst()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");

            head = SinglyLinkedList.InsertAtEnd(head, p1);
            head = SinglyLinkedList.InsertBefore(head, p1, p2);

            Assert.That(head.data.Name, Is.EqualTo("Maurice"));
            Assert.That(head.Next.data.Name, Is.EqualTo("Onur"));
        }

        [Test]
        public void InsertAfter_ShouldInsertNodeAfterSpecifiedElement()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");
            var p3 = new Person(new DateTime(2008, 7, 1), "weiblich", "Maylin");

            head = SinglyLinkedList.InsertAtEnd(head, p1);
            head = SinglyLinkedList.InsertAtEnd(head, p2);

            head = SinglyLinkedList.InsertAfter(head, p1, p3);

            Assert.That(head.Next.data.Name, Is.EqualTo("Maylin"));
            Assert.That(head.Next.Next.data.Name, Is.EqualTo("Maurice"));
        }
    }
}
