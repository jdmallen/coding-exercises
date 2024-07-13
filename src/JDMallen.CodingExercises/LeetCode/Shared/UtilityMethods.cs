using System;

namespace JDMallen.CodingExercises.LeetCode.Shared;

public class UtilityMethods
{
	public static int Atoi(string s)
	{
		var temp = 0;
		for (var i = 0; i < s.Length; i++)
		{
			char c = s[i];
			int pow = s.Length - i - 1;
			temp += (int)Math.Pow(10, pow) * (c - '0');
		}

		return temp;
	}
}
