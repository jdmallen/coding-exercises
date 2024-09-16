using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.LeetCode;

public class RankTeamsByVotes
{
	public string RankTeams(string[] votes)
	{
		var numberOfTeams = votes[0].Length;

		var dict = new Dictionary<char, int[]>();

		foreach (string vote in votes)
		{
			for (var i = 0; i < vote.Length; i++)
			{
				char team = vote[i];
				dict.TryAdd(team, new int[numberOfTeams]);
				dict[team][i]++;
			}
		}

		var sortedTeams = dict.Keys.ToList();
		sortedTeams.Sort(
			(a, b) =>
			{
				for (int i = 0; i < numberOfTeams; i++)
				{
					if (dict[a][i] != dict[b][i])
					{
						return dict[b][i] - dict[a][i];
					}
				}

				return a.CompareTo(b);
			});

		return new string(sortedTeams.ToArray());
	}
}
