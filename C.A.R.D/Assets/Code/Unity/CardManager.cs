﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
	public static CardManager Controller;
	private static Dictionary<int, Card> _allCards;

	void Awake()
	{
		//Check if singleton reference already exists
		if (Controller != null)
		{
			throw new Exception("Can only have one instance of the CardDictionary singleton class");
		}

		//Assign singleton reference
		Controller = this;

		//Generate cards from the json data
		LoadAllCards();

		//This object will always be present and will only be created once
		DontDestroyOnLoad(this);
	}

	/// <summary>
	/// An array of all card ids
	/// </summary>
	public int[] CardIds
	{
		get { return _allCards.Keys.ToArray(); }
	}

    /// <summary>
    /// Parses the cards json data and generates card objects from it
    /// </summary>
    private void LoadAllCards()
	{
		//Create an empty dictionary to populate with cards
		_allCards = new Dictionary<int, Card>();

		//Read card JSON data and generate a list of cards from it
		TextAsset cardDataRaw = Resources.Load<TextAsset>("Cards");
		List<Card> generatedCards = JSONReader.GenerateCardsFromJSON(cardDataRaw.text);		

		//Read the generated cards into the allCards dictionary
		foreach(Card c in generatedCards)
		{
			_allCards.Add(c.Id, c);
		}
	}

	public Card GetCardWithID(int id)
	{
		//Throw an exception if a card with the specified ID does not exist
		if(!_allCards.ContainsKey(id))
		{
			throw new KeyNotFoundException("Can't find card with ID: " + id);
		}

		//Return the desired card
		return _allCards[id];
	}

	public Card GetRandomCard()
	{
		return _allCards[CardIds.PickRandom()];
	}
}
