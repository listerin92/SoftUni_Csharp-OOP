using System;
using NUnit.Framework;
using Database;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] initialData = new int[] { 1, 2, };
        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(initialData);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        public void TestIfConstructorWorksCorrectly(int[] data)
        {
            //Arrange
            // int[] data = new int[] { 1, 2, 3 };
            this.database = new Database.Database(data);
            //Act
            int expectedCount = data.Length;
            int actualCount = this.database.Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorShouldThrowExceptionWithLargerThan16()
        {
            int[] data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database.Database(data);
            });
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            //Arrange
            int expectedCount = 3;
            //Act
            database.Add(3); //setup state is with 2 elements
            int actualCount = this.database.Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddThrowsExceptionWhenDBFull()
        {
            //Act
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(17);
            });
        }
        [Test]
        public void RemoveShouldDecreaseCount()
        {
            //Arrange
            int expectedCount = 1;
            //Act
            database.Remove();
            int actualCount = this.database.Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDBEmpty()
        {
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
                {
                    this.database.Remove();
                }
            );
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopyOfData(int[] expectedData)
        {
            this.database = new Database.Database(expectedData);

            int[] actualData = this.database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}