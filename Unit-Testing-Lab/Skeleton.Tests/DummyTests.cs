using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy aliveDummy;
    private Dummy deadDummy;
    private const int Experience = 200;
    private const int AttackedPoints = 30;
    private const int AliveDummyHealthPoints = 100;
    private const int DeadDummyHealthPoints = 0;
    [SetUp]
    public void SetDummies()
    {
        //Arrange
        this.aliveDummy = new Dummy(AliveDummyHealthPoints, Experience);
        this.deadDummy = new Dummy(DeadDummyHealthPoints, Experience);
    }

    [Test]
    public void DummyShouldLoseHealthIfAttacked()
    {
        //Act
        this.aliveDummy.TakeAttack(AttackedPoints);

        //Assert
        Assert.That(this.aliveDummy.Health, Is.EqualTo(70));
    }
    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        //Assert
        Assert.That(() =>
                this.deadDummy.TakeAttack(AttackedPoints), //Act
            Throws.InvalidOperationException
                .With.Message.EqualTo("Dummy is dead."), "Dead targets cannot be attacked");
    }
    
    [Test]
    public void DeadDummyGiveExperience()
    {
        //Act
        var experience = this.deadDummy.GiveExperience();

        //Assert
        Assert.That(experience, Is.EqualTo(experience));
    }
    
    [Test]
    public void AliveDummyNotGiveExperience()
    {
        //Assert
        Assert.That(() =>
                this.aliveDummy.GiveExperience(), //Act
            Throws.InvalidOperationException
                .With.Message.EqualTo("Target is not dead."));
    }
}