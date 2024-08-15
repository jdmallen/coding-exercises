using System;
using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.Sorts;

public static class Utility
{
	public static IList<T> Shuffle<T>(this IList<T> source)
	{
		var rng = new Random();
		var length = source.Count;
		for (var i = length - 1; i > 0; i--)
		{
			var randomIndex = rng.Next(0, i);

			(source[i], source[randomIndex]) = (source[randomIndex], source[i]);
		}
		return source;
	}
}
