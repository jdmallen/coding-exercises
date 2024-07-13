﻿using System.Linq;
using System.Text;

namespace JDMallen.CodingExercises.LeetCode;

public class LargestNumberFormedFromIntegers
{
	/// <summary>
	/// Given a list of non-negative integers nums, arrange them such that they form the largest number and return it.
	/// 
	/// Since the result may be very large, so you need to return a string instead of an integer.
	///
	/// Example 1:
	/// 
	/// Input: nums = [10,2]
	/// Output: "210"
	/// Example 2:
	/// 
	/// Input: nums = [3,30,34,5,9]
	/// Output: "9534330"
	/// 
	/// 
	/// Constraints:
	/// 
	/// 1 &lt;= nums.length &lt;= 100
	/// 0 &lt;= nums[i] &lt;= 109
	/// </summary>
	/// <param name="nums"></param>
	/// <returns></returns>
	public string LargestNumber(int[] nums)
	{
		if (nums.Length == 1)
		{
			return nums[0].ToString();
		}

		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = nums.Length - 1; j >= 1; j--)
			{
				var left = nums[j - 1].ToString();
				var right = nums[j].ToString();
				var cat1 = left + right;
				var cat2 = right + left;

				// reeeeally hate doing a 3rd for-loop here
				for (int k = 0; k < cat1.Length; k++)
				{
					var catLeft = cat1[k] - '0';
					var catRight = cat2[k] - '0';
					if (catRight - '0' > catLeft - '0')
					{
						(nums[j], nums[j - 1]) = (nums[j - 1], nums[j]);

						break;
					}

					if (catRight - '0' < catLeft - '0')
					{
						break;
					}
				}
			}
		}

		var answer = string.Join("", nums);

		if (answer.All(c => c == '0'))
		{
			return "0";
		}

		// trim leading zeros
		var trimmedAnswer = new StringBuilder();
		var leadingZero = false;
		for (var i = 0; i < answer.Length; i++)
		{
			if ((i == 0 || leadingZero) && answer[i] == '0')
			{
				leadingZero = true;
			}
			else
			{
				leadingZero = false;
				trimmedAnswer.Append(answer[i]);
			}
		}

		return trimmedAnswer.ToString();
	}
}
