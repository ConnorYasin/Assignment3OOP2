using System.Collections.Generic;
using Assignment3;

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
            User newUser = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            list.AddFirst(newUser);
            Assert.AreEqual(newUser, list.head.Data);
        }

        [Test]
        public void TestAddingNodeEndList()
        {
            User newUser = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            list.AddLast(newUser);
            Assert.AreEqual(newUser, list.tail.Data);
        }

        [Test]
        public void TestRemoveFirstNode()
        {
            User newUser = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            list.AddFirst(newUser)
            list.RemoveFirst();
            Assert.AreEqual(newUser, list.Head.Data);
        }

        [Test]
        public void TestRemoveLastNode()
        {
            User newUser = (new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
            list.AddLast(newUser)
            list.RemoveLast();
            Assert.IsNull(newUser, list.Tail)
        }

        [Test]
        public void TestValueofNode()
        {
            User node = list.Head?.Next?.Next;
            Assert.AreEqual(User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555")););
        }

        [Test]
        public void TestSizeOfList()
        {
            Assert.AreEqual(4, list.count);
        }
        [Test]
        public void TestContainsUser()
        {
            User result = list.Contains(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            Assert.IsTrue(result);
        }

        [Test]
        public void TestIndexOfUser()
        {
            User index = list.IndexOf(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            Assert.AreEqual(2, index);
        }

        [Test]
        public void TestReplaceUser()
        {
            User replacement = new User(10, "Updated", "update@me.com", "pass");
            list.Replace(replacement, 1);
            User updated = list.GetValue(1);
            Assert.AreEqual(replacement, updated);
        }

        [Test]
        public void TestClearList()
        {
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestSortListByName()
        {
            list.SortListByName();
            Assert.AreEqual("Colonel Sanders", list.GetFirst().Name);
            Assert.AreEqual("Ronald McDonald", list.GetLast().Name);
        }
}