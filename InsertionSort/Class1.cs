namespace InsertionSort;

/* 
 Algortith:
 for j = 2 to A.length
	 key = A[j]
	 i = j - 1
	 while i > 0 and A[i] > key
		 A[i + 1] = A[i]
		 i = i - 1
	 A[i + 1] = key
 Output: Sorted Array
 Time Complexity: O(n^2)
 Space Complexity: O(1)
 Stable: Yes
 In-Place: Yes
 Online: No
 Adaptive: Yes
 Notes:
 1. Best for small data sets
 2. Good for partially sorted data
 3. Good for data that is being added to a list
 4. Good for data that is being streamed
 5. Good for data that is being sorted in memory
 6. Good for data that is being sorted in place
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
