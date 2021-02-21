using System;
/*
    * solution to the leetcode problem "Two Sum"
    * https://leetcode.com/problems/two-sum
    * Ahmetcan Ozturk
*/
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        bool found = false;
        int counter1 = 0;
        int counter2 = 1;
        int[] item = new int[2];
        while(!found && counter1<nums.Length) {
            while(!found && counter2<nums.Length) {
                found = (nums[counter1] + nums[counter2] == target);
                if(found) {
                    item[0] = counter1;
                    item[1] = counter2;
                }
                counter2++;
            }
            counter1++;
            counter2 = counter1 + 1;
        }
        return item;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        var arr = new int[] { 2, 7, 11, 15 };
        int target = 9;
        var result = solution.TwoSum(arr, target);
        Console.WriteLine(string.Join(",", result));
        Console.ReadKey();
    }
}