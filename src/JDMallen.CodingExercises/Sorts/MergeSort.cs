using System;
using System.Collections.Generic;

namespace JDMallen.CodingExercises.Sorts
{
    public static class MergeSortExtensions
    {
	    public static List<T> MergeSort<T>(this IList<T> list)
		where T : IComparable<T>
	    {
		    if (list is { Count: <= 1 })
		    {
			    return new List<T>(list);
		    }


		    return MergeSort(list, 0, list.Count);
	    }

	    private static List<T> MergeSort<T>(IList<T> list, int start, int end)
		where T : IComparable<T>
	    {
		    if (end - start < 2)
		    {
			    var retList = new List<T> { list[start] };
			    return retList;
		    }

			int middle = start + (end - start) / 2;
			List<T> left = MergeSort(list, start, middle);
			List<T> right = MergeSort(list, middle, end);

			var result = new List<T>();
			var leftIndex = 0;
			var rightIndex = 0;
			var resultIndex = 0;

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
