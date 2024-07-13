using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.LeetCode;

public class MergeIntervals
{
	public int[][] Merge(int[][] intervals)
	{
		var result = new List<int[]>();

		// first, sort the intervals by start, then by end
		intervals = intervals.OrderBy(interval => interval[0])
			.ThenBy(interval => interval[1])
			.ToArray();

		for (var i = 0; i < intervals.Length; i++)
		{
			int start = intervals[i][0];
			int end = intervals[i][1];
			if (start == -1) // visited; skip
			{
				continue;
			}

			for (int j = i + 1; j < intervals.Length; j++)
			{
				int startNext = intervals[j][0];
				int endNext = intervals[j][1];
				if (startNext == -1 || startNext > end || endNext < start) // skip
				{
					continue;
				}

				if (startNext >= start && endNext <= end) // entirely contained; mark and skip
				{
					intervals[j][0] = -1;
				}

				if (startNext < start) // connected to beginning; mark and extend
				{
					start = startNext;
					intervals[j][0] = -1;
				}

				if (endNext > end) // connected to end; mark and extend
				{
					end = endNext;
					intervals[j][0] = -1;
				}
			}

			result.Add(new[] { start, end });
		}

		return result.ToArray();
	}
}
