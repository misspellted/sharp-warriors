namespace Eight
{
    public interface IFightSubscriber
    {
        void OnAttack(Warrior attacker, Warrior defender, int attack, int damage);

        void OnDefeat(Warrior defeated);

        void OnSurvive(Warrior surviving);
    }
}
