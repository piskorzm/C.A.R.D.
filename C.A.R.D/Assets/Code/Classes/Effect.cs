public class Effect {

    public TargetType Target { get; private set; }
    public int Damage { get; private set; }

    public Effect(TargetType t, int damage)
    {
        Target = t;
        Damage = damage;
    }

	public override bool Equals(object obj)
	{
		//If the other object is not an effect, return false
		if(obj.GetType() != typeof(Effect))
		{
			return false;
		}

		//Check that the target type and damage are the same on the other effect
		Effect other = (Effect)obj;
		return other.Target == Target && other.Damage == Damage;
	}

	public static bool operator == (Effect a, Effect b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Effect a, Effect b)
	{
		return !a.Equals(b);
	}

	public override int GetHashCode()
	{
		return int.Parse(((int)Target).ToString() + Damage.ToString());
	}
}
