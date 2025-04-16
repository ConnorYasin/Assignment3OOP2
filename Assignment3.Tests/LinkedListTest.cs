namespace Assignment3.Tests
{
    public class SLLTest
    {
        Utility.SLL list;

        [SetUp]
        public void Setup()
        {
            list = new Utility.SLL();

            list.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            list.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            list.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            list.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }
        [TearDown]
        public void TearDown()
        {
            list.Clear();
        }

        [Test]
        public void TestAddingNodeBeginList()
        {
            User newUser = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            list.AddFirst(newUser);
            Assert.That(list.head.Data, Is.EqualTo(newUser));
        }
        [Test]
        public void TestAddingNodeEndList()
        {
            User newUser = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            list.AddLast(newUser);
            Assert.That(list.tail.Data, Is.EqualTo(newUser));
        }
        [Test]
        public void TestRemoveFirstNode()
        {
            User newUser = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            list.AddFirst(newUser);
            list.RemoveFirst();
            Assert.That(list.head.Data, Is.EqualTo(newUser));
        }
        [Test]
        public void TestRemoveLastNode()
        {
            User newUser = (new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
            list.AddLast(newUser);
            list.RemoveLast();
            Assert.That(list.tail.Data, Is.EqualTo(newUser));
        }
        [Test]
        public void TestValueofNode()
        {
            User user = list.head.Next.Data;
            Assert.That(list.GetValue(1), Is.EqualTo(user));
        }
        [Test]
        public void TestSizeOfList()
        {
            Assert.That(list.size, Is.EqualTo(4));
        }
        [Test]
        public void TestContainsUser()
        {
            User newUser = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            bool result = list.Contains(newUser);
            Assert.IsTrue(result);
        }
        [Test]
        public void TestIndexOfUser()
        {
            User newUser = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            int index = list.IndexOf(newUser);
            Assert.That(index, Is.EqualTo(2));
        }
        [Test]
        public void TestReplaceUser()
        {
            User replacement = new User(10, "Updated", "update@me.com", "pass");
            list.Replace(replacement, 1);
            User updated = list.GetValue(1);
            Assert.That(updated, Is.EqualTo(replacement));
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
            Assert.That(list.GetFirst().Name, Is.EqualTo("Colonel Sanders"));
            Assert.That(list.GetLast().Name, Is.EqualTo("Ronald McDonald"));
        }
    }
}