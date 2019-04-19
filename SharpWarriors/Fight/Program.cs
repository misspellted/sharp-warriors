using System;

namespace Eight
{
    // This covers the eighth entry in Derek Banas' C# tutorial video series on YouTube:
    // https://www.youtube.com/watch?v=decfmj7b5Vg&list=PLGLfVvz_LVvRX6xK1oi0reKci6ignjdSa&index=8
    // Pop Quiz: Have 2 Warriors Fight to the Death.

    class Program
    {
        static void Main(string[] args)
        {
            Warrior one = new Warrior("Derek", 100, 10, 10);
            Warrior two = new Warrior("Banas", 100, 10, 10);

            Fight fight = new Fight(one, two);

            fight.Start();

            // Inform the viewer of the attack history as well as the winner.
            foreach (string message in fight.AttackHistory)
            {
                Console.WriteLine(message);
                Console.WriteLine();
            }

            // Allow the viewer to actually see the attack history, without the window closing first.
            Console.ReadLine();
        }
    }
}
