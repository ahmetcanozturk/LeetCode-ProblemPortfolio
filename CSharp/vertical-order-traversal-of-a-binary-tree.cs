using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/*
    * solution to the leetcode problem "Vertical Order Traversal of a Binary Tree"
    * https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree
*/
public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        if (root == null)
            return null;

        var map = new SortedDictionary<int, List<(int,int)>>();

        verticalOrder(root, 0, 0, map);

        var result = new List<IList<int>>();
        if(map != null)
        {
            foreach(var item in map)
                result.Add(item.Value.OrderBy(x => x.Item2).ThenBy(x => x.Item1).Select(x => x.Item1).ToList());
        }
        return result;
    }

    // recursive
    private void verticalOrder(TreeNode root, int horizontalDistance, int level, SortedDictionary<int, List<(int,int)>> map)
    {
        if (root == null)
            return;

        // store/modify currenct node in map
        if(!map.ContainsKey(horizontalDistance))
        {
            map.Add(horizontalDistance, new List<(int,int)> { (root.val, level) });
        }
        else
        {
            // get the element list at horizontal distance and add node value
            map[horizontalDistance].Add((root.val, level));
        }

        // nodes in left subtree
        verticalOrder(root.left, horizontalDistance - 1, level + 1, map);

        // nodes in right subtree
        verticalOrder(root.right, horizontalDistance + 1, level + 1, map);
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }

    public TreeNode(int x = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = x;
        this.left = left;
        this.right = right;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        //[3,9,20,null,null,15,7]
        var root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(7);

        var result = solution.VerticalTraversal(root);
        foreach (var item in result)
            Console.WriteLine(string.Join(",", item));

        Console.ReadKey();
    }
}