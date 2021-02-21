# solution to the LeetCode problem "Longest Common Prefix"
# https://leetcode.com/problems/longest-common-prefix
# Find the longest common prefix string amongst an array of strings.
# Ahmetcan Ozturk
from typing import List

class Solution:
    def longestCommonPrefix(self, strs: List[str]) -> str:
        if len(strs) == 0:
            return ""
        if len(strs) == 1:
            return strs[0]

        first = strs[0]
        prefix = ""
        for i in range(len(first)):
            for item in strs:
                if (i > len(item) - 1):
                    return prefix
                if first[i] != item[i]:
                    return prefix
            
            prefix = prefix + first[i]
    
        return prefix

if __name__ == "__main__":
    strs = ["ab","a"]
    result = Solution().longestCommonPrefix(strs)

    print(result)