using MiniJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
	private static CardManager _controller;
	private static Dictionary<string, Card> _allCards;

	void Awake()
	{
		//Check if singleton reference already exists
		if (_controller != null)
		{
			throw new Exception("Can only have one instance of the CardDictionary singleton class");
		}

		//Assign singleton reference
		_controller = this;

		//Generate cards from the json data
		GenerateCardsFromJSON();

		//This object will always be present and will only be created once
		DontDestroyOnLoad(this);
	}

	/// <summary>
	/// An array of all card names
	/// </summary>
	public string[] CardNames
	{
		get { return _allCards.Keys.ToArray(); }
	}

	/// <summary>
	/// Parses the cards json data and generates card objects from it
	/// </summary>
	private void GenerateCardsFromJSON()
	{
		//Read card data and deserialize
		TextAsset cardDataRaw = Resources.Load<TextAsset>("Cards");
		Dictionary<string, object> cardData = (Dictionary<string, object>)Json.Deserialize(cardDataRaw.text);

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
			_allCards.Add(newCard.Name, newCard);
		}

		//TODO - Minion cards
	}
}
