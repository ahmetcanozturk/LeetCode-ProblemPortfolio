using System;
using System.Collections;
using System.Collections.Generic;

/*
    * solution to the leetcode problem "Kth Largest Element in a Stream"
    * https://leetcode.com/problems/kth-largest-element-in-a-stream
    * Ahmetcan Ozturk
*/
public class KthLargest
{
    private static int count;
    private SortedSet<(int,int)> numbers;
    private int k;
    public KthLargest(int k, int[] nums)
    {
        count = 0;
        if (nums.Length == 0)
            nums = new int[] { int.MinValue };
        numbers = new SortedSet<(int,int)>();
        this.k = k;
        for (int i = 0; i < nums.Length; i++)
        {
            numbers.Add((nums[i], i));
            if (numbers.Count > k)
                numbers.Remove(numbers.Min);
            count++;
        }
    }

    public int Add(int val)
    {
        if(val > numbers.Min.Item1 || k > numbers.Count)
        {
            numbers.Add((val, count));
            if (numbers.Count > k)
                numbers.Remove(numbers.Min);
            count++;
        }

        return numbers.Min.Item1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var kthLargest = new KthLargest(3, new int[] {4, 5, 8, 2});
        Console.WriteLine(kthLargest.Add(3));
        Console.WriteLine(kthLargest.Add(5));
        Console.WriteLine(kthLargest.Add(10));
        Console.WriteLine(kthLargest.Add(9));
        Console.WriteLine(kthLargest.Add(4));

        Console.ReadKey();
    }
}