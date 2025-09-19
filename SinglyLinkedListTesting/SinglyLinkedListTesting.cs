using Common;
using Datenstrukturen;
namespace SinglyLinkedListTest
{
    public class Tests
    {
        [Test]
        public void InsertAtEnd_AddsNodeCorrectly()
        {
            Node head = null;
            head = SinglyLinkedList.insertAtEnd(head, new Person(new DateTime(2000, 6, 11), "maennlich", "Paul"));
            head = SinglyLinkedList.insertAtEnd(head, new Person(new DateTime(1974, 8, 20), "weiblich", "Cornelia"));

            Assert.AreEqual("Paul", head.Data.Name);
            Assert.AreEqual("Cornelia", head.Next.Data.Name);
            Assert.IsNull(head.Next.Next);
        }
        [Test]
        public void SearchSpecificPerson_ReturnsCorrectNode()
        {
            Node head = null;
            head = SinglyLinkedList.insertAtEnd(head, new Person(new DateTime(1974, 8, 20), "weiblich", "Cornelia"));
            head = SinglyLinkedList.insertAtEnd(head, new Person(new DateTime(2008, 7, 1), "weiblich", "Linnea"));
            head = SinglyLinkedList.insertAtEnd(head, new Person(new DateTime(2008, 6, 11), "weiblich", "Paul"));
            Node result = SinglyLinkedList.searchNode(head, "Linnea");

            Assert.IsNotNull(result);
            Assert.AreEqual("Linnea", result.Data.Name);
        }
    }
}