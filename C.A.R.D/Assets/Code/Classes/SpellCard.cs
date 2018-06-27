using System.Collections.Generic;

public class SpellCard : Card {

    private List<Effect> _effects;

    public SpellCard(string name, Rarity rar, string desc, int cost, string imagePath, Effect effect) : base(name, rar, desc, cost, imagePath)
    {
        _effects = new List<Effect>();
        _effects.Add(effect);
    }

    public SpellCard(string name, Rarity rar, string desc, int cost, string imagePath, List<Effect> effects) : base(name, rar, desc, cost, imagePath)
    {
        _effects = effects;
    }
}