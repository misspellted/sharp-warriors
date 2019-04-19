using NUnit.Framework;
using Eight;

namespace EightTests
{
    public class WarriorTests
    {
        [Test]
        public void WarriorSurvivesAttack()
        {
            Warrior tested = new Warrior("The Dude", 100, 1, 25);

            Assert.NotZero(tested.DefendAgainstAttack(50));

            Assert.NotZero(tested.HitPoints);
        }

        [Test]
        public void WarriorDoesntSurviveAttack()
        {
            Warrior tested = new Warrior("The Dude", 100, 1, 1);

            Assert.NotZero(tested.DefendAgainstAttack(101));

            Assert.Zero(tested.HitPoints);
        }

        [Test]
        public void WarriorGeneratesAttack()
        {
            Warrior tested = new Warrior("The Dude", 100, 1, 100);

            Assert.NotZero(tested.GetAttack());
        }
    }
}