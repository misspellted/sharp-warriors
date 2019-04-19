using System;

namespace Eight
{
    // This covers the eighth entry in Derek Banas' C# tutorial video series on YouTube:
    // https://www.youtube.com/watch?v=decfmj7b5Vg&list=PLGLfVvz_LVvRX6xK1oi0reKci6ignjdSa&index=8
    // Pop Quiz: Have 2 Warriors Fight to the Death.

    class ConsoleFightSubscriber : IFightSubscriber
    {
        public void OnAttack(Warrior attacker, Warrior defender, int attack, int damage)
        {
            Console.WriteLine($"{attacker.Name} attacked {defender.Name}, with {attack}, dealing {damage} damage.");
            Console.WriteLine();
        }

        public void OnDefeat(Warrior defeated)
        {
            Console.WriteLine($"{defeated.Name} has been defeated.");
            Console.WriteLine();
        }

        public void OnSurvive(Warrior surviving)
        {
            // Call out the criticalness of the surviver, because why not?
            if (surviving.HitPoints == 1)
            {
                Console.WriteLine($"{surviving.Name} is barely clinging to life.");
            }
            else
            {
                Console.WriteLine($"{surviving.Name} has {surviving.HitPoints} hit points left.");
            }

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Warrior one = new Warrior("Derek", 100, 10, 10);
            Warrior two = new Warrior("Banas", 100, 10, 10);

            Fight fight = new Fight(one, two);

            fight.AddSubscriber(new ConsoleFightSubscriber());

            fight.Start();

            // Allow the viewer to actually see the attack history, without the window closing first.
            Console.ReadLine();
        }
    }
}
