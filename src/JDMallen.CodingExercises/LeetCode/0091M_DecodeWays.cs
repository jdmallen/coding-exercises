using System.Linq;
using JDMallen.CodingExercises.LeetCode.Shared;

namespace JDMallen.CodingExercises.LeetCode;

public class DecodeWays
{
	public int NumDecodings(string s)
	{
		int[] dp = Enumerable.Repeat(0, s.Length + 1).ToArray();

		// if (s.Length == 0)
		// {
		// 	return 1;
		// }
		//
		// if (s.Length == 1)
		// {
		// 	return s[0] != '0' ? 1 : 0;
		// }

		dp[0] = 1;
		dp[1] = s[0] != '0' ? 1 : 0;

		for (var i = 2; i < s.Length + 1; i++)
		{
			int singleSub = UtilityMethods.Atoi(s.Substring(i - 1, 1));
			int doubleSub = UtilityMethods.Atoi(s.Substring(i - 2, 2));

			if (doubleSub >= 10 && doubleSub <= 26)
			{
				dp[i] += dp[i - 2];
			}

			if (singleSub != 0)
			{
				dp[i] += dp[i - 1];
			}
		}

		return dp[s.Length];
	}
}
