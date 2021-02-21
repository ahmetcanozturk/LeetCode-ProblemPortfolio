using System;
using System.Collections.Generic;
using System.Linq;
/*
    * solution to the leetcode problem "Longest Substring Without Repeating Characters"
    * https://leetcode.com/problems/longest-substring-without-repeating-characters
    * Ahmetcan Ozturk
*/
public class Solution
{
    public int LengthOfLongestSubstring(string s) {
        if (string.IsNullOrEmpty(s))
            return 0;

        var elements = s.ToCharArray();
        var longest = new List<char>();
        var temp = new List<char>();

        temp.Add(elements[0]);
        longest = temp.ToList();

        for(int i=1; i<elements.Length; i++)
        {
            if (!temp.Contains(elements[i]))
                temp.Add(elements[i]);
            else
            {
                int idx = temp.IndexOf(elements[i]);
                temp.RemoveRange(0, idx + 1);
                if (temp.Count == 0)
                    temp = new List<char>() { elements[i] };
                else
                    temp.Add(elements[i]);
            }

            if (temp.Count > longest.Count)
                longest = temp.ToList();
        }
        return longest.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        Console.Write("input: ");
        string input = Console.ReadLine();
        var result = solution.LengthOfLongestSubstring(input);
        Console.WriteLine(result);
        Console.ReadKey();
    }
}