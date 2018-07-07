using System.Collections;
using System.Collections.Generic;

public abstract class Card {

    public int Id { get; private set; }
    public string Name { get; private set; }
	public Rarity CardRarity { get; private set; }  
    public string Description { get; private set; }
    public int Cost { get; private set; }
    public string ImagePath { get; private set; }

    public Card(int id, string name, Rarity rarity, string desc, int cost, string imagePath)
    {
        Id = id;
        Name = name;
		CardRarity = rarity;
        Description = desc;
        Cost = cost;
        ImagePath = imagePath;
    }

	public override bool Equals(object obj)
	{
		//Return false if the other object is not a Card
		if (obj.GetType() != typeof(Card))
		{
			return false;
		}
		else
		{
			//If the IDs of both cards are equal, then return true, otherwise return false
			return ((Card)obj).Id == Id;
		}
	}

	public override int GetHashCode()
	{
		return Id;
	}
}
