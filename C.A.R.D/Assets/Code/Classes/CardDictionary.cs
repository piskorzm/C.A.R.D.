using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MiniJSON;
using UnityEngine;

public class CardDictionary
{
	private static CardDictionary _controller;
	private static Dictionary<string, Card> _allCards;

	public CardDictionary()
	{
		if (_controller != null)
		{
			throw new Exception("Can only have one instance of a singleton class");
		}

		//Assign singleton reference
		_controller = this;

		//Generate cards
		GenerateCards();
	}

	public string[] CardNames
	{
		get { return _allCards.Keys.ToArray(); }
	}

	private void GenerateCards()
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
	////Spells
	//SpellCard smallRock = new SpellCard("Small Rock", Rarity.LEGENDARY, "It's a small rock!", 0, "SmallRock.png", new Effect(TargetType.TARGET, 1));
	//_allCards.Add(smallRock.Name, smallRock);

	//SpellCard bigRock = new SpellCard("Big Rock", Rarity.LEGENDARY, "It's a BIG rock!", 2, "BigRock.png", new Effect(TargetType.TARGET, 3));
	//_allCards.Add(bigRock.Name, bigRock);

	//SpellCard moterunner = new SpellCard("Moterunner", Rarity.LEGENDARY, "Gives cancer to your opponent", 10, "Moterunner.png", new Effect(TargetType.TARGET, 100));
	//_allCards.Add(moterunner.Name, moterunner);

	////Minions
	//MinionCard spikeyMikey = new MinionCard("Spikey Mikey", Rarity.LEGENDARY, "Watch out, he is spikey", 5, "SpikeyMikey.png", 11, 1);
	//_allCards.Add(spikeyMikey.Name, spikeyMikey);

	//MinionCard fano = new MinionCard("Fano", Rarity.LEGENDARY, "Fano is just not very good", 10, "Fano.png", 0, 1);
	//_allCards.Add(fano.Name, fano);

	//MinionCard drPlump = new MinionCard("Dr.Plump", Rarity.LEGENDARY, "Destroys opponets moral status", 4, "DrPlump.png", 6, 4);
	//_allCards.Add(drPlump.Name, drPlump);

	//MinionCard angryGoose = new MinionCard("Angry Goose", Rarity.LEGENDARY, "Beter start running now!", 3, "AngryGoose.png", 4, 3);
	//_allCards.Add(angryGoose.Name, angryGoose);
}
}
