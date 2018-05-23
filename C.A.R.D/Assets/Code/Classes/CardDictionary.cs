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
        SpellCard smallRock = new SpellCard(AllCards.SmallRock, "It's a small rock!", 0, new Effect(TargetType.TARGET, 1));
        _allCards.Add(AllCards.SmallRock, smallRock);

        SpellCard bigRock = new SpellCard(AllCards.BigRock, "It's a BIG rock!", 0, new Effect(TargetType.TARGET, 3));
        _allCards.Add(AllCards.BigRock, bigRock);

        MinionCard spikeyMikey = new MinionCard(AllCards.SpikeyMikey, "Watch out, he is spikey.", 4, 11, 1);
        _allCards.Add(AllCards.SpikeyMikey, bigRock);

        MinionCard fano = new MinionCard(AllCards.Fano, "Fano is just not very good.", 10, 0, 1);
        _allCards.Add(AllCards.Fano, fano);
    }
}
