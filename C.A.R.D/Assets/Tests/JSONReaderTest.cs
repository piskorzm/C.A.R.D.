using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;

public class JSONReaderTest {

	private const string OneSpellCardJSON = "{\"spellCards\": [{\"name\": \"Small Rock\",\"rarity\": \"Common\",\"description\": \"It's a small rock\",\"cost\": 0,\"path\": \"SmallRock\",\"effects\": [	{\"targetType\": \"Target\",\"damage\": 1}]}],\"minionCards\":[]}";

	[Test]
	public void ReadOneSpellCardJSON()
	{
		//Read the one spell card json data and generate a list of cards from it, which should contain only one card
		List<Card> cards = JSONReader.GenerateCardsFromJSON(OneSpellCardJSON);

		//Ensure the length of this card list is one
		Assert.AreEqual(1, cards.Count);

		//Ensure the card was generated correctly
		Assert.AreEqual("Small Rock", cards[0].Name);
	}
}
