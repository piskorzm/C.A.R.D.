using System.Collections.Generic;
using MiniJSON;
using System;

/// <summary>
/// Class used to generate cards from JSON data
/// </summary>
public static class JSONReader {

	/// <summary>
	/// Takes a JSON string as input and uses it to generate a list of cards
	/// </summary>
	/// <param name="jsonText">The input JSON string</param>
	/// <returns>A list of cards generated from the JSON string</returns>
	public static List<Card> GenerateCardsFromJSON(string jsonText)
	{
		//Create an empty list of cards, which will be populated with the generated cards
		List<Card> generatedCards = new List<Card>();

		//Deserialise the JSON string
		Dictionary<string, object> cardData = (Dictionary<string, object>)Json.Deserialize(jsonText);

		//Extract spell and minion cards
		List<object> spellCards = (List<object>)cardData["spellCards"];
        List<object> minionCards = (List<object>)cardData["minionCards"];

		//Iterate through every spell card
		foreach (object card in spellCards)
		{
            //Get json data of the card
			Dictionary<string, object> currentCardData = (Dictionary<string, object>)card;

            //Set individual components of the card
            string name = ExtractName(currentCardData);
            Rarity rarity = ExtractRarity(currentCardData);
            string description = ExtractDescription(currentCardData);
            int cost = ExtractCost(currentCardData);
            string imagePath = ExtractImagePath(currentCardData);
            List<Effect> effects = ExtractEffects(currentCardData);

			//Create a new spellcard from the parsed json data
			SpellCard newCard = new SpellCard(name, rarity, description, cost, imagePath, effects);

			//Add the spell card to the dictionary of all cards
			generatedCards.Add(newCard);
		}

        foreach (object card in minionCards)
        {
            //Get json data of the card
            Dictionary<string, object> currentCardData = (Dictionary<string, object>)card;

            //Set individual components of the card
            string name = ExtractName(currentCardData);
            Rarity rarity = ExtractRarity(currentCardData);
            string description = ExtractDescription(currentCardData);
            int cost = ExtractCost(currentCardData);
            string imagePath = ExtractImagePath(currentCardData);
            int health = ExtractHealth(currentCardData);
            int attack = ExtractAttack(currentCardData);

            //Create a new spellcard from the parsed json data
            MinionCard newCard = new MinionCard(name, rarity, description, cost, imagePath, health, attack);

            //Add the spell card to the dictionary of all cards
            generatedCards.Add(newCard);
        }

        //Return the list of generated cards
        return generatedCards;
	}

    private static string ExtractName(Dictionary<string, object> cardData)
    {
        return (string)cardData["name"];
    }

    private static Rarity ExtractRarity(Dictionary<string, object> cardData)
    {
        string rarityText = (string)cardData["rarity"];
        Rarity rarity;

        switch (rarityText)
        {
            case "Common":
                rarity = Rarity.COMMON;
                break;
            case "Uncommon":
                rarity = Rarity.UNCOMMON;
                break;
            case "Rare":
                rarity = Rarity.RARE;
                break;
            case "Epic":
                rarity = Rarity.EPIC;
                break;
            case "Legendary":
                rarity = Rarity.LEGENDARY;
                break;
            default:
                throw new Exception("Invalid rarity in json data for card: " + (string)cardData["name"]);
        }
        return rarity;
    }

    private static string ExtractDescription(Dictionary<string, object> cardData)
    {
        return (string)cardData["description"];
    }

    //MiniJSON treats ints as longs, hence the double casts
    private static int ExtractCost(Dictionary<string, object> cardData)
    {
        return (int)((long)cardData["cost"]);
    }

    private static string ExtractImagePath(Dictionary<string, object> cardData)
    {
        return (string)cardData["path"];
    }

    private static int ExtractHealth(Dictionary<string, object> cardData)
    {
        return (int)((long)cardData["health"]);
    }

    private static int ExtractAttack(Dictionary<string, object> cardData)
    {
        return (int)((long)cardData["attack"]);
    }

    private static List<Effect> ExtractEffects(Dictionary<string, object> cardData)
    {
        List<Effect> effects = new List<Effect>();
        List<object> effectData = (List<object>)cardData["effects"];

        //Iterate through every effect
        foreach (object effect in effects)
        {
            Dictionary<string, object> currentEffectData = (Dictionary<string, object>)effect;

            //Extract target type
            string targetTypeText = (string)currentEffectData["targetType"];
            TargetType targetType;

            switch (targetTypeText)
            {
                case "Self":
                    targetType = TargetType.SELF;
                    break;
                case "Opponent":
                    targetType = TargetType.OPPONENT;
                    break;
                case "Target":
                    targetType = TargetType.TARGET;
                    break;
                case "All":
                    targetType = TargetType.ALL;
                    break;
                default:
                    throw new Exception("Invalid target type in json data for card: " + (string)cardData["name"] + ", target type is: " + targetTypeText);
            }

            //Extract damage
            int damage = (int)currentEffectData["damage"];

            //Add the effect to the list of effects for this card
            effects.Add(new Effect(targetType, damage));
        }

        return effects;
    }
}