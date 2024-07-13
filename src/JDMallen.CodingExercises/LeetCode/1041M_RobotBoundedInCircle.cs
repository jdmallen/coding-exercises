namespace JDMallen.CodingExercises.LeetCode;

public class RobotBoundedInCircle
{
	public bool IsRobotBounded(string instructions)
	{
		int x = 0, y = 0;         // start at origin
		var currentDirection = 0; // facing N

		int[,] directions = new[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } }; // N, E, S, W

		foreach (char inst in instructions)
		{
			switch (inst)
			{
				case 'L':
					currentDirection = (currentDirection + 3) % 4;

					break;
				case 'R':
					currentDirection = (currentDirection + 1) % 4;

					break;
				case 'G':
					x += directions[currentDirection, 0];
					y += directions[currentDirection, 1];

					break;
			}
		}

		return currentDirection == 0 || x == 0 && y == 0;
	}
}
