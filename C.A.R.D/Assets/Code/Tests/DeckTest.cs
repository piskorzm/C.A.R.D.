﻿using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class DeckTest {

    MinionCard card1 = new MinionCard(0, "minion card", Rarity.UNCOMMON, "description", 1, "imagePath", 1, 1);
    SpellCard card2 = new SpellCard(1, "spell card", Rarity.RARE, "description", 2, "imagePath", new Effect(TargetType.OPPONENT, 1));

    [Test]
    public void CreateEmptyDeckTest()
    {
        Deck deck = new Deck();

        Assert.AreEqual(0, deck.CardsLeft);
    }

    [Test]
    public void CreateDeckTest()
    {
        List<Card> cards = new List<Card>();
        cards.Add(card1);
        cards.Add(card2);

        Deck deck = new Deck(cards);

        Assert.AreEqual(cards.Count, deck.CardsLeft);
        Assert.Contains(card1, GetCardsFromDeck(deck));
        Assert.Contains(card2, GetCardsFromDeck(deck));
    }

    [Test]
    public void ShuffleDeckTest()
    {
        List<Card> cards = new List<Card>();
        cards.Add(card1);
        cards.Add(card2);

        Deck deck = new Deck(cards);

        bool deckShuffeled = false;
        int checkLimit = 100;

        for(int i = 0; i < checkLimit; i++)
        {
            deck.Shuffle();
            if (GetCardsFromDeck(deck)[0] != card1)
            {
                deckShuffeled = true;
                i = checkLimit;
            }
        }

        Assert.IsTrue(deckShuffeled);
    }

    [Test]
    public void DrawFromEmptyDeckTest()
    {
        Deck deck = new Deck();

        Card drawnCard = deck.Draw();

        Assert.IsNull(drawnCard);
    }

    [Test]
    public void DrawFromDeckTest()
    {
        List<Card> cards = new List<Card>();
        cards.Add(card1);
        cards.Add(card2);

        Deck deck = new Deck(cards);

        while (GetCardsFromDeck(deck)[0] != card1)
        {
            deck.Shuffle();
        }

        Card drawnCard = deck.Draw();

        Assert.AreEqual(cards.Count - 1, deck.CardsLeft);
        Assert.AreEqual(card1, drawnCard);
    }

    [Test]
    public void DeckEqualTest()
    {
        List<Card> cards1 = new List<Card>();
        cards1.Add(card1);
        cards1.Add(card2);

        List<Card> cards2 = new List<Card>();
        cards2.Add(card1);
        cards2.Add(card2);

        Deck deck1 = new Deck(cards1);
        Deck deck2 = new Deck(cards2);
        Deck emptyDeck = new Deck();
        Card nonDeckTypeObject = card1;


        Assert.IsFalse(deck1.Equals(nonDeckTypeObject));
        Assert.IsFalse(deck1.Equals(emptyDeck));

        while (GetCardsFromDeck(deck1)[0] != GetCardsFromDeck(deck2)[0])
        {
            deck1.Shuffle();
        }

        Assert.IsTrue(deck1.Equals(deck2));

        while (GetCardsFromDeck(deck1)[0] == GetCardsFromDeck(deck2)[0])
        {
            deck1.Shuffle();
        }

        Assert.IsFalse(deck1.Equals(deck2));
    }

    public List<Card> GetCardsFromDeck (Deck deck)
    {
        return (List<Card>)typeof(Deck).GetField("_cards", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(deck);
    }

}
