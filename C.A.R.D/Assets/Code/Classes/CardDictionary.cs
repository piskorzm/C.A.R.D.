using System;
using System.Collections;
using System.Collections.Generic;

public class CardDictionary {

    private static CardDictionary _controller;
    private static Dictionary<string, Card> _allCards;

    public CardDictionary()
    {
        if(_controller != null)
        {
            throw new Exception("Can only have one instance of a singleton class");
        }

        //Assign singleton reference
        _controller = this;

        //Generate cards
        GenerateCards();
    }

    private void GenerateCards()
    {
        SpellCard smallRock = new SpellCard("Small Rock", "It's a small rock!", 0, new Effect(TargetType.TARGET, 1));

        _allCards.Add(AllCards.SmallRock, smallRock);
    }
}
