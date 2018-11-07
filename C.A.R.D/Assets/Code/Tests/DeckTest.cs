using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class DeckTest {

    //Card objects to be used in the tests
    MinionCard card1 = new MinionCard(0, "minion card", Rarity.UNCOMMON, "description", 1, "imagePath", 1, 1);
    SpellCard card2 = new SpellCard(1, "spell card", Rarity.RARE, "description", 2, "imagePath", new Effect(TargetType.OPPONENT, 1));

    //Check if the Deck constructor without parameters works correctly
    [Test]
    public void CreateEmptyDeckTest()
    {
        Deck deck = new Deck();

        Assert.AreEqual(0, deck.CardsLeft);
    }

    //Check if the Deck constructor given a list of Card objects works correctly
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

        //Shuffeled flag
        bool deckShuffeled = false;
        //Upper limit of shuffles to be performed, where the chance of failing, given that the Shuffle method works correctly is equal to 2^shuffleLimit
        int shuffleLimit = 100;

        for(int i = 0; i < shuffleLimit; i++)
        {
            deck.Shuffle();
            //Set the flag to true if the order of cards has changed. Exit the loop
            if (GetCardsFromDeck(deck)[0] != card1)
            {
                deckShuffeled = true;
                i = shuffleLimit;
            }
        }

        Assert.IsTrue(deckShuffeled);
    }

    //Drawing from an empty deck should return null
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

        //Unshuffle the deck if needed 
        while (GetCardsFromDeck(deck)[0] != card1)
        {
            deck.Shuffle();
        }

        Card drawnCard = deck.Draw();

        //Check if the number of cards in the deck has been reduced
        Assert.AreEqual(cards.Count - 1, deck.CardsLeft);
        //Check if the drawn card is equal to the first card in the deck
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

        //Checking if an object of a different type is equal to a deck should return false
        Assert.IsFalse(deck1.Equals(nonDeckTypeObject));
        //Checking if a deck is equal to a deck with different number of cards should return false
        Assert.IsFalse(deck1.Equals(emptyDeck));

        //Shuffle if needed, so both decks have their cards in the same order
        while (GetCardsFromDeck(deck1)[0] != GetCardsFromDeck(deck2)[0])
        {
            deck1.Shuffle();
        }

        //Chacking against a deck with containing the same cards in same order should return true
        Assert.IsTrue(deck1.Equals(deck2));

        //Shuffle if needed, so both decks have their cards in a different order
        while (GetCardsFromDeck(deck1)[0] == GetCardsFromDeck(deck2)[0])
        {
            deck1.Shuffle();
        }

        //Chacking against a deck containing the same cards in a different order should return false
        Assert.IsFalse(deck1.Equals(deck2));
    }

    //Function used to access the _cards List reference of a given deck for testing purposes
    public List<Card> GetCardsFromDeck (Deck deck)
    {
        return (List<Card>)typeof(Deck).GetField("_cards", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(deck);
    }

}
