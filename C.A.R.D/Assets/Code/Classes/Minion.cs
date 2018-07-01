using System;
using System.Collections.Generic;

public class Minion
{
    public MinionCard Card;
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
	public int Attack { get; private set; }

	public Minion (MinionCard card)
    {
        Card = card;
        MaxHealth = card.Health;
        CurrentHealth = card.Health;
        Attack = card.Attack;
    }

    public void AttackMinion(Minion targetMinion)
    {
        targetMinion.CurrentHealth -= Attack;
    }

    public void AttackPlayer(Player targetPlayer)
    {
        targetPlayer.CurrentHealth -= Attack;
    }
}