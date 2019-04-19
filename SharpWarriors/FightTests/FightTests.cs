using NUnit.Framework;
using Eight;

namespace EightTests
{
    class FightTests : IFightSubscriber
    {
        // OnAttack data.
        private Warrior attacker;
        private Warrior defender;
        private int attack;
        private int damage;

        // OnDefeat data.
        private Warrior defeated;

        // OnSurvive data.
        private Warrior survivor;

        [SetUp]
        public void Prepare()
        {
            // Reset anything modified by subscriber notifications.
            attacker = null;
            defender = null;
            attack = -1;
            damage = -1;

            defeated = null;

            survivor = null;
        }

        [Test]
        public void AttackDefeatsDefender()
        {
            Warrior one = new Warrior("Derek", 1, 1, 0);
            Warrior two = new Warrior("Banas", 1, 0, 0); // Don't block, to garauntee death.

            Fight tested = new Fight(one, two);

            // Subscribe to notifications.
            tested.AddSubscriber(this);

            tested.Attack(one, two);

            // The attack notification will be sent to subscribers.
            Assert.AreEqual(one, attacker);
            Assert.AreEqual(two, defender);
            Assert.NotZero(attack);
            Assert.Greater(damage, -1);

            // The defeat nofication will be sent to subscribers.
            Assert.AreEqual(two, defeated);

            // The survivor notification will not be sent to subscribers.
            Assert.IsNull(survivor);
        }

        [Test]
        public void DefenderSurvivesAttack()
        {
            Warrior one = new Warrior("Derek", 100, 10, 10);
            Warrior two = new Warrior("Banas", 100, 10, 10);

            Fight tested = new Fight(one, two);

            // Subscribe to notifications.
            tested.AddSubscriber(this);

            tested.Attack(one, two);

            // The attack notification will be sent to subscribers.
            Assert.AreEqual(one, attacker);
            Assert.AreEqual(two, defender);
            Assert.NotZero(attack);
            Assert.Greater(damage, -1);

            // The defeat nofication will not be sent to subscribers.
            Assert.IsNull(defeated);

            // The survivor notification will be sent to subscribers.
            Assert.AreEqual(two, survivor);
        }

        [Test]
        public void WarriorsFightToTheDeath()
        {
            Warrior one = new Warrior("Derek", 100, 10, 10);
            Warrior two = new Warrior("Banas", 100, 10, 10);

            Fight tested = new Fight(one, two);

            // Subscribe to notifications.
            tested.AddSubscriber(this);

            tested.Start();

            // The defeat notification will be sent at the end of the fight.
            Assert.IsNotNull(defeated);
        }

        // Utilize the subscriber interface to verify subscriber notifications.
        // Yes, I know there's something called mocking. I haven't learned how to translate my Java TestNG/Mockito
        // knowledge over yet. Soon (tm).

        public void OnAttack(Warrior attacker, Warrior defender, int attack, int damage)
        {
            this.attacker = attacker;
            this.defender = defender;
            this.attack = attack;
            this.damage = damage;
        }

        public void OnDefeat(Warrior defeated)
        {
            this.defeated = defeated;
        }

        public void OnSurvive(Warrior survivor)
        {
            this.survivor = survivor;
        }
    }
}
