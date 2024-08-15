using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.Tests.Data;

public class DynamicIntegerListsClassData : IEnumerable<object[]>
{
	private static readonly Random Random = new();

	public IEnumerator<object[]> GetEnumerator()
	{
		yield return GenerateTestCase();
		yield return GenerateTestCase();
		yield return GenerateTestCase();
		yield return GenerateTestCase();
		yield return GenerateTestCase();
		yield return GenerateTestCase();
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private static object[] GenerateTestCase()
	{
		// Generate a random length for the array (1 <= n <= 10,000)
		int length = Random.Next(1, 10_001);

		// Generate a sequence of integers from 1 to 'length'
		int[] sortedArray = Enumerable.Range(1, length).ToArray();

		// Shuffle the array using Fisher-Yates
		int[] shuffledArray = FisherYatesShuffle(sortedArray);

		return [shuffledArray, sortedArray];
	}

	private static int[] FisherYatesShuffle(int[] array)
	{
		var shuffledArray = (int[])array.Clone();
		for (int i = shuffledArray.Length - 1; i > 0; i--)
		{
			int j = Random.Next(0, i + 1);
			(shuffledArray[i], shuffledArray[j]) = (shuffledArray[j], shuffledArray[i]);
		}

		return shuffledArray;
	}
}