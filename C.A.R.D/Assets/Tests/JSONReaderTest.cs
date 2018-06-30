using NUnit.Framework;
using System.Collections.Generic;

public class JSONReaderTest {

	private const string OneSpellCardJSON = "{\"spellCards\": [{\"id\": 0,\"name\": \"Small Rock\",\"rarity\": \"Common\",\"description\": \"It's a small rock\",\"cost\": 0,\"path\": \"SmallRock\",\"effects\": [	{\"targetType\": \"Target\",\"damage\": 1}]}],\"minionCards\":[]}";
	private const string OneMinionCardJSON = "{\"spellCards\": [],\"minionCards\":[{\"id\": 1,\"name\": \"Spikey Mikey\",\"rarity\": \"Rare\",\"description\": \"Watch out, he is spikey\",\"cost\": 5,\"path\": \"SpikeyMikey\",\"attack\": 11,\"health\": 1}]}";

	[Test]
	public void ReadOneSpellCardJSON()
	{
		//Read the one spell card json data and generate a list of cards from it, which should contain only one card
		List<Card> cards = JSONReader.GenerateCardsFromJSON(OneSpellCardJSON);

		//Ensure the length of this card list is two
		Assert.AreEqual(1, cards.Count);

		//Ensure the cards were generated correctly
		Assert.AreEqual("Small Rock", cards[0].Name);
	}

    [Test]
    public void ReadOneMinionCardJSON()
    {
        //Read the one spell card json data and generate a list of cards from it, which should contain only one card
        List<Card> cards = JSONReader.GenerateCardsFromJSON(OneMinionCardJSON);

        //Ensure the length of this card list is two
        Assert.AreEqual(1, cards.Count);

        //Ensure the cards were generated correctly
        Assert.AreEqual("Spikey Mikey", cards[0].Name);
    }
}
