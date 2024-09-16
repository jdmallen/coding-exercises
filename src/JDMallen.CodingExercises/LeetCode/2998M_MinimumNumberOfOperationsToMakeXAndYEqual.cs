using System;
using System.Collections.Generic;
using JDMallen.CodingExercises.Graphs;

namespace JDMallen.CodingExercises.LeetCode;

public class MinimumNumberOfOperationsToMakeXAndYEqual
{
	public int MinimumOperationsToMakeEqual_NaiveAttempt(int x, int y)
	{
		const int proximity = 1;

		if (x == y)
		{
			return 0;
		}

		var operationCount = 0;

		while (x != y)
		{
			if (x > y && DivByZ(x, 11, out x))
			{
				operationCount++;

				continue;
			}

			if (x > y && x != y && DivByZ(x, 5, out x))
			{
				operationCount++;

				continue;
			}

			if (x < y
			    || x > y && CloseToGreaterMultiple(x, 11) && x - y > proximity + 1
			    || x > y && CloseToGreaterMultiple(x, 5) && x - y > proximity + 1)
			{
				x++;
				operationCount++;

				continue;
			}

			if (x > y)
			{
				x--;
				operationCount++;

				continue;
			}
		}

		return operationCount;

		bool DivByZ(int x, int z, out int result)
		{
			if (x % z == 0)
			{
				result = x / z;

				return true;
			}

			result = x;

			return false;
		}

		bool CloseToGreaterMultiple(int x, int z) => x % z >= z - proximity;
	}

	public int MinimumOperationsToMakeEqual(int x, int y)
	{
		if (x == y)
		{
			return 0;
		}

		var queue = new Queue<Node<Tuple<int, int>>>();
		var visited = new HashSet<int>();
		var startingNode = new Node<Tuple<int, int>>(Tuple.Create(x, 0));

		queue.Enqueue(startingNode);
		visited.Add(startingNode.Payload.Item1);

		while (queue.Count > 0)
		{
			Node<Tuple<int, int>> node = queue.Dequeue();
			int currentValue = node.Payload.Item1;
			int operationsSoFar = node.Payload.Item2;

			var nextValues = new List<int>
			{
				currentValue + 1,
				currentValue - 1,
			};

			if (DivideByZIfMultiple(currentValue, 11, out int result))
			{
				nextValues.Add(result);
			}

			if (DivideByZIfMultiple(currentValue, 5, out result))
			{
				nextValues.Add(result);
			}

			foreach (int nextValue in nextValues)
			{
				if (nextValue == y)
				{
					return operationsSoFar + 1;
				}

				if (visited.Contains(nextValue) || nextValue <= 0)
				{
					continue;
				}

				visited.Add(nextValue);
				var nextNode =
					new Node<Tuple<int, int>>(Tuple.Create(nextValue, operationsSoFar + 1));
				queue.Enqueue(nextNode);
			}
		}

		return -1;

		bool DivideByZIfMultiple(int x, int z, out int result)
		{
			if (x % z == 0)
			{
				result = x / z;

				return true;
			}

			result = x;

			return false;
		}
	}
}
