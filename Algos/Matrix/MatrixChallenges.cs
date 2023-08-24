using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public class MatrixChallenges
    {
        enum Direction
        {
            Right,
            Down,
            Left,
            Top
        }
        static void NumbersInSpiralOrder(char[,] matrix)
        {

            int row = 0;
            int col = 0;
            int rowEnd = 1;
            int colEnd = 0;

            Direction direction = Direction.Right;
            int endBracket = matrix.Length;

            for (int k = 0; k < matrix.Length * 4; k++)
            {
                Console.WriteLine(matrix[row, col]);

                if (row == rowEnd && col == colEnd)
                {
                    rowEnd = rowEnd++;
                    colEnd = colEnd++;
                    direction = Direction.Right;
                    endBracket = endBracket - 1;
                }


                if (Direction.Right == direction)
                {
                    col++;
                }
                else if (Direction.Down == direction)
                {
                    row++;
                }
                else if (Direction.Left == direction)
                {
                    col--;
                }
                else if (Direction.Top == direction)
                {
                    row--;
                }

                if (col == endBracket)
                {
                    direction = Direction.Down;
                    row++;
                    col--;
                }
                else if (row == endBracket && col == endBracket - 1)
                {
                    direction = Direction.Left;
                    row--;
                    col--;
                }
                else if (row == endBracket - 1 && col < colEnd)
                {
                    direction = Direction.Top;
                    col++;
                    row--;
                }
            }
        }

        public void Main()
        {
            char[,] matrix = new char[,]
            {
                { 'a', 'b', 'c', 'd' },
                { 'e', 'f', 'g', 'h' },
                { 'i', 'j', 'k', 'l' },
                { 'm', 'n', 'n', 'o' }
            };

            NumbersInSpiralOrder(matrix);

            Console.ReadLine();
        }
    }
}
