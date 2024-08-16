using System;
using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.LeetCode;

public class TheLatestTimeToCatchABus
{
	public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
	{
		Array.Sort(buses);
		Array.Sort(passengers);

		int passengerIndex = 0;
		int lastPossibleTime = 0;

		foreach (int bus in buses)
		{
			int passengersOnBus = 0;

			while (passengerIndex < passengers.Length && passengers[passengerIndex] <= bus && passengersOnBus < capacity)
			{
				lastPossibleTime = passengers[passengerIndex];
				passengersOnBus++;
				passengerIndex++;
			}

			// If the bus has capacity left, and it is the last bus, the last possible time is the bus's time
			if (passengersOnBus < capacity)
			{
				lastPossibleTime = bus;
			}
		}

		// Decrement the last possible time until it's not the same as any passenger's time
		while (Array.BinarySearch(passengers, lastPossibleTime) >= 0)
		{
			lastPossibleTime--;
		}

		return lastPossibleTime;
	}
}
