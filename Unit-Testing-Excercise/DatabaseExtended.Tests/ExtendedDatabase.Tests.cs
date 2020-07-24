using System;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private Person[] persons = new Person[]
        {
            new Person(1, "Ivan"),
            new Person(2, "Petkan"),
            new Person(3, "Dragan"),
        };

        [SetUp]
        public void Setup()
        {
            this.database = new ExtendedDatabase.ExtendedDatabase(persons);

        }

        [Test]
        public void TestInitializeConstructor()
        {
            this.database = new ExtendedDatabase.ExtendedDatabase(persons);

            int expectedCount = 3;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void ConstructorAddRangeShouldThrowExceptionWithLargerThan16()
        {
            Person[] fullPersons = new Person[]
            {
                new Person(1, "Ivan"), new Person(1, "Ivan"), new Person(1, "Ivan"), new Person(1, "Ivan"),
                new Person(1, "Ivan"), new Person(1, "Ivan"), new Person(1, "Ivan"), new Person(1, "Ivan"),
                new Person(1, "Ivan"), new Person(1, "Ivan"), new Person(1, "Ivan"), new Person(1, "Ivan"),
                new Person(1, "Ivan"), new Person(1, "Ivan"), new Person(1, "Ivan"), new Person(1, "Ivan"),
                new Person(1, "Ivan")
        };
            Assert.Throws<ArgumentException>(() =>
            {
                this.database = new ExtendedDatabase.ExtendedDatabase(fullPersons);
            });

        }
        [Test]
        public void AddShouldIncreaseCount()
        {
            //Arrange
            int expectedCount = 4;
            //Act
            database.Add(new Person(4, "Stefan")); //setup state is with 2 elements
            int actualCount = this.database.Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void AddShouldThrowExceptionWhenUserNotUnique()
        {
            Person person = new Person(4, "Stefan");
            this.database.Add(person);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(person);

            });
        }
        [Test]
        public void AddShouldThrowExceptionWhenIdNotUnique()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person person2 = new Person(1, "Pesho");
                this.database.Add(person2);

            });
        }
        [Test]
        public void AddShouldThrowExceptionWhenTryToAddMoreThan16()
        {
            Person person = null;

            for (int i = 4; i <= 16; i++)
            {
                person = new Person(i, $"Dragan{i}");
                this.database.Add(person);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person lastPerson = new Person(16, "asdf");
                this.database.Add(lastPerson);
            });
        }
        [Test]
        public void RemoveShouldDecreaseCount()
        {
            //Arrange
            int expectedCount = 2;
            //Act
            this.database.Remove(); //setup state is with 2 elements
            int actualCount = this.database.Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void RemoveShouldThrowExceptionWhenCountGoesZero()
        {
            database.Remove();
            database.Remove();
            database.Remove();
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }
        [Test]
        public void FindByUsernameIsNullCheck()
        {
            string name = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.database.FindByUsername(name);
            });
        }
        [Test]
        public void FindByUsernameIsEmptyCheck()
        {
            string name = "";
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.database.FindByUsername(name);
            });
        }
        [Test]
        public void FindByUserThrowsExceptionWhenUserNotFound()
        {
            string name = "ivan";
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindByUsername(name);
            });
        }
        [Test]
        public void FindByUserUserFound()
        {
            string expectecName = "Ivan2";
            Person newPerson = new Person(4, expectecName);
            this.database.Add(newPerson);

            Person actualPerson = this.database.FindByUsername(expectecName);
            Assert.AreEqual(expectecName, actualPerson.UserName);
        }
        [Test]
        public void FindByIdThrowsExceptionWhenIdIsNegative()
        {
            int id = -10;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.database.FindById(id);
            });
        }
        [Test]
        public void FindByIdThrowsExceptionWhenIdNotFound()
        {
            int id = 10;
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindById(id);
            });
        }
        [Test]
        public void FindByIdFound()
        {
            int expectedID = 4;
            Person newPerson = new Person(expectedID, "Ivan2");
            this.database.Add(newPerson);

            Person actualPerson = this.database.FindById(expectedID);
            Assert.AreEqual(expectedID, actualPerson.Id);
        }

        [Test]
        public void CompareTwoPersonArrays()
        {
            var expected = this.persons;
            Person[] actual = new Person[3];
            actual[0] = database.FindById(1);
            actual[1] = database.FindById(2);
            actual[2] = database.FindById(3);


            CollectionAssert.AreEqual(expected, actual);
        }
    }
}