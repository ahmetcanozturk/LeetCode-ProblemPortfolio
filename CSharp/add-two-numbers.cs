using System;
/*
    * solution to the leetcode problem "Add Two Numbers"
    * https://leetcode.com/problems/add-two-numbers
    * Ahmetcan Ozturk
*/
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        int sum = (l1.val + l2.val) % 10;
        int remainder = (l1.val + l2.val) < 10 ? 0 : 1;
        ListNode result = new ListNode(sum);
        bool finished = (l1.next == null) && (l2.next == null);
        while(!finished) {
            l1 = popNode(l1);
            l2 = popNode(l2);
            finished = (l1 == null || (l1 != null && l1.next == null)) && (l2 == null || (l2 != null && l2.next == null));
            int val1 = l1 != null ? l1.val : 0;
            int val2 = l2 != null ? l2.val : 0;
            sum = (val1 + val2 + remainder) % 10;
            remainder = (val1 + val2 + remainder) < 10 ? 0 : 1;
            result = addNode(result, new ListNode(sum));
        }

        if(remainder == 1)
            result = addNode(result, new ListNode(remainder));
        return result;
    }
    
    private ListNode addNode(ListNode head, ListNode node)
    {
        ListNode temp = head;
        while (temp.next != null)
            temp = temp.next;
        temp.next = node;
        return head;
    }
    
    private static ListNode popNode(ListNode top)
    {
        if (top != null)
            top = top.next;
        else
            return null;
        return top;
    }
}

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        // test input
        var arr1 = new int[] { 2, 4, 3 };
        var arr2 = new int[] { 5, 6, 4 };
        var l1 = new ListNode(arr1[0]);
        var l2 = new ListNode(arr2[0]);
        for (int i = 1; i < arr1.Length; i++)
        {
            var node = new ListNode(arr1[i]);
            node.next = l1;
            l1 = node;
        }
        for (int i = 1; i < arr2.Length; i++)
        {
            var node = new ListNode(arr2[i]);
            node.next = l2;
            l2 = node;
        }

        var result = solution.AddTwoNumbers(l1, l2);

        Console.WriteLine(result.val);
        while (result.next != null)
        {
            result = result.next;
            Console.WriteLine(result.val);
        }

        Console.ReadKey();
    }
}