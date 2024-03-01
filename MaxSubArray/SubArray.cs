namespace MaxSubArray;

/*
 The maximum subarray problem is the task of finding the contiguous subarray within a one-dimensional array, 
 a[1...n], of numbers which has the largest sum.
 Example:
 Input: [-2, 1, -3, 4, -1, 2, 1, -5, 4]
 Output: [4, -1, 2, 1] has the largest sum = 6

 The maximum subarray problem can be solved using the divide and conquer technique.
 The array is divided into two halves and the maximum subarray is calculated for each half.
 The maximum subarray is then calculated for the entire array by comparing the maximum subarray of each half.
 The maximum subarray of the entire array is the maximum of the maximum subarray of each half.

 The maximum subarray of the entire array can be calculated in O(n log n) time.
 The maximum subarray of the entire array can also be calculated in O(n) time using the Kadane's algorithm.

 Algorithm:
 // A: Array
 // low: start index
 // high: end index
 // returns the start index, end index, and the sum of the maximum subarray
 Find-Maximum-Subarray(A, low, high)
 1. If low = high // base case: only one element.
 2.     Return (low, high, A[low])
 3. Else
 		// Divide the array into two halves and calculate the maximum subarray of each half.
 4.     mid = (low + high) / 2

 		// Find the maximum subarray of the left half
 5.     (left-low, left-high, left-sum) = Find-Maximum-Subarray(A, low, mid)

 		// Find the maximum subarray of the right half
 6.     (right-low, right-high, right-sum) = Find-Maximum-Subarray(A, mid + 1, high)

 		// Find the maximum subarray that crosses the midpoint. Meaning, the maximum subarray that includes the midpoint.
 7.     (cross-low, cross-high, cross-sum) = Find-Max-Crossing-Subarray(A, low, mid, high)

 		// Compare the maximum subarray of the left half, right half, and the maximum subarray that crosses the midpoint.
 8.     if left-sum ≥ right-sum and left-sum ≥ cross-sum
 9.         Return (left-low, left-high, left-sum)
 10.    else if right-sum ≥ left-sum and right-sum ≥ cross-sum
 11.        Return (right-low, right-high, right-sum)
 12.    else
 13.        Return (cross-low, cross-high, cross-sum)

 // A: Array
 // low: start index
 // mid: middle index
 // high: end index
 // returns the start index, end index, and the sum of the maximum subarray. 
 Find-Max-Crossing-Subarray(A, low, mid, high)
 1. left-sum = -∞
 2. sum = 0

 	// Find the maximum subarray of the left half
 3. for i = mid downto low
 4.     sum = sum + A[i]
 5.     if sum > left-sum
 6.         left-sum = sum
 7.         max-left = i

 8. right-sum = -∞
 9. sum = 0
 10. for j = mid + 1 to high
 11.     sum = sum + A[j]
 12.     if sum > right-sum
 13.         right-sum = sum
 14.         max-right = j

 15. return (max-left, max-right, left-sum + right-sum)

 Time Complexity: O(n log n)
 Space Complexity: O(n). Because the algorithm uses extra space for the left and right arrays.



*/
public static class SubArray
{
    public static (int, int, int) FindMaximumSubarray(int[] A, int low, int high)
    {
        if (low == high)
        {
            return (low, high, A[low]);
        }
        else
        {
            int mid = (low + high) / 2;
            (int leftLow, int leftHigh, int leftSum) = FindMaximumSubarray(A, low, mid);
            (int rightLow, int rightHigh, int rightSum) = FindMaximumSubarray(A, mid + 1, high);
            (int crossLow, int crossHigh, int crossSum) = FindMaxCrossingSubarray(A, low, mid, high);

            if (leftSum >= rightSum && leftSum >= crossSum)
            {
                return (leftLow, leftHigh, leftSum);
            }
            else if (rightSum >= leftSum && rightSum >= crossSum)
            {
                return (rightLow, rightHigh, rightSum);
            }
            else
            {
                return (crossLow, crossHigh, crossSum);
            }
        }
    }

    private static (int, int, int) FindMaxCrossingSubarray(int[] A, int low, int mid, int high)
    {
        int leftSum = int.MinValue;
        int sum = 0;
        int maxLeft = 0;

		// Find the maximum subarray of the left half. 
		// By starting from the midpoint and going to the left.
        for (int i = mid; i >= low; i--)
        {
			// Calculate the sum of the subarray.
            sum += A[i];

			// If the sum is greater than the leftSum, then update the leftSum and the maxLeft.
            if (sum > leftSum)
            {
                leftSum = sum;

				// Update the maxLeft to the current index.
                maxLeft = i;
            }
        }

        int rightSum = int.MinValue;
        sum = 0;
        int maxRight = 0;

		// Find the maximum subarray of the right half.
        for (int j = mid + 1; j <= high; j++)
        {
            sum += A[j];
            if (sum > rightSum)
            {
                rightSum = sum;
                maxRight = j;
            }
        }

        return (maxLeft, maxRight, leftSum + rightSum);
    }

}
