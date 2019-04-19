using System;
using System.Collections.Generic;
using System.Text;

namespace Eight
{
    public class Fight
    {
        public Warrior One { get; private set; }
        public Warrior Two { get; private set; }

        public List<string> AttackHistory { get; private set; } = new List<string>();

        public Fight(Warrior one, Warrior two)
        {
            One = one;
            Two = two;
        }

        public void Attack(Warrior attacker, Warrior defender)
        {
            int damage = defender.DefendAgainstAttack(attacker.GetAttack());

            AttackHistory.Add(string.Format("{0} attacked {1}, dealing {2} damage.", attacker.Name, defender.Name, damage));

            // If the attacking warrior defeated the defending warrior, add that to the history as well.
            // Otherwise, add the remaining hit points to the history.
            switch (defender.HitPoints)
            {
                case 0:
                    AttackHistory.Add(string.Format("{0} has been defeated.", defender.Name));
                    break;
                case 1:
                    AttackHistory.Add(string.Format("{0} is barely clinging to life.", defender.Name, defender.HitPoints));
                    break;
                default:
                    AttackHistory.Add(string.Format("{0} has {1} hit points left.", defender.Name, defender.HitPoints));
                    break;
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
