using System;

namespace Algos
{
    /// <summary>
    ///  Notes on DP:
    ///  Every DP problem involves a grid, values in the cell are usually what you're trying to optimize
    ///  Each cell is a subproblem, so think how you can divide your problem into subproblems
    ///  Useful when you're trying to optimize something, given a constraint
    ///  When the problem can be broken down into discrete subproblems

    ///  There's no single formula for calulating the DP solution
    /// </summary>
    public class LongestCommon
    {
        /// Finds the longest common substring of two strings using DP
        static int LongestCommonSubstring(string str1, string str2)
        {
            int[,] grid = new int[str1.Length, str2.Length];

            for (int row = 0; row < str1.Length; row++)
            {
                for (int col = 0; col < str2.Length; col++)
                {
                    if (str1[row] == str2[col])
                    {
                        if (row - 1 >= 0 && col - 1 >= 0)
                        {
                            grid[row, col] = grid[row - 1, col - 1] + 1;
                        }
                        else
                        {
                            grid[row, col] = 1;
                        }
                        
                    }
                }
            }

            return FindMaxNumberInGrid(grid);
        }

        static int FindMaxNumberInGrid(int[,] grid)
        {
            int max = 0;

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] > max)
                    {
                        max = grid[row, col];
                    }
                }
            }

            return max;
        }


        public void Main()
        {
            int result = LongestCommonSubstring("blue", "clues");
            Console.WriteLine(result);
        }
    }
}
