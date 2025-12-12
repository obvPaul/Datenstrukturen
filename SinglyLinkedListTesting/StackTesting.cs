using NUnit.Framework;
using Datenstrukturen;
using Common;
using SortingAlgorithms;

namespace StackTesting
{
    [TestFixture]
    public class Tests
    {
        private MyStack<Person> stack = null!;

        [SetUp]
        public void Setup()
        {
            stack = new MyStack<Person>();
        }

        [Test]
        public void PushPop_ShouldFollowLIFO()
        {
            var p1 = new Person(new DateTime(2000, 1, 1), "maennlich", "Onur");
            var p2 = new Person(new DateTime(2001, 1, 1), "weiblich", "Anna");

            stack.Push(p1);
            stack.Push(p2);

            Assert.That(stack.Pop()!.Name, Is.EqualTo("Anna"));
            Assert.That(stack.Pop()!.Name, Is.EqualTo("Onur"));
        }

        [Test]
        public void Peek_ShouldReturnTopWithoutRemoving()
        {
            var p = new Person(new DateTime(2000, 1, 1), "maennlich", "Tom");
            stack.Push(p);

            Assert.That(stack.Peek()!.Name, Is.EqualTo("Tom"));
            Assert.That(stack.Pop()!.Name, Is.EqualTo("Tom"));
        }

        [Test]
        public void IsEmpty_ShouldReturnTrueForNewStack()
        {
            Assert.That(stack.IsEmpty(), Is.True);  // ← Gefixt!
        }

        [Test]
        public void Pop_OnEmptyStack_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek_OnEmptyStack_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void Push_NullData_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => stack.Push(null!));
        }

        [Test]
        public void Sort_WithBubbleSort_ShouldSortStack()
        {
            var p1 = new Person(new DateTime(2000, 1, 1), "weiblich", "Lisa");
            var p2 = new Person(new DateTime(2000, 1, 1), "maennlich", "Tom");
            var p3 = new Person(new DateTime(2000, 1, 1), "weiblich", "Anna");

            stack.Push(p1);
            stack.Push(p2);
            stack.Push(p3);  // Top: Anna → Tom → Lisa

            stack.SetSortAlgorithm(new BubbleSort<Person>());
            stack.Sort();

            Assert.That(stack.Pop()!.Name, Is.EqualTo("Anna"));
            Assert.That(stack.Pop()!.Name, Is.EqualTo("Lisa"));
            Assert.That(stack.Pop()!.Name, Is.EqualTo("Tom"));
        }

        [Test]
        public void Sort_WithInsertionSort_ShouldSortStack()
        {
            var p1 = new Person(new DateTime(2000, 1, 1), "weiblich", "Lisa");
            var p2 = new Person(new DateTime(2000, 1, 1), "maennlich", "Tom");
            var p3 = new Person(new DateTime(2000, 1, 1), "weiblich", "Anna");

            stack.Push(p1);
            stack.Push(p2);
            stack.Push(p3);

            stack.SetSortAlgorithm(new InsertionSort<Person>());
            stack.Sort();

            Assert.That(stack.Pop()!.Name, Is.EqualTo("Anna"));
            Assert.That(stack.Pop()!.Name, Is.EqualTo("Lisa"));
            Assert.That(stack.Pop()!.Name, Is.EqualTo("Tom"));
        }

        [Test]
        public void Sort_EmptyStack_ShouldNotThrow()
        {
            stack.SetSortAlgorithm(new BubbleSort<Person>());
            Assert.DoesNotThrow(() => stack.Sort());
        }

        [Test]
        public void Sort_SingleElement_ShouldRemainUnchanged()
        {
            var p = new Person(new DateTime(2000, 1, 1), "maennlich", "Max");
            stack.Push(p);

            stack.SetSortAlgorithm(new BubbleSort<Person>());
            stack.Sort();

            Assert.That(stack.Pop()!.Name, Is.EqualTo("Max"));
        }

        [Test]
        public void Sort_WithoutSettingAlgorithm_ShouldThrowException()
        {
            stack.Push(new Person(new DateTime(2000, 1, 1), "maennlich", "Tom"));

            Assert.Throws<InvalidOperationException>(() => stack.Sort());
        }

        [Test]
        public void LargeStack_PushAndPop_ShouldHandleManyElements()
        {
            const int count = 1000;
            for (int i = 0; i < count; i++)
            {
                stack.Push(new Person(new DateTime(2000, 1, 1), "maennlich", $"Person{i}"));
            }

            for (int i = count - 1; i >= 0; i--)
            {
                Assert.That(stack.Pop()!.Name, Is.EqualTo($"Person{i}"));
            }
            Assert.That(stack.IsEmpty(), Is.True);
        }

        [Test]
        public void Sort_LargeStack_WithInsertionSort_ShouldSortCorrectly()
        {
            var persons = new[]
            {
                new Person(new DateTime(2000, 1, 1), "maennlich", "Zorro"),
                new Person(new DateTime(2000, 1, 1), "weiblich", "Anna"),
                new Person(new DateTime(2000, 1, 1), "maennlich", "Tom"),
                new Person(new DateTime(2000, 1, 1), "weiblich", "Lisa")
            };

            foreach (var p in persons)
            {
                stack.Push(p);
            }

            stack.SetSortAlgorithm(new InsertionSort<Person>());
            stack.Sort();

            Assert.That(stack.Pop()!.Name, Is.EqualTo("Anna"));
            Assert.That(stack.Pop()!.Name, Is.EqualTo("Lisa"));
            Assert.That(stack.Pop()!.Name, Is.EqualTo("Tom"));
            Assert.That(stack.Pop()!.Name, Is.EqualTo("Zorro"));
        }
    }
}