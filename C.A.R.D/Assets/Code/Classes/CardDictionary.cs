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

        SpellCard bigRock = new SpellCard(AllCards.BigRock, "It's a BIG rock!", 2, new Effect(TargetType.TARGET, 3));
        _allCards.Add(AllCards.BigRock, bigRock);

        SpellCard moteRunner = new SpellCard(AllCards.MoteRunner, "Gives cancer to your opponent", 10, new Effect(TargetType.TARGET, 100));
        _allCards.Add(AllCards.MoteRunner, moteRunner);


        MinionCard spikeyMikey = new MinionCard(AllCards.SpikeyMikey, "Watch out, he is spikey", 5, 11, 1);
        _allCards.Add(AllCards.SpikeyMikey, spikeyMikey);

        MinionCard fano = new MinionCard(AllCards.Fano, "Fano is just not very good", 10, 0, 1);
        _allCards.Add(AllCards.Fano, fano);

        //TODO add "HAHAHA, it's so easy" on play
        MinionCard drPlump = new MinionCard(AllCards.DrPlump, "Destroys opponets moral status", 4, 6, 4);
        _allCards.Add(AllCards.DrPlump, drPlump);

        MinionCard angryGoose = new MinionCard(AllCards.AngryGoose, "Beter start running now!", 3, 4, 3);
        _allCards.Add(AllCards.AngryGoose, angryGoose);
    }
}
