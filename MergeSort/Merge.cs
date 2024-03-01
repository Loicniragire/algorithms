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
Merge-Sort-Recursively(A, p, r)
	if p < r
		q = (p + r) / 2
		Merge-Sort(A, p, q)
		Merge-Sort(A, q + 1, r)
		Merge(A, p, q, r)

// A: Array,
// p: Start Index,
// q: Middle Index,
// r: End Index
Merge-Sort(A, p, q, r)
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
    /* public static int[] RecursiveSort(int[] array) */
    /* { */
    /*     if (array.Length <= 1) */
    /*     { */
    /*         return array; */
    /*     } */
    /*  */
    /*     MergeSort(array, 0, array.Length - 1); */
    /*  */
    /*     return array; */
    /* } */

    public static int[] Sort(int[] array)
    {
        // divide the array into two halves. 
        var n1 = array.Length / 2;
        var n2 = array.Length - n1;

        // copy the left half into L
        // copy the right half into R
        var L = new int[n1];
        var R = new int[n2];
        for (var x = 0; x < n1; x++)
        {
            L[x] = array[x];
        }

        for (var y = 0; y < n2; y++)
        {
            R[y] = array[n1 + y];
        }

        // Let i and j be the indices of the left and right arrays
        // k is the index of the original array
        var i = 0;
        var j = 0;
        var k = 0;

        // perfom a Mergse-Sort on the left and right arrays.
        // Merge the two halves into the original array
        // Starting from the start index to the end index
        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                array[k] = L[i];
                i++;
            }
            else
            {
                array[k] = R[j];
                j++;
            }
            k++;
        }
        // Copy the remaining elements of L, if there are any
        while (i < n1)
        {
            array[k] = L[i];
            i++;
            k++;
        }
        // Copy the remaining elements of R, if there are any\n
        while (j < n2)
        {
            array[k] = R[j];
            j++;
            k++;
        }

        return array;
    }

    // Merges two subarrays of array[].
    // First subarray is array[leftStart...mid]
    // Second subarray is array[mid+1...rightEnd]
    private static void MergeArray(int[] array, int[] tempArray, int leftStart, int mid, int rightEnd)
    {
        int i = leftStart; // Initial index of first subarray
        int j = mid + 1; // Initial index of second subarray
        int k = leftStart; // Initial index of merged subarray

        // Merge the temp arrays back into array[leftStart...rightEnd]
        while (i <= mid && j <= rightEnd)
        {
            if (tempArray[i] <= tempArray[j])
            {
                array[k] = tempArray[i];
                i++;
            }
            else
            {
                array[k] = tempArray[j];
                j++;
            }
            k++;
        }

        // Copy the remaining elements of left subarray if any
        while (i <= mid)
        {
            array[k] = tempArray[i];
            k++;
            i++;
        }

        // No need to copy the second half (since they're already in their place in the temporary array)
    }

    /* private static void MergeSort(int[] array, int startingIndex, int endingIndex) */
    /* { */
    /*     var middleIndex = (startingIndex + endingIndex) / 2; */
    /*     MergeArray(array, startingIndex, middleIndex, endingIndex); */
    /* } */

    /* private static void MergeArray(int[] array, int startingIndex, int middleIndex, int endingIndex) */
    /* { */
    /*  */
    /*  */
    /*     var leftIndex = middleIndex - startingIndex + 1; */
    /*     var rightIndex = endingIndex - middleIndex; */
    /*  */
    /*     var firstHalfSize = new int[leftIndex]; */
    /*     var secondHalfSize = new int[rightIndex]; */
    /*  */
    /*     while (leftIndex < firstHalfSize) */
    /*     { */
    /*         array[mergedIndex] = left[leftIndex]; */
    /*         leftIndex++; */
    /*         mergedIndex++; */
    /*     } */
    /*     while (rightIndex < secondHalfSize) */
    /*  */
    /*         array[mergedIndex] = right[rightIndex]; */
    /*     rightIndex++; */
    /*     mergedIndex++; */
    /* } */
}
