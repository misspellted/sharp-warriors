using System;

namespace Eight
{
    public class Warrior
    {
        public string Name { get; private set; }
        public int HitPoints { get; private set; }
        public int AttackStrength { get; private set; }
        public int BlockingDefense { get; private set; }

        public Warrior(string name, int hitPoints, int attackStrength, int blockingDefense)
        {
            Name = name;
            HitPoints = hitPoints;
            AttackStrength = attackStrength;
            BlockingDefense = blockingDefense;
        }

        public int DefendAgainstAttack(int attack)
        {
            int blockable = new Random().Next(0, BlockingDefense);

            int blocked = Math.Min(blockable, attack);

            int damage = attack - blocked;

            HitPoints = Math.Max(0, HitPoints - damage);

            return damage;
        }

        public int GetAttack()
        {
            return new Random().Next(1, AttackStrength);
        }
    }
}
