public class MinionCard : Card {

    public int Health { get; private set; }
    public int Damage { get; private set; }

	public MinionCard(string name, string desc, int cost, int health, int damage) : base(name, desc, cost)
    {
        Health = health;
        Damage = damage;
    }
}
