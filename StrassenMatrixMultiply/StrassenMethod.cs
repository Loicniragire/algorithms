namespace StrassenMatrixMultiply;

// TODO: Complete implementation. Also, double check on the algorithm itself. 
/*
   The Strassen's algorithm is a divide and conquer algorithm that multiplies two matrices.
   The Strassen's algorithm multiplies two n x n matrices in O(n^log7) time.
   The Strassen's algorithm is faster than the standard matrix multiplication algorithm which multiplies two n x n matrices in O(n^3) time.
   The Strassen's algorithm is not practical for large matrices because the constant factor in the O(n^log7) time is large.

   The Strassen's algorithm multiplies two n x n matrices using 7 multiplications instead of 8 multiplications 
   in the standard matrix multiplication algorithm. (see SquareMatrix.RecursiveMultiply functin in SquareMatrix.cs)

   The Strassen's algorithm multiplies two n x n matrices using 18 additions and 7 subtractions instead of 4n^2 additions and n^2 subtractions in the standard matrix multiplication algorithm.

Algorithm:
1. Divide the n x n matrices A and B into four n/2 x n/2 matrices. 
2. Compute the 10 matrices S1, S2, S3, S4, S5, S6, S7, S8, S9,and S10. Each matrix is the result of an arithmetic operation on A and B. Complexity: O(n^2)
3. Using the 10 matrices S1, S2, S3, S4, S5, S6, S7, S8, S9, and S10, compute the 7 matrices P1, P2, P3, P4, P5, P6, and P7. Each matrix is the result of a recursive call to the Strassen's algorithm. Complexity: O(n^2)
	P1 = A11 * S1 = A11 * B12 - A11 * B22
	P2 = S2 * B22 = A11 * B22 + A12 * B22
	P3 = S3 * B11 = A21 * B11 + A22 * B11
	P4 = A22 * S4 = A22 * B21 - A22 * B11
	P5 = S5 * S6 = A11 * B11 + A11 * B22 + A22 * B11 + A22 * B22
	P6 = S7 * S6 = A12 * B11 + A12 * B22 - A22 * B11 - A22 * B22
	P7 = S2 * S4 = A11 * B22 - A12 * B22 + A21 * B11 - A22 * B11

4. Return the n x n matrix C by combining the 4 n/2 x n/2 matrices.  Complexity: O(n^2)
	C11 = P5 + P4 - P2 + P6 = A11 * B11 + A11 * B22 + A22 * B11 + A22 * B22 = A11 * B11 + A12 * B21
	C12 = P1 + P2 = A11 * B12 + A11 * B22 = A11 * B12 + A12 * B22
	C21 = P3 + P4 = A21 * B11 + A22 * B11 = A21 * B11 + A22 * B12
	C22 = P5 + P1 - P3 - P7 = A11 * B11 + A12 * B12 - A11 * B11 + A12 * B22 = A12 * B21 + A22 * B11
 */

public static class Strassen
{
	/// <summary>
	/// The Strassen's algorithm multiplies two n x n matrices in O(n^log7) time.
	/// </summary>
	/// <param name="A">n x n matrix</param>
	/// <param name="B">n x n matrix</param>
	/// <returns>The n x n matrix C = A x B</returns>
	public static int[,] Multiply(int[,] A, int[,] B)
	{
		// Base case
		// If the input matrices are 1 x 1 matrices, then multiply the matrices using the standard algorithm
		// The standard algorithm multiplies two 1 x 1 matrices in O(1) time
		if (A.GetLength(0) == 1)
		{
			return new int[,] { { A[0, 0] * B[0, 0] } };
		}

		// Divide the n x n matrices A and B into four n/2 x n/2 matrices
		// A11, A12, A21, A22, B11, B12, B21, B22
		int n = A.GetLength(0);
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

		// Compute the 10 matrices S1, S2, S3, S4, S5, S6, S7, S8, S9, and S10
		// Complexity: O(n^2)
		//
		int[,] S1 = Subtract(B12, B22);
		int[,] S2 = Add(A11, A12);
		int[,] S3 = Add(A21, A22);
		int[,] S4 = Subtract(B21, B11);
		int[,] S5 = Add(A11, A22);
		int[,] S6 = Add(B11, B22);
		int[,] S7 = Subtract(A12, A22);
		int[,] S8 = Add(B21, B22);
		int[,] S9 = Subtract(A11, A21);
		int[,] S10 = Add(B11, B12);

		int[,] P1 = Multiply(A11, S1);
		int[,] P2 = Multiply(S2, B22);
		int[,] P3 = Multiply(S3, B11);
		int[,] P4 = Multiply(A22, S4);
		int[,] P5 = Multiply(S5, S6);
		int[,] P6 = Multiply(S7, S6);
		int[,] P7 = Multiply(S2, S4);

		// Compute the n x n matrix C using the 10 matrices S1, S2, S3, S4, S5, S6, S7, P1, P2, P3, P4, P5, P6, P7
		// Complexity: O(n^2)
		int[,] C11 = Add(Add(P5, P4), Subtract(P2, P6));
		int[,] C12 = Add(P1, P2);
		int[,] C21 = Add(P3, P4);
		int[,] C22 = Subtract(Add(P5, P1), Add(P3, P7));

		// Return the n x n matrix C by combining the 4 n/2 x n/2 matrices
		// Complexity: O(n^2)
		int[,] C = new int[n, n];
		for (int i = 0; i < n / 2; i++)
		{
			for (int j = 0; j < n / 2; j++)
			{
				C[i, j] = C11[i, j];
				C[i, j + n / 2] = C12[i, j];
				C[i + n / 2, j] = C21[i, j];
				C[i + n / 2, j + n / 2] = C22[i, j];
			}
		}

		return C;
	}
}
