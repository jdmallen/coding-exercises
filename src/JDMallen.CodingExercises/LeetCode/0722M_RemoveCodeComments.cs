using System.Collections.Generic;

namespace JDMallen.CodingExercises.LeetCode;

public class RemoveCodeComments
{
	public IList<string> RemoveComments(string[] source)
	{
		var inBlock = false;
		var inLine = false;
		var answer = new List<string>();
		foreach (var line in source)
		{
			var noCommentLine = "";
			for (var i = 1; i < line.Length; i += 2)
			{
				char c1 = line[i - 1];
				char c2 = line[i];

				inBlock = c1 switch
				{
					'/' when c2 == '*' => true,
					'*' when c2 == '/' => false,
					_                  => inBlock,
				};

				if (c1 == '/' && c2 == '/' && !inBlock)
				{
					inLine = true;
				}

				if (inBlock || inLine)
				{
					continue;
				}

				noCommentLine += c1;
				noCommentLine += c2;
			}

			answer.Add(noCommentLine);
			inLine = false;
		}

		return answer;
	}
}
