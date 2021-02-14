using System;
using System.Collections;
using System.Collections.Generic;
/*
    * solution to the leetcode problem "Rotting Oranges"
    * https://leetcode.com/problems/rotting-oranges
*/
public class Solution {
    public int OrangesRotting(int[][] grid) {
        if (grid.Length == 0 || (grid.Length > 0 && grid[0].Length == 0))
            return 0;
        int rows = grid.Length;
        int cols = grid[0].Length;
        int time = 0;
        int fresh = 0;
        var queue = new Queue<Pair>();

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 2)
                    queue.Enqueue(new Pair(i, j));
                else if (grid[i][j] == 1)
                    fresh++;
            }
        }
        if (fresh == 0)
            return 0;

        while (fresh > 0 && queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var item = queue.Dequeue();
                int row = item.X;
                int col = item.Y;

                if (roteOrange(grid, queue, row, col - 1))
                    fresh--;
                if (roteOrange(grid, queue, row, col + 1))
                    fresh--;
                if (roteOrange(grid, queue, row - 1, col))
                    fresh--;
                if (roteOrange(grid, queue, row + 1, col))
                    fresh--;
            }
            time++;
        }
        return fresh == 0 ? time : -1;
    }
    
    private bool roteOrange(int[][] grid, Queue<Pair> queue, int row, int col)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        if (row >= 0 && col >= 0 && row < rows && col < cols && grid[row][col] == 1)
        {
            queue.Enqueue(new Pair(row, col));
            grid[row][col] = 2;
            return true;
        }
        return false;
    }
    
    private struct Pair
    {
        internal int X;
        internal int Y;

        internal Pair(int x, int y)
        {
            X = x;
            Y = y;
        } 
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        var grid1 = new int[][] {new int[] {2,1,1}, new int[] {1,1,0}, new int[] {0,1,1}};
        var grid2 = new int[][] {new int[] {2,1,1}, new int[] {0,1,1}, new int[] {1,0,1}};
        var grid3 = new int[][] {new int[] {0,2}};

        Console.WriteLine(solution.OrangesRotting(grid1));
        Console.WriteLine(solution.OrangesRotting(grid2));
        Console.WriteLine(solution.OrangesRotting(grid3));

        Console.ReadKey();
    }
}