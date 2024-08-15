using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.LeetCode;

public class MeetingRoomsII
{
	/// <summary>
	/// Given an array of meeting time intervals intervals where intervals[i] = [start_i, end_i],
	/// return the minimum number of conference rooms required.
	///
	/// 
	///
	///	Example 1:
	///
	///	Input: intervals = [[0,30],[5,10],[15,20]]
	///	Output: 2
	///	Example 2:
	///
	///	Input: intervals = [[7,10],[2,4]]
	///	Output: 1
	/// 
	///
	///	Constraints:
	///
	///	1 &lt;= intervals.length &lt;= 10^4
	///	0 &lt;= start_i &lt; end_i &lt;= 10^6
	/// </summary>
	/// <param name="intervals"></param>
	/// <returns></returns>
	public int MinMeetingRooms(int[][] intervals)
	{
		if (intervals.Length == 1)
		{
			return 1; // just need one room for 1 interval
		}

		intervals = intervals.OrderBy(interval => interval[0]).ToArray();

		var minHeap = new PriorityQueue<int, int>();
		minHeap.Enqueue(intervals[0][1], intervals[0][1]);

		foreach (int[] interval in intervals.Skip(1))
		{
			if (minHeap.Count == 0)
			{
				continue;
			}

			var endingSoonest = minHeap.Peek();
			if (endingSoonest <= interval[0])
			{
				_ = minHeap.Dequeue();
			}

			minHeap.Enqueue(interval[1], interval[1]);
		}

		return minHeap.Count;
	}
}
