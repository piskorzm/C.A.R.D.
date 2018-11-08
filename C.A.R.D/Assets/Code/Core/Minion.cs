using System;
using System.Collections.Generic;

public class Minion : Entity
{
    public MinionCard Card;

	public Minion(MinionCard card) : base(card.Health, card.Health, card.Attack)
    {
        Card = card;
    }

    public void AttackEntity(Entity target)
    {
		target.TakeDamage(Attack);
        TakeDamage(target.Attack);
    }
}