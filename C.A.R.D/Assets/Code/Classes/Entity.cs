using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity {

	public int MaxHealth { get; private set; }
	public int CurrentHealth { get; private set; }
	public int Attack { get; private set; }

	public Entity(int maxHealth, int currentHealth, int attack)
	{
		MaxHealth = maxHealth;
		CurrentHealth = currentHealth;
		Attack = attack;
	}

	/// <summary>
	/// Inflicts an amount of damage on this entity
	/// </summary>
	/// <param name="amount">The amount of damage to inflict</param>
	public void TakeDamage(int amount)
	{
		//Take damage equal to amount, cap at 0
		CurrentHealth = Mathf.Max(CurrentHealth - amount, 0);
	}
}
