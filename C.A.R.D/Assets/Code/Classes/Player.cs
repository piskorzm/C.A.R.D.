using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public static int STARTING_CARD_AMOUNT;

    public int ID { get; private set; }
    public string Name { get; private set; }
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; public set; }

    private Deck _deck;
    private List<Card> _hand;
    private Field OwnField;
    private Field OpponentsField;

    /// <summary>
    /// Player class constructor. Draws starting cards to _hand.
    /// </summary>
    /// <param name="id">Player ID</param>
    /// <param name="name">Player name</param>
    /// <param name="health">Initial health</param>
    /// <param name="deck">Deck to use</param>
	public Player(int id, string name, int health, Deck deck)
    {
        ID = id;
        Name = name;
        MaxHealth = health;
        CurrentHealth = health;
        _deck = deck;

        //Initialise hand
        _hand = new List<Card>();

        //Draw starting cards
        for(int i = 0; i < STARTING_CARD_AMOUNT; i++)
        {
            _hand.Add(_deck.Draw());
        }
    }

    /// <summary>
    /// Passes the reference to player'ss field and the opponent's field
    /// </summary>
    /// <param name="own">Players field</param>
    /// <param name="opponents">Opponents field</param>
	public void SetFields(Field own, Field opponents)
	{
        OwnField = own;
        OpponentsField = opponents;
	}

	private void PlayCard(Card card)
	{
        if(card.GetType() == typeof(MinionCard))
        {
            OwnField.PlaceMinion(card);
        }
        else if(card.GetType() == typeof(SpellCard))
        {

        }

        _hand.Remove(card);
	}
}