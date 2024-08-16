using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.LeetCode;

public class GroupAnagramStrings
{
	public IList<IList<string>> GroupAnagrams(string[] strs)
	{
		var dict = new Dictionary<string, List<string>>();
		foreach (string str in strs)
		{
			var sorted = new string(str.ToCharArray().OrderBy(x => x).ToArray());
			if (!dict.ContainsKey(sorted))
			{
				dict[sorted] = new List<string>();
			}

			dict[sorted].Add(str);
		}

		//convert from dict back to arrays
		string[][] arrays = dict.Values.Select(list => list.ToArray()).ToArray();

		return arrays;
	}
}
