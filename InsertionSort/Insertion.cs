namespace InsertionSort;

/* 
Algorithm:
1. Start from the second element of the array
2. Compare the current element with the previous elements
3. If the current element is less than the previous element, swap the two elements
4. Repeat step 2 and 3 until the current element is greater than the previous element
5. Repeat steps 1 to 4 until the entire array is sorted

Pseudocode:
Insertion-Sort(A)
 for j = 2 to A.length
	 key = A[j]
	 i = j - 1
	 while i > 0 and A[i] > key
		 A[i + 1] = A[i]
		 i = i - 1
	 A[i + 1] = key

 Output: Sorted Array
 Time Complexity: O(n^2)
 Space Complexity: O(1). Because the array is sorted in place. 
 Stable: Yes
 In-Place: Yes
 Online: No
 Adaptive: Yes. 
 Notes:
 1. Best for small data sets
 2. Good for partially sorted data
 3. Good for data that is being sorted in memory
 4. Good for data that is being sorted in place

 Best Case: O(n) - When the array is already sorted. Because the inner loop will not execute
 Worst Case: O(n^2) - When the array is sorted in reverse order. Because the inner loop will execute n(n-1)/2 times
 Average Case: O(n^2) - When the array is sorted in random order. Because the inner loop will execute n(n-1)/4 times
*/
public static class Insertion
{
    public static int[] Sort(int[] array)
    {
        for (int j = 2; j < array.Length; j++)
        {
            var key = array[j];
            int i = j - 1;

			// continuously swap until array[i] is less than key
            while (i > 0 && array[i] > key)
            {
                array[i + 1] = array[i];
                i = i - 1;
            }

			// insert key into the correct position
            array[i + 1] = key;
        }
        return array;
    }
}
