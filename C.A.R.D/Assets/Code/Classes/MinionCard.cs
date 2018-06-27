public class MinionCard : Card {

    public int Health { get; private set; }
    public int Attack { get; private set; }

	public MinionCard(string name, Rarity rar, string desc, int cost, string imagePath, int health, int attack) : base(name, rar, desc, cost, imagePath)
    {
        Health = health;
        Attack = attack;
    }
}
