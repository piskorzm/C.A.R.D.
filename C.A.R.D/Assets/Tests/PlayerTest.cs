using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class PlayerTest {

    //Create cards list to be used for testing
    private static MinionCard minionTestCard = new MinionCard(1, "Ghost", Rarity.RARE, "Is spooky", 3, "ghost", 3, 3);
    private static SpellCard spellTestCard = new SpellCard(2, "Curse", Rarity.RARE, "Does a very nice curse", 1, "curse", new Effect(TargetType.TARGET, 3));
    private static List<Card> cards = new List<Card> { minionTestCard, spellTestCard };

    //Declare a Player instance to be used for testing
    private static Player player;

	//Player fields to be initialised with
	private int id = 1;
	private string name = "The Destroyer";
	private int health = 100;

	[SetUp]
	public void SetupTest()
	{
		//Create individual components of a player
		int id = 1;
		string name = "The Destroyer";
		int health = 100;
		Deck deck = new Deck(cards);

		//Create a player
		player = new Player(id, name, health, deck);
	}

    [Test]
    public void CreatePlayerTest()
    {
        //Ensure that the player was created correctly
        Assert.AreEqual(id, player.Id);
        Assert.AreEqual(name, player.Name);
        Assert.AreEqual(health, player.MaxHealth);
        Assert.AreEqual(health, player.CurrentHealth);

		//Ensure that the deck is empty as a result of drawing
        Assert.AreEqual(new Deck(), player.Deck);
        Assert.AreEqual(0, player.Deck.CardsLeft);

		//Ensure that the player now has 2 different cards in their hand
        Assert.AreEqual(2, player.Hand.Count);
		Card c1 = player.Hand[0];
		Card c2 = player.Hand[1];
		Assert.AreNotEqual(c1, c2);
    }

    [Test]
    public void SetFieldsTest()
    {
        //Set the fields for the player
        //player.SetFields(ownField, opponentsField);
        

        //TODO check if fields have been set correctly (private)
    }

    [Test]
    public void PlayMinionCardTest()
    {
        player.PlayCard(minionTestCard);

        //Check if the hand cound has been decremented
        Assert.AreEqual(1, player.Hand.Count);

        //Check if the field contains a minion
        Assert.AreEqual(1, player.OwnField.Minions.Count);
    }
}
