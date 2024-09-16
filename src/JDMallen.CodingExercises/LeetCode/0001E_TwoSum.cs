using System;

namespace JDMallen.CodingExercises.LeetCode;

public class TwoSumToTarget
{
	public int[] TwoSum(int[] nums, int target)
	{
		// first, rule out the case where a zero exists
		var zeroIndex = Array.FindIndex(nums, x => x == 0);
		if (zeroIndex > -1)
		{
			var targetIndex = Array.FindIndex(nums, x => x == target);

			return [zeroIndex, targetIndex];
		}
		
		// sort the array, and come in from two ends
		Array.Sort(nums);

		int startPointer = 0, endPointer = nums.Length - 1, middle = nums.Length / 2;

		bool Check()
		{
			return nums[startPointer] + nums[endPointer] == target;
		}

		while (!Check() && startPointer <= middle && endPointer > middle)
		{
			startPointer++;
			if (Check())
			{
				return [startPointer, endPointer];
			}
			endPointer--;
			if (Check())
			{
				return [startPointer, endPointer];
			}
		}

		// shouldn't reach here
		return [startPointer, endPointer];
	}
}
