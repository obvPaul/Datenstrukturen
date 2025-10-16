using NUnit.Framework;
using Common;
using Datenstrukturen;

namespace SinglyLinkedListTesting
{
    public class Tests
    {
        private SinglyLinkedList list;

        [SetUp]
        public void Setup()
        {
            list = new SinglyLinkedList();
        }

        [Test]
        public void InsertAtEnd_ListWithTwoElements_ShouldInsertNodesAtEndOfList()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");

            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);

            var head = list.GetHead();
            Assert.That(head.data.Name, Is.EqualTo("Onur"));
            Assert.That(head.Next.data.Name, Is.EqualTo("Maurice"));
        }

        [Test]
        public void SearchNode_ShouldFindExistingNode()
        {
            var p1 = new Person(new DateTime(2008, 7, 1), "weiblich", "Maylin");
            var p2 = new Person(new DateTime(2008, 6, 11), "weiblich", "Sally");

            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);

            var found = list.SearchNode("Sally");
            Assert.That(found, Is.Not.Null);
            Assert.That(found.data.Name, Is.EqualTo("Sally"));
        }

        [Test]
        public void SearchNode_ShouldReturnNull_WhenNotFound()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            list.InsertAtEnd(p1);

            var found = list.SearchNode("Gabriel");
            Assert.That(found, Is.Null);
        }

        [Test]
        public void InsertBefore_ShouldInsertNodeBeforeSpecifiedElement()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");
            var p3 = new Person(new DateTime(2008, 7, 1), "weiblich", "Maylin");

            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);
            list.InsertBefore(p2, p3);

            var head = list.GetHead();
            Assert.That(head.Next.data.Name, Is.EqualTo("Maylin"));
            Assert.That(head.Next.Next.data.Name, Is.EqualTo("Maurice"));
        }

        [Test]
        public void InsertBefore_ShouldInsertAtHead_WhenElementAfterIsFirst()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");

            list.InsertAtEnd(p1);
            list.InsertBefore(p1, p2);

            var head = list.GetHead();
            Assert.That(head.data.Name, Is.EqualTo("Maurice"));
            Assert.That(head.Next.data.Name, Is.EqualTo("Onur"));
        }

        [Test]
        public void InsertAfter_ShouldInsertNodeAfterSpecifiedElement()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");
            var p3 = new Person(new DateTime(2008, 7, 1), "weiblich", "Maylin");

            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);
            list.InsertAfter(p1, p3);

            var head = list.GetHead();
            Assert.That(head.Next.data.Name, Is.EqualTo("Maylin"));
            Assert.That(head.Next.Next.data.Name, Is.EqualTo("Maurice"));
        }
    }
}
