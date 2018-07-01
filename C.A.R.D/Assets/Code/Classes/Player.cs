using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	public const int STARTING_CARD_AMOUNT = 5; 

	public int Id { get; private set; }
	public string Name { get; private set; }

	public Deck Deck;
	public List<Card> Hand;
	public Field OwnField;
	public Field OpponentsField;

	/// <summary>
	/// Player class constructor. Draws starting cards to <see cref="_hand"/>
	/// </summary>
	/// <param name="id">Player ID</param>
	/// <param name="name">Player name</param>
	/// <param name="health">Initial health</param>
	/// <param name="deck">Deck to use</param>
	public Player(int id, string name, int health, Deck deck) : base(health, health, 0)
	{
		Id = id;
		Name = name;

		Deck = deck;

		//Initialise hand
		Hand = new List<Card>();

		//Draw starting cards
		for (int i = 0; i < STARTING_CARD_AMOUNT; i++)
		{
            Card cardToDraw = Deck.Draw();
            if (cardToDraw != null)
            {
                Hand.Add(Deck.Draw());
            }
		}
	}

	/// <summary>
	/// Passes the reference to player's field and the opponent's field
	/// </summary>
	/// <param name="own">Players field</param>
	/// <param name="opponents">Opponents field</param>
	public void SetFields(Field own, Field opponents)
	{
		OwnField = own;
		OpponentsField = opponents;
	}

	public void PlayCard(Card card)
	{
		if (card.GetType() == typeof(MinionCard))
		{
			OwnField.PlaceMinion((MinionCard)card);
		}
		else if (card.GetType() == typeof(SpellCard))
		{

		}

		Hand.Remove(card);
	}
}