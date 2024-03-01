namespace SquareMatrixMultiply;

/*
  The square matrix multiplication problem is the task of multiplying two n x n matrices.
  Example:
  Input: A = [[1, 2], [3, 4]], B = [[5, 6], [7, 8]]
  Output: C = [[19, 22], [43, 50]]

  Algorithm:
   A: n x n matrix
   B: n x n matrix
   returns the n x n matrix C = A x B
  
   Naive-Square-Matrix-Multiply(A, B)
   1. n = A.rows
   2. Let C be a new n x n matrix
   3. for i = 1 to n
   4.     for j = 1 to n
   5.         C[i, j] = 0
   6.         for k = 1 to n
   7.             C[i, j] = C[i, j] + A[i, k] * B[k, j]
   8. return C
   The naive algorithm for multiplying two n x n matrices has a time complexity of O(n^3).
   Space complexity: O(n^2) because the result matrix C is of size n x n.
 */

public static class SquareMatrix
{
    public static int[,] NaiveSquareMatrixMultiply(int[,] A, int[,] B)
    {
        int n = A.GetLength(0);
        int[,] C = new int[n, n];

        // Loop through the rows of A
        for (int i = 0; i < n; i++)
        {
            // Loop through the columns of B
            for (int j = 0; j < n; j++)
            {
                // Initialize the result matrix C at index i, j to 0
                C[i, j] = 0;

                // Loop through the columns of A
                for (int k = 0; k < n; k++)
                {
                    C[i, j] += A[i, k] * B[k, j];
                }
            }
        }
        return C;
    }

    public static int[,] RecursiveMultiply(int[,] A, int[,] B)
    {
        /*
		   Algorithm:
		   A: n x n matrix
		   B: n x n matrix
		   returns the n x n matrix C = A x B

		   n = A.rows
		   Let C be a new n x n matrix
		   if n = 1
		       C[1, 1] = A[1, 1] * B[1, 1]
		   else
		       C11 = Recursive-Multiply(A11, B11) + Recursive-Multiply(A12, B21)
		       C12 = Recursive-Multiply(A11, B12) + Recursive-Multiply(A12, B22)
		       C21 = Recursive-Multiply(A21, B11) + Recursive-Multiply(A22, B21)
		       C22 = Recursive-Multiply(A21, B12) + Recursive-Multiply(A22, B22)

		   return C

		   A total of 8 recursive calls are made, each of which has a time complexity of O(n^2).
		   A total of 4 matrix additions are made, each of which has a time complexity of O(n^2).
		   Complexity: O(n^3)
		 */

        int n = A.GetLength(0);
        int[,] C = new int[n, n];

        if (n == 1)
        {
            C[0, 0] = A[0, 0] * B[0, 0];
        }
        else
        {
            int[,] A11 = new int[n / 2, n / 2];
            int[,] A12 = new int[n / 2, n / 2];
            int[,] A21 = new int[n / 2, n / 2];
            int[,] A22 = new int[n / 2, n / 2];
            int[,] B11 = new int[n / 2, n / 2];
            int[,] B12 = new int[n / 2, n / 2];
            int[,] B21 = new int[n / 2, n / 2];
            int[,] B22 = new int[n / 2, n / 2];

            // Copy the elements of A and B into the 8 n/2 x n/2 matrices
            // Complexity: O(n^2)
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    A11[i, j] = A[i, j];
                    A12[i, j] = A[i, j + n / 2];
                    A21[i, j] = A[i + n / 2, j];
                    A22[i, j] = A[i + n / 2, j + n / 2];
                    B11[i, j] = B[i, j];
                    B12[i, j] = B[i, j + n / 2];
                    B21[i, j] = B[i + n / 2, j];
                    B22[i, j] = B[i + n / 2, j + n / 2];
                }
            }

            // C11 = A11 * B11 + A12 * B21
            int[,] C11 = Add(RecursiveMultiply(A11, B11), RecursiveMultiply(A12, B21));

            // C12 = A11 * B12 + A12 * B22
            int[,] C12 = Add(RecursiveMultiply(A11, B12), RecursiveMultiply(A12, B22));

            // C21 = A21 * B11 + A22 * B21
            int[,] C21 = Add(RecursiveMultiply(A21, B11), RecursiveMultiply(A22, B21));

            // C22 = A21 * B12 + A22 * B22
            int[,] C22 = Add(RecursiveMultiply(A21, B12), RecursiveMultiply(A22, B22));
        }
        return C;

    }
}
