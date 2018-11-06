using System;
using System.Collections.Generic;

public class SpellCard : Card
{
	private List<Effect> _effects;

	public SpellCard(int id, string name, Rarity rar, string desc, int cost, string imagePath, Effect effect) : base(id, name, rar, desc, cost, imagePath)
	{
		_effects = new List<Effect>();
		_effects.Add(effect);
	}

	public SpellCard(int id, string name, Rarity rar, string desc, int cost, string imagePath, List<Effect> effects) : base(id, name, rar, desc, cost, imagePath)
	{
		_effects = effects;
	}

	public int EffectCount
	{
		get
		{
			return _effects.Count;
		}
	}

	public Effect GetEffect(int index)
	{
		if(index >= EffectCount)
		{
			throw new IndexOutOfRangeException("Effect does not exist at index: " + index);
		}

		return _effects[index];
	}
}