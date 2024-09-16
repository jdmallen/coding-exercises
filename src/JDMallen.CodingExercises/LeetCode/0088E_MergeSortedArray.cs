using System;

namespace JDMallen.CodingExercises.LeetCode;

public class MergeSortedArray
{
	public void Merge(int[] nums1, int m, int[] nums2, int n)
	{
		for (int i = m; i < nums1.Length; i++)
		{
			nums1[i] = nums2[i - m];
		}

		Array.Sort(nums1);
	}

	public void MergeOptimized(int[] nums1, int m, int[] nums2, int n)
	{
		if (m == 0)
		{
			nums1 = nums2;

			return;
		}

		if (n == 0)
		{
			return;
		}

		var result = new int[m + n];

		var length = Math.Max(nums1.Length, nums2.Length);
		var longerLength = length;
		for (int i = 0; i < longerLength; i++)
		{
			if (i == nums1.Length || i == nums2.Length)
			{
				break; // avoid index out of array errors
			}

			if (nums1[i] <= nums2[i])
			{
				result[i] = nums1[i];
				result[i+1] = nums2[i];
			}
		}

		nums1 = result;
	}
}
