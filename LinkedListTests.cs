using Assignment3.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    public class LinkedListTests
    {
        private SLL linkedList;
        private User user1;
        private User user2;
        private User user3;

        public void Setup()
        {
            linkedList = new SLL();
            user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            user2 = new User(2, "Joe", "j@gmail.com", "password");
            user3 = new User(3, "Blow", "blow@gmail.com", "password");
        }

        [Test]
        public void TestListIsEmpty()
        {
            linkedList = new SLL();
            Assert.IsTrue(linkedList.IsEmpty());
        }

        [Test]
        public void TestPrependItem()
        {
            linkedList = new SLL();
            var user = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            linkedList.AddFirst(user);
            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user, linkedList.GetValue(0));
        }

        [Test]
        public void TestAppendItem()
        {
            linkedList = new SLL();
            var user = new User(2, "Joe", "jblow@gmail.com", "password");
            linkedList.AddLast(user);
            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user, linkedList.GetValue(0));
        }

        [Test]
        public void TestInsertItemAtIndex()
        {
            linkedList = new SLL();
            var user1 = new User(3, "Joe Blow", "jblow@gmail.com", "password");
            var user2 = new User(4, "Joe Blow", "jblow@gmail.com", "password");
            linkedList.AddLast(user1);
            linkedList.Add(user2, 1);
            Assert.AreEqual(2, linkedList.Count());
            Assert.AreEqual(user1, linkedList.GetValue(0));
            Assert.AreEqual(user2, linkedList.GetValue(1));
        }

        [Test]
        public void TestReplaceItemAtIndex()
        {
            linkedList = new SLL();
            var user1 = new User(5, "Joe Blow", "jblow@gmail.com", "password");
            var user2 = new User(6, "Joe Blow", "jblow@gmail.com", "password");
            linkedList.AddLast(user1);
            linkedList.Replace(user2, 0);
            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user2, linkedList.GetValue(0));
        }

        [Test]
        public void TestDeleteItemFromBeginning()
        {
            linkedList = new SLL();
            var user = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            linkedList.AddLast(user);
            linkedList.RemoveFirst();
            Assert.IsTrue(linkedList.IsEmpty());
        }

        [Test]
        public void TestDeleteItemFromEnd()
        {
            linkedList = new SLL();
            var user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            var user2 = new User(2, "Blow", "blow@gmail.com", "password");
            linkedList.AddLast(user1);
            linkedList.AddLast(user2);
            linkedList.RemoveLast();
            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user1, linkedList.GetValue(0));
        }

        [Test]
        public void TestDeleteItemFromMiddle()
        {
            linkedList = new SLL();
            var user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            var user2 = new User(2, "Joe", "j@gmail.com", "password");
            var user3 = new User(3, "Blow", "blow@gmail.com", "password");
            linkedList.AddLast(user1);
            linkedList.AddLast(user2);
            linkedList.AddLast(user3);
            linkedList.Remove(1);
            Assert.AreEqual(2, linkedList.Count());
            Assert.AreEqual(user3, linkedList.GetValue(1));
        }

        [Test]
        public void TestFindAndRetrieveItem()
        {
            linkedList = new SLL();
            var user = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            linkedList.AddLast(user);
            var foundIndex = linkedList.IndexOf(user);
            Assert.AreEqual(0, foundIndex);
            var foundUser = linkedList.GetValue(foundIndex);
            Assert.AreEqual(user, foundUser);
        }
        [Test]
        public void TestReverse()
        {
            linkedList.AddLast(user1);
            linkedList.AddLast(user2);
            linkedList.AddLast(user3);
            linkedList.Reverse();

            Assert.AreEqual(user3, linkedList.GetValue(0));
            Assert.AreEqual(user2, linkedList.GetValue(1));
            Assert.AreEqual(user1, linkedList.GetValue(2));
        }
        [Test]
        public void TestToArray()
        {
            linkedList = new SLL();
            linkedList.AddLast(user1);
            linkedList.AddLast(user2);
            linkedList.AddLast(user3);

            User[] array = linkedList.ToArray();

            Assert.AreEqual(3, array.Length);
            Assert.AreEqual(user1, array[0]);
            Assert.AreEqual(user2, array[1]);
            Assert.AreEqual(user3, array[2]);
        }
        [Test]
        public void TestJoin()
        {
            linkedList = new SLL();
            var otherList = new SLL();
            var user4 = new User(4, "Joel Osteen", "Joel Osteen@gmail.com", "password");
            var user5 = new User(4, "Osteen", "Osteen@gmail.com", "password");

            linkedList.AddLast(user1);
            linkedList.AddLast(user2);
            otherList.AddLast(user3);
            otherList.AddLast(user4);
            otherList.AddLast(user5);

            linkedList.Join(otherList);

            Assert.AreEqual(5, linkedList.Count());
            Assert.AreEqual(user1, linkedList.GetValue(0));
            Assert.AreEqual(user2, linkedList.GetValue(1));
            Assert.AreEqual(user3, linkedList.GetValue(2));
            Assert.AreEqual(user4, linkedList.GetValue(3));
            Assert.AreEqual(user5, linkedList.GetValue(4));
        }
        [Test]
        public void TestDivide()
        {
            linkedList = new SLL();
            linkedList.AddLast(user1);
            linkedList.AddLast(user2);
            linkedList.AddLast(user3);

            (SLL list1, SLL list2) = linkedList.Divide(2, linkedList);

            Assert.AreEqual(2, list1.Count());
            Assert.AreEqual(user1, list1.GetValue(0));
            Assert.AreEqual(user2, list1.GetValue(1));

            Assert.AreEqual(1, list2.Count());
            Assert.AreEqual(user3, list2.GetValue(0));
        }
    }
}

