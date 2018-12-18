using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos
{
    public class Knapsack
    {

        ///  
        static int MaximizeProfit(int[] size, int[] value, int bag)
        {
            int minValue = value.Min();
            int[,] grid = new int[size.Length, bag - minValue + 1];

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {

                }
            }


            return int.MinValue;
        }

        public void Main()
        {

        }
    }
}
