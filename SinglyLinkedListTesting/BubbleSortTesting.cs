using NUnit.Framework;
using Datenstrukturen;
using Common;
using SortingAlgorithms;

namespace BubbleSortTesting
{
    [TestFixture]
    public class Tests
    {
        private DoubleLinkedList<Person> _list = null!;
        private ListSorter<Person> _sorter = null!;

        [SetUp]
        public void Setup()
        {
            _list = new DoubleLinkedList<Person>();
            _sorter = new ListSorter<Person>(new BubbleSort<Person>());
        }

        [Test]
        public void BubbleSort_ListWithThreePersons_ShouldSortByNameAscending()
        {
            var p1 = new Person(new DateTime(2003, 1, 1), "maennlich", "Sally");
            var p2 = new Person(new DateTime(2002, 1, 1), "maennlich", "Onur");
            var p3 = new Person(new DateTime(2001, 1, 1), "maennlich", "Maurice");

            _list.InsertAtEnd(p1);
            _list.InsertAtEnd(p2);
            _list.InsertAtEnd(p3);

            _sorter.Sort(_list.GetHead());

            var head = _list.GetHead();
            Assert.That(head!.data.Name, Is.EqualTo("Maurice"));
            Assert.That(head.Next!.data.Name, Is.EqualTo("Onur"));
            Assert.That(head.Next.Next!.data.Name, Is.EqualTo("Sally"));
        }

        [Test]
        public void BubbleSort_EmptyList_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => _sorter.Sort(_list.GetHead()));
        }

        [Test]
        public void BubbleSort_ListWithOneElement_ShouldRemainUnchanged()
        {
            var p = new Person(new DateTime(2001, 1, 1), "maennlich", "Maylin");
            _list.InsertAtEnd(p);

            _sorter.Sort(_list.GetHead());

            Assert.That(_list.GetHead()!.data.Name, Is.EqualTo("Maylin"));
        }
    }
}