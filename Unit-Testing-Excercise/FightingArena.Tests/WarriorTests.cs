using System;
using System.Diagnostics.CodeAnalysis;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 50;
            int expectedHP = 100;
            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHP = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHP, actualHP);
        }
        [Test]
        public void TestIncorrectNameNull()
        {
            string name = null;
            int damage = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
                {
                    Warrior warrior = new Warrior(name, damage, hp);
                }
                );
        }
        [Test]
        public void TestIncorrectNameWhiteSpace()
        {
            string name2 = " ";
            int damage = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
                {
                    Warrior warrior = new Warrior(name2, damage, hp);
                }
            );
        }
        [Test]
        public void TestIncorrectNameEmptyString()
        {
            string name3 = string.Empty;
            int damage = 50;
            int hp = 100;
            Assert.Throws<ArgumentException>(() =>
                {
                    Warrior warrior = new Warrior(name3, damage, hp);
                }
            );
        }
        [Test]
        public void TestWithZeroDamage()
        {
            string name = "Pesho";
            int damage = 0;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
                {
                    Warrior warrior = new Warrior(name, damage, hp);
                }
            );
        }
        [Test]
        public void TestWithNegativeDamage()
        {
            string name = "Pesho";
            int damage = -10;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
                {
                    Warrior warrior = new Warrior(name, damage, hp);
                }
            );
        }
        [Test]
        public void TestWithNegativeHp()
        {
            string name = "Pesho";
            int damage = 50;
            int hp = -100;

            Assert.Throws<ArgumentException>(() =>
                {
                    Warrior warrior = new Warrior(name, damage, hp);
                }
            );
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void TestAttackEnemyWithLowerThan30HPException(int attackerHP)
        {
            string attackerName = "Pesho";
            int attackerDamage = 10;
            Warrior attackerWarrior = new Warrior(attackerName, attackerDamage, attackerHP);

            string enemyName = "Gosho";
            int enemyDamage = 10;
            int enemyHP = 40;
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attackerWarrior.Attack(enemyWarrior);
            });
        }
        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void TestEnemyWithLowerThan30HPException(int enemyHP)
        {
            string attackerName = "Pesho";
            int attackerHP = 40;
            int attackerDamage = 10;
            Warrior attackerWarrior = new Warrior(attackerName, attackerDamage, attackerHP);

            string enemyName = "Gosho";
            int enemyDamage = 10;
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attackerWarrior.Attack(enemyWarrior);
            });
        }

        [Test]
        public void TestAttackTooStrongEnemyException()
        {
            string attackerName = "Pesho";
            int attackerDamage = 50;
            int attackerHP = 40;
            Warrior attackerWarrior = new Warrior(attackerName, attackerDamage, attackerHP);

            string enemyName = "Gosho";
            int enemyDamage = 1000;
            int enemyHP = 40;
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attackerWarrior.Attack(enemyWarrior);
            });
        }

        [Test]
        [TestCase(20)]
        [TestCase(36)]
        public void TestNormalAttack(int attackerDamage)
        {
            string attackerName = "Pesho";
            //int attackerDamage = 50;
            int attackerHP = 40;
            Warrior attackerWarrior = new Warrior(attackerName, attackerDamage, attackerHP);

            string enemyName = "Gosho";
            int enemyDamage = 30;
            int enemyHP = 35;
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHP);

            int expectedAttackerHp = attackerHP - enemyDamage;

            attackerWarrior.Attack(enemyWarrior);


            Assert.That(expectedAttackerHp == attackerWarrior.HP);
        }
    }
}