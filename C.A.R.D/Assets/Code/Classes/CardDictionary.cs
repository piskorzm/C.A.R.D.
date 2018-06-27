using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MiniJSON;

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

    public string[] CardNames
    {
        get { return _allCards.Keys.ToArray(); }
    }

    private void GenerateCards()
    {
		
        // TODO - MAKE IMAGES FOR ALL THESE CARDS

        //Spells
        SpellCard smallRock = new SpellCard("Small Rock", Rarity.LEGENDARY, "It's a small rock!", 0, "SmallRock.png", new Effect(TargetType.TARGET, 1));
        _allCards.Add(smallRock.Name, smallRock);

        SpellCard bigRock = new SpellCard("Big Rock", Rarity.LEGENDARY, "It's a BIG rock!", 2, "BigRock.png", new Effect(TargetType.TARGET, 3));
        _allCards.Add(bigRock.Name, bigRock);

        SpellCard moterunner = new SpellCard("Moterunner", Rarity.LEGENDARY, "Gives cancer to your opponent", 10, "Moterunner.png", new Effect(TargetType.TARGET, 100));
        _allCards.Add(moterunner.Name, moterunner);

        //Minions
        MinionCard spikeyMikey = new MinionCard("Spikey Mikey", Rarity.LEGENDARY, "Watch out, he is spikey", 5, "SpikeyMikey.png", 11, 1);
        _allCards.Add(spikeyMikey.Name, spikeyMikey);

        MinionCard fano = new MinionCard("Fano", Rarity.LEGENDARY, "Fano is just not very good", 10, "Fano.png", 0, 1);
        _allCards.Add(fano.Name, fano);

        MinionCard drPlump = new MinionCard("Dr.Plump", Rarity.LEGENDARY, "Destroys opponets moral status", 4, "DrPlump.png", 6, 4);
        _allCards.Add(drPlump.Name, drPlump);

        MinionCard angryGoose = new MinionCard("Angry Goose", Rarity.LEGENDARY, "Beter start running now!", 3, "AngryGoose.png", 4, 3);
        _allCards.Add(angryGoose.Name, angryGoose);
    }
}
