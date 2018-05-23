using System.Collections.Generic;

public class Deck {

    public const int MAX_CARDS = 10;

    private List<Card> _cards;

    public Deck(List<Card> cards)
    {
        _cards = cards;
        Shuffle();
    }

    public Card Draw()
    {
        Card toDraw = _cards[0];
        _cards.RemoveAt(0);
        return toDraw;
    }

    public void Shuffle()
    {
        _cards.Shuffle();
    }
}
