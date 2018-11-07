using System.Collections.Generic;

public class Deck
{
	public const int MAX_CARDS = 10;

	protected List<Card> _cards;

	public Deck() : this(new List<Card>()) { }

	public Deck(List<Card> cards)
	{
		_cards = cards;
		Shuffle();
	}

	/// <summary>
	/// Draw the top card and removes it from the deck
	/// </summary>
	/// <returns>Card drawn</returns>
	public Card Draw()
	{
		if (_cards.Count != 0)
		{
			Card toDraw = _cards[0];
			_cards.RemoveAt(0);
			return toDraw;
		}
		else
		{
			return null;
		}
	}

	/// <summary>
	/// Shuffles the deck
	/// </summary>
	public void Shuffle()
	{
		_cards.Shuffle();
	}

	public override bool Equals(object obj)
	{
		//Return false if the other object is not a deck
		if (obj.GetType() != typeof(Deck))
		{
			return false;
		}
		else
		{
			//Obtain a reference to the other deck
			Deck other = (Deck)obj;

			//Return false immediately if both decks do not have the same number of cards
			if (other.CardsLeft != CardsLeft)
			{
				return false;
			}

			//Cycle through all the cards in each deck and check that they are equal
			for (int i = 0; i < CardsLeft; i++)
			{
				if (_cards[i] != other._cards[i])
				{
					return false;
				}
			}

			//Return true if all cards are equal
			return true;
		}
	}

    /// <summary>
    /// Gets the sum of the card IDs in the deck, as the result giving a unique ID for the deck, given they all have the sasme number of cards.
    /// </summary>
    /// <returns>int IDSum</returns>
	public override int GetHashCode()
	{
		int IDSum = 0;

		foreach (Card c in _cards)
		{
			IDSum += c.Id;
		}

		return IDSum;
	}

    /// <summary>
    /// Gets the number of cards left in the deck
    /// </summary>
	public int CardsLeft
	{
		get { return _cards.Count; }
	}
}
