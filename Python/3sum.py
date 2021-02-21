# solution to the LeetCode problem "3Sum"
# https://leetcode.com/problems/3sum
# Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? 
# Find all unique triplets in the array which gives the sum of zero.
# Ahmetcan Ozturk
from typing import List

class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        nums = sorted(nums)
        result = set()
        for i in range(len(nums)):
            left = i + 1
            right = len(nums) - 1
            while left < right:
                if nums[left] + nums[right] == -nums[i]:
                    result.add((nums[i], nums[left], nums[right]))
                    left += 1
                    right -= 1
                elif nums[left] + nums[right] < -nums[i]:
                    left += 1
                else:
                    right -= 1
        return list(result)

if __name__ == "__main__":
    sol = Solution()
    nums = [-1, 0, 1, 2, -1, -4]

    result = sol.threeSum(nums)

    print(result)