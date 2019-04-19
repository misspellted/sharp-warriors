using NUnit.Framework;
using Eight;

namespace EightTests
{
    class FightTests
    {
        [Test]
        public void AttackDefeatsDefender()
        {
            Warrior one = new Warrior("Derek", 100, 10, 10);
            Warrior two = new Warrior("Banas", 1, 100, 1);

            Fight tested = new Fight(one, two);

            tested.Attack(one, two);

            Assert.Zero(two.HitPoints);
        }

        [Test]
        public void DefenderSurvivesAttack()
        {
            Warrior one = new Warrior("Derek", 100, 10, 10);
            Warrior two = new Warrior("Banas", 100, 10, 10);

            Fight tested = new Fight(one, two);

            tested.Attack(one, two);

            Assert.NotZero(two.HitPoints);
        }

        [Test]
        public void WarriorsFightToTheDeath()
        {
            Warrior one = new Warrior("Derek", 100, 10, 10);
            Warrior two = new Warrior("Banas", 100, 10, 10);

            Fight tested = new Fight(one, two);

            tested.Start();

            Assert.True(one.HitPoints == 0 || two.HitPoints == 0);
        }

        [Test]
        public void NoAttackHistoryWithoutAFight()
        {
            Warrior one = new Warrior("Derek", 100, 10, 10);
            Warrior two = new Warrior("Banas", 100, 10, 10);

            Fight tested = new Fight(one, two);

            Assert.IsEmpty(tested.AttackHistory);
        }

        [Test]
        public void FightGeneratesAttackHistory()
        {
            Warrior one = new Warrior("Derek", 100, 10, 10);
            Warrior two = new Warrior("Banas", 100, 10, 10);

            Fight tested = new Fight(one, two);

            tested.Start();

            Assert.IsNotEmpty(tested.AttackHistory);
            Assert.True(tested.AttackHistory[tested.AttackHistory.Count - 1].Contains("defeated"));
        }
    }
}
