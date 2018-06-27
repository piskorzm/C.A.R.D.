public class MinionCard : Card {

    public int Health { get; private set; }
    public int Damage { get; private set; }

	public MinionCard(string name, Rarity rar, string desc, int cost, string imagePath, int health, int damage) : base(name, rar, desc, cost, imagePath)
    {
        Health = health;
        Damage = damage;
    }
}
