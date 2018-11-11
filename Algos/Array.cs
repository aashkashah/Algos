﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos
{
    class Array
    {
        static int[] RotateLeft(int[] arr, int d)
        {
            int[] temp = new int[d];

            for (int i = 0; i < d; i++)
            {
                temp[i] = arr[i];
            }
            for(int i = d, j = 0; i < arr.Length; i++, j++)
            {
                arr[j] = arr[i];
            }
            for (int i = arr.Length - temp.Length, j = 0; i < arr.Length; i++, j++)
            {
                arr[i] = temp[j];
            }

            return arr;

        } 

        static int MaxHourglass(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int[] hour = new int[row - 2 + col - 2];
            List<int> hourglass = new List<int>();

            for (int i = 0; i < row - 2; i++)
            {
                for (int j = 0; j < col -2; j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j + 1] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    hourglass.Add(sum);
                }
            }

            return hourglass.Max();
        }

        static void minimumBribes(int[] q)
        {
            int bribeCount = 0;

            for (int i = q.Length - 1; i >= 0; i--)
            {
                if (q[i] < i + 1)
                {
                    // find num of spots this person is away
                    int spotsAway = (i + 1) - q[i];
                    bribeCount += spotsAway;
                }
                else if (q[i] > i + 1)
                {
                    // validate that this person didn't bribe more than 2 times
                    if (q[i] - (i + 1) > 2)
                    {
                        Console.WriteLine("Too chaotic");
                        return;
                    }
                }
            }

            Console.WriteLine(bribeCount);
        }

        public static void Main2(string[] args)
        {
            int[,] matrix = new int[,] 
            { 
                { -9, -9, -9, 1, 1, 1 },
                { 0, -9,  0,  4, 3, 2 },
                { -9, -9, -9, 1, 2, 3 },
                { 0,  0,  8,  6, 6, 0 },
                { 0,  0,  0, -2, 0, 0 },
                { 0,  0,  1,  2, 4, 0 }
            };

            //int maxHourglass = MaxHourglass(matrix);
            //Console.WriteLine(maxHourglass);

            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            //int[] leftRotate = RotateLeft(arr, 3);
            //Console.WriteLine(leftRotate);

            int[] queue = new int[] { 1, 2, 5, 3, 7, 8, 6, 4 };
            minimumBribes(queue);

        }
    }
}
