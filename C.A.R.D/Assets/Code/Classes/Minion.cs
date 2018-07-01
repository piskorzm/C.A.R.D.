using System;
using System.Collections.Generic;

public class Minion
{
    public MinionCard Card;
    public int MaxHealth;
    public int CurrentHealth;
    public int Attack;
    
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