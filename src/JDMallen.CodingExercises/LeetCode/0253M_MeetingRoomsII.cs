using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.LeetCode;

public class MeetingRoomsII
{
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
