public class MinionCard : Card {

    public int Health { get; private set; }
    public int Attack { get; private set; }

	public MinionCard(int id, string name, Rarity rar, string desc, int cost, string imagePath, int health, int attack) : base(id, name, rar, desc, cost, imagePath)
    {
        Health = health;
        Attack = attack;
    }
}
