// Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:

// [4,5,6,7,0,1,2] if it was rotated 4 times.
// [0,1,2,4,5,6,7] if it was rotated 7 times.
// Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].

// Given the sorted rotated array nums of unique elements, return the minimum element of this array.

// You must write an algorithm that runs in O(log n) time.

 

// Example 1:

// Input: nums = [3,4,5,1,2]
// Output: 1
// Explanation: The original array was [1,2,3,4,5] rotated 3 times.
// Example 2:

// Input: nums = [4,5,6,7,0,1,2]
// Output: 0
// Explanation: The original array was [0,1,2,4,5,6,7] and it was rotated 4 times.
// Example 3:

// Input: nums = [11,13,15,17]
// Output: 11
// Explanation: The original array was [11,13,15,17] and it was rotated 4 times. 
 

// Constraints:

// n == nums.length
// 1 <= n <= 5000
// -5000 <= nums[i] <= 5000
// All the integers of nums are unique.
// nums is sorted and rotated between 1 and n times.

public class Solution {
    // Essentially a Binary Search Algorithm (Recursion)
    public int FindMin(int[] nums) {
        int right = nums.Length - 1;
        if (right == 0 || nums[right] > nums[0]) {
            return nums[0];
        } else if (right == 1) {
            return Math.Min(nums[0], nums[1]);
        }
        int current = right / 2;
        if (nums[current] < nums[0]) {
            return FindMin(nums[..(current + 1)]);
        } else {
            return FindMin(nums[current..]);
        }
    }

    // Still Essentially a Binary Search Algorithm (No Recursion)
    public int FindMinAlt(int[] nums) {
        int left = 0;
        int right = nums.Length - 1;
        int current = right / 2;
        while (true) {
            if (right - left == 0 || nums[right] > nums[left]) {
                return nums[left];
            } else if (right - left == 1) {
                return Math.Min(nums[left], nums[right]);
            }
            if (nums[current] < nums[left]) {
                right = current;
            } else {
                left = current;
            }
            current = (right + left) / 2;
        }
    }
}
