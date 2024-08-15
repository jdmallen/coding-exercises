using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace JDMallen.CodingExercises.Sorts
{
    public static class MergeSortExtensions
    {
	    public static IList<T> MergeSort<T>(this IList<T> list)
		where T : IComparable<T>
	    {
		    // if size 1, return list
		    if (list is { Count: <= 1 })
		    {
			    return list;
		    }


		    return MergeSort(list, 0, list.Count - 1);
	    }

	    private static IList<T> MergeSort<T>(IList<T> list, int start, int end)
		where T : IComparable<T>
	    {
		    if (end - start < 2)
		    {
			    return new List<T>{list[start]};
		    }
			int middle = start + (end - start) / 2;
			var left = MergeSort(list, start, middle);
			var right = MergeSort(list, middle, end);

			var result = new List<T>(list.Count);
			int leftIndex = 0;
			int rightIndex = 0;
			int resultIndex = 0;

			while(leftIndex < left.Count && rightIndex < right.Count)
			{
				if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
				{
					result.Add(left[leftIndex]);
					leftIndex++;
				}
				else
				{
					result.Add(right[rightIndex]);
					rightIndex++;
				}
			}

			while (leftIndex < left.Count)
			{
				result.Add(left[leftIndex++]);
			}

			while (rightIndex < right.Count)
			{
				result.Add(right[rightIndex++]);
			}

			return result;
	    }
    }
}
