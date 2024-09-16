namespace JDMallen.CodingExercises.Codility;

public class L2E_CyclicRotation
{
    public int[] ArrayRotation(int[] A, int K)
    {
	    int arrLen = A.Length;
        var result = new int[arrLen];

        for (var i = 0; i < arrLen; i++)
        {
	        result[(i + K) % arrLen] = A[i];
        }

        return result;
    }
}
