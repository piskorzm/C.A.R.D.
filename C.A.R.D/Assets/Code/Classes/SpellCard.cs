using System.Collections.Generic;

public class SpellCard : Card {

    private List<Effect> _effects;

    public SpellCard(string name, string desc, int cost, Effect effect) : base(name, desc, cost)
    {
        _effects = new List<Effect>();
        _effects.Add(effect);
    }

    public SpellCard(string name, string desc, int cost, List<Effect> effects) : base(name, desc, cost)
    {
        _effects = effects;
    }
}