using System.Linq;
using System.Text;

namespace JDMallen.CodingExercises.LeetCode;

public class LargestPalindromicNumber
{
	public string LargestPalindromic(string num)
	{
		if (num.All(c => c == '0'))
		{
			return "0";
		}

		var freqArray = new int[10];

		// count everything
		foreach (char c in num)
		{
			freqArray[c - '0']++;
		}

		var firstHalf = new StringBuilder();
		var middle = '\0';

		for (var i = 9; i >= 0; i--)
		{
			if (freqArray[i] > 1)
			{
				for (var j = 0; j < freqArray[i] / 2; j++)
				{
					firstHalf.Append((char)('0' + i));
				}

				freqArray[i] %= 2;
			}

			if (freqArray[i] == 1 && middle == '\0')
			{
				middle = (char)('0' + i);
			}
		}

		// clear leading zeros

		var trimmedFirstHalf = new StringBuilder();
		var leadingZero = false;
		for (var i = 0; i < firstHalf.Length; i++)
		{
			if ((i == 0 || leadingZero) && firstHalf[i] == '0')
			{
				leadingZero = true;
			}
			else
			{
				leadingZero = false;
				trimmedFirstHalf.Append(firstHalf[i]);
			}
		}

		firstHalf = trimmedFirstHalf;

		var secondHalf = new StringBuilder();
		for (int i = firstHalf.Length - 1; i >= 0; i--)
		{
			secondHalf.Append(firstHalf[i]);
		}

		return $"{firstHalf}{(middle == '\0' ? "" : middle)}{secondHalf}";
	}
}
