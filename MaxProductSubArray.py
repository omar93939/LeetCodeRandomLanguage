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


from typing import List

class Solution:


    # Theoretically an improvement as only have to go through list once - no backtracking.
    # Original solution involved backtracking. Therefore, in the worst case, this solution's
    # efficiency should be O(N)
    # For this to have a large/noticeable effect, the length of array will have to approach
    # into the tens of thousands (depending on the number of 0s, as those get skipped in
    # either implementation), but the new/improved rendition is theoretically approaching
    # 2x faster when approaching larger and larger lists/arrays.
    def maxProduct(self, nums: List[int]) -> int:
        max = nums[0]
        current = 1
        last = 0
        negativeDivisor = 0
        count = 0
        for num in nums:
            if num == 0:
                if current < 0 and count > 1:
                    current //= negativeDivisor
                    if current > max:
                        max = current
                elif 0 > max:
                    max = 0
                last = current
                current = 1
                negativeDivisor = 0
                count = 0
                continue
            current *= num
            if current < 0:
                if not negativeDivisor:
                    negativeDivisor = current
            if current > max:
                max = current
            count += 1
        if current < 0 and count > 1:
            if nums[len(nums) - 1] == 0:
                current = last
            current //= negativeDivisor
            if current > max:
                max = current
        return max
       

    # Bit convoluted, but it runs decently fast. Still has backtracking though.
    # This makes it so that the efficiency is O(N) still, but in the worst case
    # it backtracks through the entire list.
def maxProductOriginal(self, nums: List[int]) -> int:
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
