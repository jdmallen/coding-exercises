namespace JDMallen.CodingExercises.LeetCode;

public class LongestSubstringWithoutRepeatingCharacters
{
	public int LengthOfLongestSubstring(string s)
	{
		var longest = string.Empty;
		var subString = string.Empty;

		foreach (char c in s)
		{
			if (subString.Contains(c))
			{
				subString = subString.Substring(subString.IndexOf(c) + 1);
			}

			subString += c;

			longest = subString.Length > longest.Length ? subString : longest;
		}

		longest = subString.Length > longest.Length ? subString : longest;

		return longest.Length;
	}
}
