using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior w1;
        private Warrior attacker;
        private Warrior defender;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.attacker = new Warrior("Ivan", 10, 80);
            this.defender = new Warrior("Gosho", 5, 60);

            this.w1 = new Warrior("Pesho", 40, 50);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollShouldPhysicallyAddTheWarriorToArena()
        {
            this.arena.Enroll(w1);
            Assert.That(this.arena.Warriors, Has.Member(this.w1));
        }
        [Test]
        public void EnrollShouldIncreaseCount()
        {
            int expectedCount = 2;
            this.arena.Enroll(this.w1);
            this.arena.Enroll(new Warrior("Gosho", 5, 60));
            int actualCount = this.arena.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void EnrollShouldThrowExceptionWhenAddingSameWarriorTwice()
        {
            this.arena.Enroll(this.w1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(this.w1);
            });
        }
        [Test]
        public void EnrollShouldThrowExceptionWhenAddingSameWarriorNameTwice()
        {
            Warrior w2 = new Warrior(w1.Name, w1.Damage, w1.HP);
            this.arena.Enroll(this.w1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(w2);
            });
        }

        [Test]
        public void TestFightingWithMissingAttacker()
        {
            this.arena.Enroll(defender);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Ivan", "Gosho");
            });
        }
        [Test]
        public void TestFightingWithMissingDefender()
        {
            this.arena.Enroll(attacker);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Ivan", "Gosho");
            });
        }
        [Test]
        public void TestFightingNormalCase()
        {
            this.arena.Enroll(attacker);
            int attackerExpectedHp = 75;
            int defenderExpectedHp = 50;
            this.arena.Enroll(defender);
            this.arena.Fight("Ivan", "Gosho");

            Assert.AreEqual(attackerExpectedHp, this.attacker.HP);
            Assert.AreEqual(defenderExpectedHp, this.defender.HP);
        }
    }
}