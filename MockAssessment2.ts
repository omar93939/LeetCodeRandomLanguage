// Given an integer n, return true if it is a power of two. Otherwise, return false.

// An integer n is a power of two, if there exists an integer x such that n == 2x.

 

// Example 1:

// Input: n = 1
// Output: true
// Explanation: 20 = 1
// Example 2:

// Input: n = 16
// Output: true
// Explanation: 24 = 16
// Example 3:

// Input: n = 3
// Output: false
 

// Constraints:

// -231 <= n <= 231 - 1

// function isPowerOfTwo(n: number): boolean {
//   const log = Math.log2(n);
//   return Number.isInteger(log);
// };


// Given an array nums of n integers where nums[i] is in the range [1, n], return an array of all the integers in the range [1, n] that do not appear in nums.

 

// Example 1:

// Input: nums = [4,3,2,7,8,2,3,1]
// Output: [5,6]
// Example 2:

// Input: nums = [1,1]
// Output: [2]
 

// Constraints:

// n == nums.length
// 1 <= n <= 105
// 1 <= nums[i] <= n

function findDisappearedNumbers(nums: number[]): number[] {
  for (let i = 0; i < nums.length; i++) {
    if (nums[i] > 0) {
      if (nums[nums[i] - 1] > 0) {
        nums[nums[i] - 1] = -nums[nums[i] - 1];
      }
    } else {
      if (nums[-nums[i] - 1] > 0) {
        nums[-nums[i] - 1] = -nums[-nums[i] - 1];
      }
    }
    
  }
  for (let i = 0; i < nums.length; i++) {
    if (nums[i] > 0) {
      nums[i] = i + 1;
    }
  }
  return nums.filter(num => num > 0);
};