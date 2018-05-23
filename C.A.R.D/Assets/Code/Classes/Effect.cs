using System.Collections;
using System.Collections.Generic;

public class Effect {

    public TargetType Target { get; private set; }
    public int Damage { get; private set; }

    public Effect(TargetType t, int damage)
    {
        Target = t;
        Damage = damage;
    }
}
