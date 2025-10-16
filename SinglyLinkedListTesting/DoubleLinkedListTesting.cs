using NUnit.Framework;
using Common;
using Datenstrukturen;
using System;

namespace DoubleLinkedListTesting
{
    public class Tests
    {
        private DoubleLinkedList<Person> list;

        [SetUp]
        public void Setup()
        {
            list = new DoubleLinkedList<Person>();
        }

        private bool PersonComparer(Person a, Person b) => a.Name == b.Name;

        [Test]
        public void InsertAtEnd_ListWithTwoElements_ShouldInsertNodesAtEndOfList()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");

            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);

            var head = list.GetHead();
            var tail = list.GetTail();

            Assert.That(head.Data.Name, Is.EqualTo("Onur"));
            Assert.That(head.Next.Data.Name, Is.EqualTo("Maurice"));
            Assert.That(tail.Prev.Data.Name, Is.EqualTo("Onur"));
        }

        [Test]
        public void SearchNode_ElementExists_ShouldReturnCorrectNode()
        {
            var p1 = new Person(new DateTime(2008, 7, 1), "weiblich", "Maylin");
            var p2 = new Person(new DateTime(2008, 6, 11), "weiblich", "Sally");

            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);

            var found = list.SearchNode(p => p.Name == "Sally");

            Assert.That(found, Is.Not.Null);
            Assert.That(found.Data.Name, Is.EqualTo("Sally"));
        }

        [Test]
        public void SearchNode_ElementNotInList_ShouldReturnNull()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            list.InsertAtEnd(p1);

            var found = list.SearchNode(p => p.Name == "Gabriel");

            Assert.That(found, Is.Null);
        }

        [Test]
        public void InsertBefore_ElementInMiddle_ShouldInsertBeforeCorrectNode()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");
            var p3 = new Person(new DateTime(2008, 7, 1), "weiblich", "Maylin");

            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);
            list.InsertBefore(p2, p3, PersonComparer);

            var head = list.GetHead();
            Assert.That(head.Next.Data.Name, Is.EqualTo("Maylin"));
            Assert.That(head.Next.Next.Data.Name, Is.EqualTo("Maurice"));
        }

        [Test]
        public void InsertBefore_ElementIsHead_ShouldInsertNewHead()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");

            list.InsertAtEnd(p1);
            list.InsertBefore(p1, p2, PersonComparer);

            var head = list.GetHead();
            Assert.That(head.Data.Name, Is.EqualTo("Maurice"));
            Assert.That(head.Next.Data.Name, Is.EqualTo("Onur"));
        }

        [Test]
        public void InsertAfter_ElementInMiddle_ShouldInsertAfterCorrectNode()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");
            var p3 = new Person(new DateTime(2008, 7, 1), "weiblich", "Maylin");

            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);
            list.InsertAfter(p1, p3, PersonComparer);

            var head = list.GetHead();
            Assert.That(head.Next.Data.Name, Is.EqualTo("Maylin"));
            Assert.That(head.Next.Next.Data.Name, Is.EqualTo("Maurice"));
            Assert.That(head.Next.Prev.Data.Name, Is.EqualTo("Onur"));
        }

        [Test]
        public void InsertAfter_ElementIsTail_ShouldInsertNewTail()
        {
            var p1 = new Person(new DateTime(2000, 6, 11), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 2, 3), "maennlich", "Maurice");

            list.InsertAtEnd(p1);
            list.InsertAfter(p1, p2, PersonComparer);

            var tail = list.GetTail();
            Assert.That(tail.Data.Name, Is.EqualTo("Maurice"));
            Assert.That(tail.Prev.Data.Name, Is.EqualTo("Onur"));
        }
    }
}
