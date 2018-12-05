using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos
{
    class ArrayChallenges
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

        // Sparse arrays
        // https://www.hackerrank.com/challenges/sparse-arrays/problem
        static int[] matchingStrings(string[] strings, string[] queries)
        {
            int[] result = new int[queries.Length];
            Dictionary<string, int> occurance = new Dictionary<string, int>();

            for (int i = 0; i < strings.Length; i++)
            {
                if (occurance.ContainsKey(strings[i]))
                {
                    int count = occurance[strings[i]];
                    occurance[strings[i]] = count + 1;
                }
                else
                {
                    occurance.Add(strings[i], 1);
                }
            }
            
            for(int i = 0; i < queries.Length; i++)
            {
                if (occurance.ContainsKey(queries[i]))
                {
                    result[i] = occurance[queries[i]];
                }
            }

            return result;
        }

        // https://www.hackerrank.com/challenges/crush/problem
        static long arrayManipulation(int n, int[][] queries)
        {
            long[] result = new long[n];

            for(int i = 0; i < queries.Length; i++)
            {
                for (int j = queries[i][0] - 1; j <= queries[i][1] - 1; j++)
                {
                    result[j] = result[j] + queries[i][2];
                }
            }

            long max = long.MinValue;

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] > max)
                {
                    max = result[i];
                }
            }

            return max;
        }

        /// <summary>
        ///  Flip a matrix in a by moving max sum to upper left quadrant
        ///  Upper left quadrant : n/2 x n/2
        ///  https://www.hackerrank.com/challenges/flipping-the-matrix/problem
        /// </summary>
        /// <returns>Max sum of top left sub matrix (quadrant)</returns>
        static int FlippingMatrix(int[][] matrix)
        {

            for (int i = 0; i < matrix.Length; i++)
            {
                if (shouldFlipColumn(matrix, i))
                {
                    flipColumn(ref matrix, i);
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                if (shouldFlipRow(matrix, i))
                {
                    flipRow(ref matrix, i);
                }
            }

            int sum = 0;

            for (int i = 0; i < matrix.Length / 2; i++)
            {
                for (int j = 0; j < matrix.Length / 2; j++)
                {
                    sum += matrix[i][j];
                }
            }

            return sum;
        }

        static bool shouldFlipColumn(int[][] matrix, int index)
        {
            int upperSum = 0;
            int lowerSum = 0;

            for (int i = 0, j = matrix.Length - 1 ; i < matrix.Length/2; i++, j--)
            {
                upperSum += matrix[i][index];
                lowerSum += matrix[j][index];
            }

            return lowerSum > upperSum ? true : false;
        }

        static bool shouldFlipRow(int[][] matrix, int index)
        {
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0, j = matrix.Length - 1; i < matrix.Length / 2; i++, j--)
            {
                leftSum += matrix[index][i];
                rightSum += matrix[index][j];
            }

            return rightSum > leftSum ? true : false;
        }

        static void flipColumn(ref int[][] matrix, int index)
        {
            for (int i = 0, j = matrix.Length - 1; i < matrix.Length / 2; i++, j--)
            {
                int temp = matrix[i][index];
                matrix[i][index] = matrix[j][index];
                matrix[j][index] = temp;
            }
        }

        static void flipRow(ref int[][] matrix, int index)
        {
            for (int i = 0, j = matrix.Length - 1; i < matrix.Length / 2; i++, j--)
            {
                int temp = matrix[index][i];
                matrix[index][i] = matrix[index][j];
                matrix[index][j] = temp;
            }
        }

        /// Bob and Andy play a game of remove max elem and elems after max elem from list 
        /// whoever isn't able to remove an elem loses
        /// Bob starts first
        /// https://www.hackerrank.com/challenges/an-interesting-game-1/problem
        static String GamingArray(List<int> arr)
        {   
            int turn = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                int index = FindMaxElementIndex(ref arr);
                RemoveMaxAndElemAfterMax(ref arr, index);
                turn++;
            }
            
            if (turn % 2 == 1)
            {
                // odd number representing Bob's win
                return "BOB";
            }
            else
            {
                return "ANDY";
            }
        }

        static int FindMaxElementIndex(ref List<int> arr)
        {
            int max = arr[0];
            int maxIndex = 0;
            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        static void RemoveMaxAndElemAfterMax(ref List<int> arr, int index)
        {
            arr.RemoveRange(index, arr.Count - index);
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

            //int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            //int[] leftRotate = RotateLeft(arr, 3);
            //Console.WriteLine(leftRotate);

            //int[] queue = new int[] { 1, 2, 5, 3, 7, 8, 6, 4 };
            //minimumBribes(queue);

            //int[] result = matchingStrings(new string[] { "def", "de", "fgh" }, new string[] { "de", "lmn", "fgh" });
            //Console.WriteLine(result);

            //long result = arrayManipulation(5, new int[][]
            //                {
            //                    new int[] { 1, 2, 100 },
            //                    new int[] { 2, 5, 200 },
            //                    new int[] { 3, 4, 100 }
            //                });

            //int[][] flipMatrix = new int[][]
            //{
            //    new int[] { 112, 42, 83, 119},
            //    new int[] { 56, 125, 56, 49},
            //    new int[] { 15, 78, 101, 43},
            //    new int[] { 62, 98, 114, 109},
            //};

            //var maxSum = FlippingMatrix(flipMatrix);
            //Console.WriteLine(maxSum);

            var winner = GamingArray(new List<int> { 5, 2, 6, 3, 4 });
            Console.Write(winner);

            Console.ReadLine();
        }
    }
}
