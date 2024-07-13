using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.LeetCode;

public class TextJustification
{
	public IList<string> FullJustify(string[] words, int maxWidth)
	{
		return FullJustifyCore(words, maxWidth, 0);
	}

	private IList<string> FullJustifyCore(string[] words, int maxWidth, int startIndex)
	{
		var list = new List<string>();
		if (words.Length == 0)
		{
			return list;
		}

		var wordsThisLine = new List<string>();
		var lastLine = false;
		int i;
		for (i = startIndex; i < words.Length; i++)
		{
			string nextWord = words[i];
			int numCharactersInWordsThisLine =
				wordsThisLine.SelectMany(x => x).Count() + wordsThisLine.Count - 1;

			if (numCharactersInWordsThisLine + nextWord.Length + 1 > maxWidth)
			{
				break;
			}

			if (i == words.Length - 1)
			{
				lastLine = true;
			}

			wordsThisLine.Add(nextWord);
		}

		if (!wordsThisLine.Any())
		{
			return list;
		}

		int numberOfGaps = wordsThisLine.Count - 1;
		int minimumSpacesForJoin = numberOfGaps < 1 ? 1 : numberOfGaps;
		int spaceToFill = maxWidth - wordsThisLine.SelectMany(x => x).Count();
		int spacesBetweenWords = lastLine ? 1 : spaceToFill / minimumSpacesForJoin;
		string line = string.Join(new string(' ', spacesBetweenWords), wordsThisLine);

		if (lastLine || wordsThisLine.Count == 1)
		{
			line = $"{line}{new string(' ', maxWidth - line.Length)}";
		}

		string sub = line;

		// start with space before last word
		for (int wordIndex = 0; wordIndex < wordsThisLine.Count; wordIndex++)
		{
			if (line.Length == maxWidth)
			{
				break;
			}

			string thisWord = wordsThisLine[wordIndex];
			int startingIndex =
				sub.IndexOf(thisWord) + thisWord.Length + line.Length - sub.Length;
			sub = line.Substring(startingIndex, line.Length - startingIndex);
			line = line.Insert(startingIndex, " ");

			if (wordIndex == wordsThisLine.Count - 1)
			{
				wordIndex = 0;
			}
		}

		list.Add(line);

		IList<string> nextList = FullJustifyCore(words, maxWidth, i);
		if (nextList.Count == 0)
		{
			return list;
		}

		list.AddRange(nextList);

		return list;
	}
}
