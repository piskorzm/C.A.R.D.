using System;
using System.Collections.Generic;

public class Field
{
    public List<Minion> _minions;

    public Field()
    {

    }

    public void PlaceMinion(MinionCard card)
    {
        Minion newMinion = new Minion(card);

        _minions.Add(newMinion);
    }
}
