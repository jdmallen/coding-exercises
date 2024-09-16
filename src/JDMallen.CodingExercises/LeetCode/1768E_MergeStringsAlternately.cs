using System;
using System.Text;

namespace JDMallen.CodingExercises.LeetCode;

public class MergeStringsAlternately
{
	public string MergeAlternately(string word1, string word2)
	{
		var sb = new StringBuilder();
		int p1 = 0, p2 = 0;
		int longerWordLength = Math.Max(word1.Length, word2.Length);

		for (var i = 0; i < longerWordLength; i++)
		{
			if (i < word1.Length)
			{

				sb.Append(word1[i]);
			}

			if (i < word2.Length)
			{
				sb.Append(word2[i]);
			}
		}

		return sb.ToString();
	}
}
