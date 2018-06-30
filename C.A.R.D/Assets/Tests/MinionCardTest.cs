using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MinionCardTest {

    [Test]
    public void CreateMinionCardTest()
    {
        //Create individual components of a minion card
        string name = "Ghost";
        Rarity rarity = Rarity.RARE;
        string description = "Is spooky";
        int cost = 3;
        string imagePath = "ghost";
        int health = 3;
        int attack = 3;

        //Create a minion card
        MinionCard testCard = new MinionCard(name, rarity, description, cost, imagePath, health, attack);

        //Ensure that the spell card was created correctly
        Assert.AreEqual(name, testCard.Name);
        Assert.AreEqual(rarity, testCard.CardRarity);
        Assert.AreEqual(description, testCard.Description);
        Assert.AreEqual(cost, testCard.Cost);
        Assert.AreEqual(imagePath, testCard.ImagePath);
        Assert.AreEqual(health, testCard.Health);
        Assert.AreEqual(attack, testCard.Attack);
    }
}
