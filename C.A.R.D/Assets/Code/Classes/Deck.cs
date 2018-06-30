using System.Collections.Generic;

public class Deck {

    public const int MAX_CARDS = 10;

    private List<Card> _cards;

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
        Card toDraw = _cards[0];
        _cards.RemoveAt(0);
        return toDraw;
    }

    /// <summary>
    /// Shuffles the deck
    /// </summary>
    public void Shuffle()
    {
        _cards.Shuffle();
    }
}
