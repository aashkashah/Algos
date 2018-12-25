using System;
using System.Linq;

namespace Algos
{
    public class Knapsack
    {
        static int MaximizeProfit(int[] size, int[] value, int bag)
        {
            int minValue = value.Min();
            int[,] grid = new int[size.Length, bag - minValue + 1];

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (size[row] >= col)
                    {
                        if (row - 1 >= 0 && col - 1 >= 0)
                        {
                            grid[row, col] = Math.Max(grid[row - 1, col - 1], value[row] + grid[row - 1, col - size[row]]);
                        }
                        else
                        {
                            grid[row, col] = value[row];
                        }
                    }
                }
            }


            return grid[grid.GetLength(0) - 1, grid.GetLength(1) - 1];
        }

        public void Main()
        {

        }
    }
}
