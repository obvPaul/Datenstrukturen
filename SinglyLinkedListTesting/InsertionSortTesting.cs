using NUnit.Framework;
using Datenstrukturen;
using Common;
using SortingAlgorithms;
using System;

namespace InsertionSortTesting
{
    [TestFixture]
    public class Tests
    {
        private DoubleLinkedList<Person> list = null!;

        [SetUp]
        public void Setup()
        {
            list = new DoubleLinkedList<Person>();
        }

        [Test]
        public void InsertionSort_ThreePersons_ShouldSortByNameAscending()
        {
            var p1 = new Person(new DateTime(1995, 5, 10), "weiblich", "Lisa");
            var p2 = new Person(new DateTime(1980, 12, 1), "maennlich", "Tom");
            var p3 = new Person(new DateTime(2000, 3, 15), "weiblich", "Anna");

            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);
            list.InsertAtEnd(p3);

            list.SetSortAlgorithm(new InsertionSort<Person>());
            list.Sort();

            var head = list.GetHead();
            Assert.Multiple(() =>
            {
                Assert.That(head!.data.Name, Is.EqualTo("Anna"));
                Assert.That(head.Next!.data.Name, Is.EqualTo("Lisa"));
                Assert.That(head.Next.Next!.data.Name, Is.EqualTo("Tom"));
            });
        }

        [Test]
        public void InsertionSort_AlreadySortedList_ShouldRemainUnchanged()
        {
            list.InsertAtEnd(new Person(new DateTime(2000, 1, 1), "weiblich", "Anna"));
            list.InsertAtEnd(new Person(new DateTime(1995, 1, 1), "weiblich", "Lisa"));
            list.InsertAtEnd(new Person(new DateTime(1980, 1, 1), "maennlich", "Tom"));

            list.SetSortAlgorithm(new InsertionSort<Person>());
            list.Sort();

            var names = new[] { "Anna", "Lisa", "Tom" };
            var current = list.GetHead();
            int i = 0;
            while (current != null)
            {
                Assert.That(current.data.Name, Is.EqualTo(names[i++]));
                current = current.Next;
            }
        }

        [Test]
        public void InsertionSort_ReverseSortedList_ShouldSortCorrectly()
        {
            list.InsertAtEnd(new Person(new DateTime(1980, 1, 1), "maennlich", "Tom"));
            list.InsertAtEnd(new Person(new DateTime(1995, 1, 1), "weiblich", "Lisa"));
            list.InsertAtEnd(new Person(new DateTime(2000, 1, 1), "weiblich", "Anna"));

            list.SetSortAlgorithm(new InsertionSort<Person>());
            list.Sort();

            var head = list.GetHead();
            Assert.Multiple(() =>
            {
                Assert.That(head!.data.Name, Is.EqualTo("Anna"));
                Assert.That(head.Next!.data.Name, Is.EqualTo("Lisa"));
                Assert.That(head.Next.Next!.data.Name, Is.EqualTo("Tom"));
            });
        }

        [Test]
        public void InsertionSort_EmptyList_ShouldNotThrow()
        {
            list.SetSortAlgorithm(new InsertionSort<Person>());
            Assert.DoesNotThrow(() => list.Sort());
        }

        [Test]
        public void InsertionSort_SingleElement_ShouldRemainUnchanged()
        {
            var p = new Person(new DateTime(1999, 9, 9), "maennlich", "Max");
            list.InsertAtEnd(p);

            list.SetSortAlgorithm(new InsertionSort<Person>());
            list.Sort();

            Assert.That(list.GetHead()!.data.Name, Is.EqualTo("Max"));
        }
    }
}