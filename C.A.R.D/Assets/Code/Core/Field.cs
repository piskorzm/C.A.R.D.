using System;
using System.Collections.Generic;

/// <summary>
/// An object used for storing minions under the control of a specific player
/// </summary>
public class Field
{
	/// <summary>
	/// A list of all minions in this field
	/// </summary>
    public List<Minion> Minions { get; private set; }

	/// <summary>
	/// The maximum allowed number of minions in a field
	/// </summary>
	private const int MAX_MINIONS = 7;

	/// <summary>
	/// Creates a new field object
	/// </summary>
    public Field()
    {
		Minions = new List<Minion>();
    }

	/// <summary>
	/// Places a minion on the field, using a <see cref="MinionCard"/>, if possible
	/// </summary>
	/// <param name="card">The card to make a minion for</param>
	/// <returns>True if the minion was placed on the field, false if the field was full</returns>
    public bool PlaceMinion(MinionCard card)
    {
		//Create a minion from the MinionCard
        Minion newMinion = new Minion(card);

		//Add the minion to the list of minions in this field, if the field is not full
		if(Minions.Count == MAX_MINIONS)
		{
			return false;
		}
		else if(Minions.Count > MAX_MINIONS)
		{
			throw new Exception("Field contains: " + Minions.Count + " minions, this should not be possible...");
		}

		//If the field has space, add the minion to it and return true
		Minions.Add(newMinion);
		return true;
    }

	/// <summary>
	/// The amount of minions present in this field
	/// </summary>
	public int ContainedMinions
	{
		get
		{
			return Minions.Count;
		}
	}
}
