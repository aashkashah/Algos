using System;
using System.Collections.Generic;

namespace Algos
{
	public class ChessBoard
	{	
		/// Start from an initital position and move along the board
		/// to place 8 queens across the chess board

		static void QueensTour(int[,] board)
		{
			QueensTourHelper(ref board, 0);
		}

		static bool QueensTourHelper(ref int[,] board, int column)
		{
			if (column >= 8)
			{
				// print board
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						Console.Write(board[i, j] + " ");
					}
					Console.WriteLine();
				}
				Console.WriteLine();
				return true;
			}
			else
			{
				for (int row = 0; row < 8; row++)
				{
					if (IsSafe(board, row, column))
					{
						// choose
						PlaceChessPiece(ref board, row, column);

						// explore
						bool result = QueensTourHelper(ref board, column + 1);
						if (result)
						{
							return true;
						}

						// un-choose
						RemoveChessPiece(ref board, row, column);
					}
				}

				return false;
			}
		}
		
		static bool IsSafe(int[,] board, int row, int col)
		{
			// validate rows
			for (int i = 0; i < 8; i++)
			{
				if (board[row, i] == 1)
				{
					return false;
				}
			}

			// validate columns
			for (int i = 0; i < 8; i++)
			{
				if (board[i, col] == 1)
				{
					return false;
				}
			}

			// validate diagonals
			// validate NE
			int j = col;
			for (int i = row; i >= 0; i--)
			{	
				if(board[i, j] == 1)
				{
					return false;
				}
				j++;
				if (j >= 8)
					break;
			}

			// validate SE
			j = col;
			for (int i = row; i < 8; i++)
			{	
				if (board[i, j] == 1)
				{
					return false;
				}
				j++;
				if (j >= 8)
					break;
			}

			// validate NW
			j = col;
			for (int i = row; i >= 0; i--)
			{	
				if (board[i, j] == 1)
				{
					return false;
				}
				j--;
				if (j < 0)
					break;
			}

			// validate SW
			j = col;
			for (int i = row; i < 8; i++)
			{	
				if (board[i, j] == 1)
				{
					return false;
				}
				j--;
				if (j < 0)
					break;
			}

			return true;
		}

		static void PlaceChessPiece(ref int[,] board, int row, int col)
		{
			board[row, col] = 1;
		}

		static void RemoveChessPiece(ref int[,] board, int row, int col)
		{
			board[row, col] = 0;
		}

		public void Main_Chess()
		{
			int[,] board = new int[8,8];
			QueensTour(board);
		}
	}
}
