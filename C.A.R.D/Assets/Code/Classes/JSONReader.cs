using System.Collections.Generic;
using UnityEngine;
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

		//Extract spell cards
		List<object> spellCards = (List<object>)cardData["spellCards"];

		//Iterate through every spell card
		foreach (object card in spellCards)
		{
			Dictionary<string, object> currentCardData = (Dictionary<string, object>)card;

			//Extract name
			string name = (string)currentCardData["name"];

			//Extract rarity
			string rarityText = (string)currentCardData["rarity"];
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
					throw new Exception("Invalid rarity in json data for card: " + name);
			}

			//Extract description
			string description = (string)currentCardData["description"];

			//Extract cost
			int cost = (int)currentCardData["cost"];

			//Extract image path
			string imagePath = (string)currentCardData["path"];

			//Extract effects
			List<Effect> effects = new List<Effect>();
			List<object> effectData = (List<object>)currentCardData["effects"];

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
						throw new Exception("Invalid target type in json data for card: " + name + ", target type is: " + targetTypeText);
				}

				//Extract damage
				int damage = (int)currentEffectData["damage"];

				//Add the effect to the list of effects for this card
				effects.Add(new Effect(targetType, damage));
			}

			//Create a new spellcard from the parsed json data
			SpellCard newCard = new SpellCard(name, rarity, description, cost, imagePath, effects);

			//Add the spell card to the dictionary of all cards
			generatedCards.Add(newCard);
		}

		//TODO - Minion cards

		//Return the list of generated cards
		return generatedCards;
	}
}
