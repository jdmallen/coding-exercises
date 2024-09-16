using System;

namespace JDMallen.CodingExercises.Codility;

public class L1E_BinaryGap
{
    public int BinaryGap(int N)
    {
        var binary = Convert.ToString(N, 2);
        Console.WriteLine(binary);
        int currentGap = 0, longestGap = 0;
        bool boundary = false;
        char lastChar = '\0';

        for (var i = 0; i < binary.Length; i++)
        {
            char c = binary[i];
            Console.WriteLine($"char {i}: '{c}'");
            if (c == '1' && (!boundary || lastChar == '1'))
            {
                boundary = true;
            }
            else if (c == '0' && boundary)
            {
                currentGap++;
                Console.WriteLine($"currentGap now {currentGap}");
            }
            else if (c == '1' && boundary)
            {
                longestGap = Math.Max(longestGap, currentGap);
                currentGap = 0;
                Console.WriteLine($"longestGap set to {longestGap}, currentGap reset");
            }

            lastChar = c;

            //Console.WriteLine($"oB: {boundary}, current: {currentGap}, longest: {longestGap}");
        }

        return longestGap;

        // Implement your solution here
    }
}
