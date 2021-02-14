using System;
/*
    * solution to the leetcode problem "Container With Most Water"
    * https://leetcode.com/problems/container-with-most-water
*/
public class Solution
{
    public int MaxArea(int[] height)
    {
        if (height.Length == 0)
            return 0;

        int curr = 0, area = 0;
        int i =0, j = height.Length - 1;

        while(i < height.Length && j>0)
        {
            if(height[i] > height[j])
            {
                curr = height[j] * (j - i);
                j--;
            }
            else
            {
                curr = height[i] * (j - i);
                i++;
            }

            if (curr > area)
                area = curr;
        }
        return area;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        //var arr = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        var arr = new int[] { 1, 2, 1, 4, 2 };
        var result = solution.MaxArea(arr);
        Console.WriteLine(result);
        Console.ReadKey();
    }
}