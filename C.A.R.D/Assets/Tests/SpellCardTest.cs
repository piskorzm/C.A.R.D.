using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class SpellCardTest {

	[Test]
	public void CreateSpellCardTestOneEffect()
	{
		//Create individual components of a spell card
		string name = "Curse";
		Rarity rarity = Rarity.RARE;
		string description = "Does a very nice curse";
		int cost = 1;
		string imagePath = "curse";
		Effect effect = new Effect(TargetType.TARGET, 3);

		//Create a spell card
		SpellCard testCard = new SpellCard(name, rarity, description, cost, imagePath, effect);

		//Ensure that the spell card was created correctly
		Assert.AreEqual(name, testCard.Name);
		Assert.AreEqual(rarity, testCard.CardRarity);
		Assert.AreEqual(description, testCard.Description);
		Assert.AreEqual(cost, testCard.Cost);
		Assert.AreEqual(imagePath, testCard.ImagePath);
		Assert.AreEqual(effect, testCard.GetEffect(0));
	}
}
