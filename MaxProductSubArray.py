# Given an integer array nums, find a contiguous non-empty subarray within the array that has the largest product, and return the product.

# The test cases are generated so that the answer will fit in a 32-bit integer.

# A subarray is a contiguous subsequence of the array.



# Example 1:

# Input: nums = [2,3,-2,4]
# Output: 6
# Explanation: [2,3] has the largest product 6.
# Example 2:

# Input: nums = [-2,0,-1]
# Output: 0
# Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
 

# Constraints:

# 1 <= nums.length <= 2 * 104
# -10 <= nums[i] <= 10
# The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.


# Bit convoluted, but it runs decently fast
from typing import List

class Solution:
    def maxProduct(self, nums: List[int]) -> int:
        max = nums[0]
        current = max
        negativeIndex = 0
        if max < 0:
            negativeIndex = 1
        for i, num in enumerate(nums[1:]):
            if num < 0:
                if not negativeIndex:
                    negativeIndex = i + 2
            elif num == 0:
                if current < 0:
                    current = 1
                    for zeroNum in nums[negativeIndex:]:
                        current *= zeroNum
                        if current > max:
                                max = current
                        if zeroNum == 0:
                            if 0 > max:
                                max = 0
                            current = 1
                            break
                negativeIndex = 0
            if current == 0:
                current = 1
            current *= num
            if current > max:
                max = current
        if current < 0:
            current = 1
            for num in nums[negativeIndex:]:
                current *= num
                if current > max:
                    max = current
        return max
