using Moq;
using NUnit.Framework;
using Skeleton;
using Skeleton.Tests;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroShouldGainExperienceIfTargetDies()
    {
        const int experience = 200;
        //Arrange
        var fakeWeapon = Mock.Of<IWeapon>();
        var hero = new Hero("Test Hero", fakeWeapon);
        var fakeTarget = new Mock<ITarget>();
        fakeTarget
            .Setup(t => t.IsDead())
            .Returns(true);
        fakeTarget
            .Setup(t => t.GiveExperience())
            .Returns(experience);

        //Act
        hero.Attack(fakeTarget.Object);

        //Assert
        Assert.That(hero.Experience, Is.EqualTo(experience));
    }
}