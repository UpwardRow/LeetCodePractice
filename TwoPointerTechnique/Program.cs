public class TwoPointerTechnique{
    public static void Main(string[] args){
        Console.WriteLine(PointersInSameDirection([1,2,3,0,0,0], 3, [2,5,6], 3));
        Console.WriteLine(PointersOppositeDirectionsInGivenSortedArrayAscendingOrder([2, 7, 11, 15], 9));
        Console.WriteLine(PointersRemoveElementInUnsortedArray([3, 2, 12, 32, 31, 2, 3], 3));
    }

    static bool PointersInSameDirection(int[] nums1, int numberOfElementsInNums1, int[] nums2, int numberOfElementsInNums2){
        int nums1Pointer = numberOfElementsInNums1 - 1; 
        int nums2Pointer = numberOfElementsInNums2 - 1; 
        int mergePointer = numberOfElementsInNums1 + numberOfElementsInNums2 - 1;

        // Merge from the back to avoid overwriting values in nums1
        while (nums1Pointer >= 0 && nums2Pointer >= 0)
        {
            if (nums1[nums1Pointer] > nums2[nums2Pointer])
                nums1[mergePointer--] = nums1[nums1Pointer--];
            else
                nums1[mergePointer--] = nums2[nums2Pointer--];
        }

        // Copy remaining elements from nums2 (if any)
        while (nums2Pointer >= 0)
            nums1[mergePointer--] = nums2[nums2Pointer--];

        Console.WriteLine("Here is nums1 " + string.Join(", ", nums1));
        return true;
    }

    static int[] PointersOppositeDirectionsInGivenSortedArrayAscendingOrder(int[] nums, int target)
    {
        int leftPointer = 0;
        int rightPointer =  nums.Length - 1;
        while (leftPointer < rightPointer)
        {
            // This here is for checking for the target
            int sum = nums[leftPointer] + nums[rightPointer];
            if (sum == target)
            {
                var myIntArray = new int[] { leftPointer + 1, rightPointer + 1 };
                Console.WriteLine("Here is the int array " + string.Join(", ", myIntArray));
                return myIntArray;
            }
            // We are still looking for the given target which is larger, so we increment the left pointer
            else if (sum <= target)
            {
                leftPointer++;
            } 
            // We are still looking for the given target which is smaller, so we decrement the right pointer
            else
            {
                rightPointer--;
            }
        }
        return new int[2];
    }


    static int PointersRemoveElementInUnsortedArray(int[] nums, int intToRemove)
    {
        int rightPointer = nums.Length;
        int leftPointer = 0;

        // If the iterator does NOT find the int to remove, then the left pointer is set to the value of the iterator, then it is incremented by 1
        for (int i = 0; i < rightPointer; i++)
        {
            if (nums[i] != intToRemove)
            {
                nums[leftPointer++] = nums[i];
            }
        }

        // Copy only the first 'leftPointer' elements (the cleaned part)
        int[] cleaned = new int[leftPointer];
        // Creates an array that is only up until the left pointer, cleaning the array
        Array.Copy(nums, cleaned, leftPointer);
        Console.WriteLine("Cleaned array: " + string.Join(", ", cleaned));
        nums = cleaned;
        return cleaned.Length;
    }
}
