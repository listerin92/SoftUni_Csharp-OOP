using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Dummy target;

    [SetUp]
    public void SetDummy() => this.target = new Dummy(100, 500);
    [Test]
    public void AxeShouldLooseDurabilityAfterAttack()
    {
        //Arrange
        var axe = new Axe(10, 5);
        //Act
        axe.Attack(this.target);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(4));
    }
    [Test]
    public void AttackWithBrokenWeapon()
    {

        //Arrange
        var axe = new Axe(10, 0);

        //Assert
        Assert.That(() => axe.Attack(this.target), //Act
            Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
    }
}