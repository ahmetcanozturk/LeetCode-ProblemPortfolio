# solution to the LeetCode problem "Longest Palindromic Substring"
# https://leetcode.com/problems/longest-palindromic-substring
# Given a string s, return the longest palindromic substring in s.
# Ahmetcan Ozturk

class Solution:
    def longestPalindrome(self, s: str) -> str:
        if(len(s) <= 1):
            return s
        longestpalindrome = ""

        for i in range(len(s) - 1):
            odd = self.getLongestPalindrome(s, i, i)
            even = self.getLongestPalindrome(s, i, i + 1)

            palindrome = odd if len(odd) > len(even) else even

            if (len(palindrome) > len(longestpalindrome)):
                longestpalindrome = palindrome

        return longestpalindrome

    def getLongestPalindrome(self, s: str, left: int, right: int) -> str:
        while(left >= 0 and right < len(s) and s[left] == s[right]):
            left -= 1
            right += 1

        return s[left + 1 : right]

if __name__ == "__main__":
    s = input()
    result = Solution().longestPalindrome(s)

    print(result)