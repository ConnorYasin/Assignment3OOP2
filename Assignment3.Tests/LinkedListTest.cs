using System.Collections.Generic;
using Assignment3

namespace Assignment3.Tests
{
    public class SLLTest
    {
        new Utility.SLL list;

        [SetUp]
        public void Setup()
        {
            list = new Utility.SLL();

            list.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            list.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            list.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            list.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [Test]
        public void TestAddingNodeBeginList()
        {
            list.AddFirst(User(1, "Joe Blow", "jblow@gmail.com", "password"));
            Assert.AreEqual(User(1, "Joe Blow", "jblow@gmail.com", "password"), list.Head.Data);
        }

        [Test]
        public void TestAddingNodeEndList()
        {
            list.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            list.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            list.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            list.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
            Assert.AreEqual("Joe Schmoe", list.Tail.Data);
        }

        [Test]
        public void TestRemoveNodeBeginList()
        {
            list.AddFirst("John Smith");
            list.RemoveFirst();
            Assert.IsNull(list.Head);
        }

        [Test]
        public void TestRemoveNodeEndList()
        {
            list.AddLast("Jane Doe");
            list.RemoveLast();
            Assert.IsNull(list.Tail);
        }

        [Test]
        public void TestValueofNode()
        {
            list.AddLast("Bob Bobberson");
            list.AddLast("Sam Sammerson");
            list.AddLast("Dave Daverson");            
            list.AddLast("Sammy Sammerson");
            list.AddLast("Davey Daverson");

            var node = list.Head?.Next?.Next;

            Assert.AreEqual("Dave Daverson", node?.Data);
        }

        [Test]
        public void TestSizeOfList()
        {
            list.AddFirst("Bob Bobberson");
            list.AddFirst("Sam Sammerson");
            list.AddFirst("Dave Daverson");

            Assert.AreEqual(3, list.count);
        }
    }
}