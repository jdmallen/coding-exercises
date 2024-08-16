using System;
using System.Linq;

namespace JDMallen.CodingExercises.LeetCode;

public class ReorderedPowerOfTwo
{
	public bool ReorderedPowerOf2(int n)
	{
		// 10e9 is the cap, and log_2 of 10e9 is 33 and change
		var powersOf2 = Enumerable.Range(0, 34)
			.Select<int,string>(x =>
			{
				char[] arr = Math.Pow(2, x).ToString().ToCharArray();
				Array.Sort(arr);
				return new string(arr);
			});

		var str = n.ToString().ToCharArray();
		Array.Sort(str);

		return powersOf2.Contains(new string(str));
	}
}
