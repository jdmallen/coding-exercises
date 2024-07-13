namespace JDMallen.CodingExercises.LeetCode;

public class NumberOfIslands
{
	public int NumIslands(char[][] grid)
	{
		var numIslands = 0;

		for (int i = grid.Length - 1; i >= 0; i--)
		{
			for (var j = 0; j < grid[i].Length; j++)
			{
				// from bottom left to top right, x direction first
				if (MarkAdjacentCells(ref grid, i, j))
				{
					numIslands++;
				}
			}
		}

		return numIslands;
	}

	private static bool MarkAdjacentCells(ref char[][] grid, int i, int j)
	{
		int[,] directions = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } }; // N, E, S, W

		if (i < 0
		    || i > grid.Length - 1
		    || j < 0
		    || j > grid[i].Length - 1)
		{
			return false;
		}

		char cell = grid[i][j];

		if (cell == '0' || cell == 'V')
		{
			return false;
		}

		// Mark cell as visited
		grid[i][j] = 'V';

		for (var k = 0; k < 4; k++)
		{
			int xDir = directions[k, 0];
			int yDir = directions[k, 1];

			int xPos = j + xDir;
			int yPos = i - yDir;

			MarkAdjacentCells(ref grid, yPos, xPos);
		}

		return true;
	}
}
