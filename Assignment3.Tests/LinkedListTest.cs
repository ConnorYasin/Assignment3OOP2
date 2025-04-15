using System.Collections.Generic;

namespace Assignment3
{
    public class SLLTest
    {
        SLL<string> list;

        [SetUp]
        public void Setup()
        {
            list = new SLL<string>();
        }

        [Test]
        public void TestAddingNodeBeginList()
        {
            list.AddFirst("Joe Blow");
            Assert.AreEqual("Joe Blow", list.Head.Data);
        }

        [Test]
        public void TestAddingNodeEndList()
        {
            list.AddFirst("John Smith");
            list.AddFirst("Jane Doe");
            list.AddFirst("Bob Bobberson");
            list.AddLast("Joe Schmoe");
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