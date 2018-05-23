using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public static int STARTING_CARD_COUNT;

    public int ID { get; private set; }
    public string Name { get; private set; }
    public int Health { get; private set; }

    private Deck _deck;
    private List<Card> _hand;

	public Player(int id, string name, int health, Deck deck)
    {
        ID = id;
        Name = name;
        Health = health;
        _deck = deck;

        //Initialise hand
        _hand = new List<Card>();

        //Draw starting cards
        for(int i = 0; i < STARTING_CARD_COUNT; i++)
        {
            _hand.Add(_deck.Draw());
        }
    }
}
