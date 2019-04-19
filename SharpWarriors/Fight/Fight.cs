using System.Collections.Generic;

namespace Eight
{
    public class Fight : IFightSubscriber
    {
        public Warrior One { get; private set; }
        public Warrior Two { get; private set; }

        private readonly List<IFightSubscriber> fightSubscribers;

        public Fight(Warrior one, Warrior two)
        {
            One = one;
            Two = two;

            fightSubscribers = new List<IFightSubscriber>();
        }

        public void AddSubscriber(IFightSubscriber fightSubscriber)
        {
            fightSubscribers.Add(fightSubscriber);
        }

        public void OnAttack(Warrior attacker, Warrior defender, int attack, int damage)
        {
            // Notify any subscribers.
            fightSubscribers.ForEach(fightSubscriber => fightSubscriber.OnAttack(attacker, defender, attack, damage));
        }

        public void OnDefeat(Warrior defeated)
        {
            // Notify any subscribers.
            fightSubscribers.ForEach(fightSubscriber => fightSubscriber.OnDefeat(defeated));
        }

        public void OnSurvive(Warrior surviving)
        {
            // Nofity any subscribers.
            fightSubscribers.ForEach(fightSubscriber => fightSubscriber.OnSurvive(surviving));
        }

        public void Attack(Warrior attacker, Warrior defender)
        {
            int attack = attacker.GetAttack();
            int damage = defender.DefendAgainstAttack(attack);

            OnAttack(attacker, defender, attack, damage);

            // Check for defeat of the defender.
            if (defender.HitPoints == 0)
            {
                OnDefeat(defender);
            }
            else
            {
                OnSurvive(defender);
            }
        }

        public void Start()
        {
            // The fight will be back and forth, starting with warrior one attacking warrior two.
            // The fight ends when the hit points of either warrior reaches zero (0).
            while (0 < One.HitPoints && 0 < Two.HitPoints)
            {
                // Warrior one attacks warrior two.
                Attack(One, Two);
                
                // If warrior two survives, they attack warrior one.
                if (0 < Two.HitPoints)
                {
                    Attack(Two, One);
                }
            }
        }
    }
}
