using System;
using System.Collections.Generic;
/*
    * solution to the leetcode problem "Letter Combinations of a Phone Number"
    * https://leetcode.com/problems/letter-combinations-of-a-phone-number
*/
public class Solution {
    public IList<string> LetterCombinations(string digits) {
        if(string.IsNullOrEmpty(digits))
            return new List<string>();
        var letters = new Dictionary<string, string>()
        {
            { "2", "abc" },
            { "3", "def" },
            { "4", "ghi" },
            { "5", "jkl" },
            { "6", "mno" },
            { "7", "pqrs" },
            { "8", "tuv" },
            { "9", "wxyz" }
        };
        var arr = digits.ToCharArray();
        
        var combinations = new Queue<string>();
        combinations.Enqueue("");
        for (int i = 0; i < arr.Length; i++)
        {
            while(combinations.Peek().Length == i)
            {
                string item = combinations.Dequeue();
                var values = letters[arr[i].ToString()].ToCharArray();
                foreach (var c in values)
                    combinations.Enqueue(item + c);
            }
        }

        return combinations.ToArray();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        Console.WriteLine(string.Join(" ", solution.LetterCombinations("23")));
        Console.WriteLine(string.Join(" ", solution.LetterCombinations("")));
        Console.WriteLine(string.Join(" ", solution.LetterCombinations("2")));

        Console.ReadKey();
    }
}