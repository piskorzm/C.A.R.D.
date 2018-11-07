using System;
using System.Collections.Generic;
using System.Linq;

public static class CollectionExtension
{
	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
	{
		return source.OrderBy(x => Guid.NewGuid()).ToList();
	}

	public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
	{
		return source.Shuffle().Take(count);
	}

	public static T PickRandom<T>(this IEnumerable<T> source)
	{
		return source.PickRandom(1).Single();
	}
}