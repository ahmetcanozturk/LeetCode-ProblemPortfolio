using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCodeProblemSolutions
{
    /*
     * solution to the leetcode problem "Next Greater Element II"
     * https://leetcode.com/problems/next-greater-element-ii
    */
    public class Solution 
    {
        public int[] NextGreaterElements(int[] nums) {
            if (nums.Length == 0)
                return new int[] { };
            var arr = new int[nums.Length * 2];
            int n = arr.Length;
            var result = new int[nums.Length];

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                if(i < nums.Length)
                {
                    result[i] = -1;
                    arr[i] = nums[i];
                    arr[nums.Length + i] = nums[i];
                }

                while (stack.Count > 0 && arr[i] > nums[stack.Peek()])
                {
                    result[stack.Peek()] = arr[i];
                    stack.Pop();
                }
                if(i < nums.Length)
                    stack.Push(i);
            }

            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var elements = solution.NextGreaterElements(new int[] {3, 2, 5, 4, 3, 6, 2, 1, 2});
            for(int i = 0; i<elements.Length; i++)
                Console.WriteLine(elements[i]);

            Console.ReadKey();
        }
    }
}