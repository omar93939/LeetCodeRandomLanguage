// Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].

// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

// You must write an algorithm that runs in O(n) time and without using the division operation.

 

// Example 1:

// Input: nums = [1,2,3,4]
// Output: [24,12,8,6]
// Example 2:

// Input: nums = [-1,1,0,-3,3]
// Output: [0,0,9,0,0]
 

// Constraints:

// 2 <= nums.length <= 105
// -30 <= nums[i] <= 30
// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

// "var" appears slightly faster than "let" outside of the loops on leetcode. Not sure why.
// This phenomenon should likely not be given too much attention though, and both are fine to use.
// I would likely usually use "let" to account for scope, but in this case it appeared beneficial to use "var".

/**
 * @param {number[]} nums
 * @return {number[]}
 */
 var productExceptSelf = function(nums) {
    var products = Array(nums.length).fill(1);
    var multiplier = 1;
    for (let i = 0; i < nums.length; i++) {
        products[i] = multiplier * products[i];
        multiplier = multiplier * nums[i];
    }
    multiplier = 1;
    for (let i = nums.length - 1; i >= 0; i--) {
        products[i] = multiplier * products[i];
        multiplier = multiplier * nums[i];
    }
    return products;
};
