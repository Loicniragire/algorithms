namespace MergeSort;

/*
Algorithm:
1. Divide the array into two halves
2. Recursively sort the two halves
3. Merge the two halves

Pseudocode:
// A: Array, 
// p: Start Index, 
// r: End Index
Sort(A, p, r)
	if p < r
		q = (p + r) / 2
		Sort(A, p, q)
		Sort(A, q + 1, r)
		MergeSort(A, p, q, r)

// A: Array,
// p: Start Index,
// q: Middle Index,
// r: End Index
MergeSort(A, p, q, r)
	// n1: Length of the left array
	n1 = q - p + 1

	// n2: Length of the right array
	n2 = r - q

	let L[1..n1 + 1] and R[1..n2 + 1] be new arrays

	// Copy the left array into L
	for i = 1 to n1
		L[i] = A[p + i - 1]

	// Copy the right array into R
	for j = 1 to n2
		R[j] = A[q + j]

	// Set the last element of L and R to infinity - This is the sentinel value
	L[n1 + 1] = ∞
	R[n2 + 1] = ∞

	// Let i and j be the indices of the left and right arrays
	i = 1
	j = 1

	// Loop through the array and merge the two halves. 
	// Starting from the start index to the end index - p to r
	// k is the index of the original array
	for k = p to r
		// If the left array is less than or equal to the right array
		// Copy the left array into the original array. 
		if L[i] ≤ R[j]
			A[k] = L[i]
			i = i + 1
		// Else copy the right array into the original array.
		// This is the merge step. 
		else A[k] = R[j]
			j = j + 1

Output: Sorted Array
Time Complexity: O(n log n)
Space Complexity: O(n). Because the algorithm uses extra space for the left and right arrays. 
	Which will be the same size as the original array.
Stable: Yes. Meaning the order of equal elements is preserved.
In-Place: No. Because the array is not sorted in place.
Online: No. Because the entire array is sorted at once.
Adaptive: No. Because the algorithm does not take advantage of existing order in its input.
Notes:
1. Best for large data sets
2. Good for data that is being sorted in memory
3. Good for data that is being sorted in place
4. Good for data that is being sorted in parallel
5. Good for data that is being sorted in a distributed system

Best Case: O(n log n) - When the array is already sorted. 
Because the array will be divided into log n parts and each part will be merged in O(n) time

Worst Case: O(n log n) - When the array is sorted in reverse order. 
Because the array will be divided into log n parts and each part will be merged in O(n) time

Average Case: O(n log n) - When the array is sorted in random order. 
Because the array will be divided into log n parts and each part will be merged in O(n) time

 */
public static class Merge
{
    public static void Sort(int[] array)
    {
        Sort(array, 0, array.Length - 1);
    }

    private static void Sort(int[] array, int p, int r)
    {
        if (p < r)
        {
            int q = (p + r) / 2;
            Sort(array, p, q);
            Sort(array, q + 1, r);
            MergeLeftAndRight(array, p, q, r);
        }
    }

    private static void MergeLeftAndRight(int[] array, int p, int q, int r)
    {
        int n1 = q - p + 1;
        int n2 = r - q;
        int[] L = new int[n1 + 1];
        int[] R = new int[n2 + 1];
        for (int i = 0; i < n1; i++)
            L[i] = array[p + i];
        for (int j = 0; j < n2; j++)
            R[j] = array[q + 1 + j];
        L[n1] = int.MaxValue;
        R[n2] = int.MaxValue;
        int iIndex = 0, jIndex = 0;
        for (int k = p; k <= r; k++)
        {
            if (L[iIndex] <= R[jIndex])
            {
                array[k] = L[iIndex];
                iIndex++;
            }
            else
            {
                array[k] = R[jIndex];
                jIndex++;
            }
        }
    }
}
