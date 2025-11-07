using System;
using NUnit.Framework;
using Datenstrukturen;
using Common;

namespace Tests
{
    public class DoubleLinkedListBubbleSortTests
    {
        private DoubleLinkedList<Person> list;

        [SetUp]
        public void Setup()
        {
            list = new DoubleLinkedList<Person>();
        }

        [Test]
        public void BubbleSort_ListWithThreePersons_ShouldSortByNameAscending()
        {
            var p1 = new Person(new DateTime(2003, 1, 1), "maennlich", "Sally");
            var p2 = new Person(new DateTime(2002, 1, 1), "maennlich", "Onur");
            var p3 = new Person(new DateTime(2001, 1, 1), "maennlich", "Maurice");

            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);
            list.InsertAtEnd(p3);

            list.BubbleSort(Comparer<Person>.Create((a, b) => a.Name.CompareTo(b.Name)));

            var head = list.GetHead();

            Assert.That(head!.data.Name, Is.EqualTo("Maurice"));
            Assert.That(head.Next!.data.Name, Is.EqualTo("Onur"));
            Assert.That(head.Next.Next!.data.Name, Is.EqualTo("Sally"));
        }

        [Test]
        public void BubbleSort_EmptyList_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() =>
                list.BubbleSort(Comparer<Person>.Create((a, b) => a.Name.CompareTo(b.Name)))
            );
        }

        [Test]
        public void BubbleSort_ListWithOneElement_ShouldRemainUnchanged()
        {
            var p = new Person(new DateTime(2001, 1, 1), "maennlich", "Maylin");
            list.InsertAtEnd(p);

            list.BubbleSort(Comparer<Person>.Create((a, b) => a.Name.CompareTo(b.Name)));

            Assert.That(list.GetHead()!.data.Name, Is.EqualTo("Maylin"));
        }
    }
}
