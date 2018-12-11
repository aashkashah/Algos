using System;
using System.Collections.Generic;
using Coordinate = Algos.Matrix.Coordinate;

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
					if (IsSafeToPlaceQueen(board, row, column))
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
		
		static bool IsSafeToPlaceQueen(int[,] board, int row, int col)
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

		static void PlaceChessPiece(ref int[,] board, int row, int col, int value = 1)
		{
			board[row, col] = value;
		}

		static void RemoveChessPiece(ref int[,] board, int row, int col)
		{
			board[row, col] = 0;
		}

		static bool CanPlaceChessPiece(int[,] board, int row, int col)
		{
			if (board[row, col] == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		static void KnightsTour(int[,] board)
		{
			board[0, 0] = 1;
			KnightsTourHelper(ref board, 0, 0, 0);
		}

		static bool KnightsTourHelper(ref int[,] board, int row, int col, int moveNumber)
		{
			// base case
			if (IsBoardFull(board))
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
				return true;
			}
			else
			{	
				// find possible moves, iterate through
				var moves = FindKnightsPossibleMoves(board, row, col);

				// cannot move through this path and the board is still un traversed
				if (moves.Count == 0 && IsBoardFull(board) == false)
				{
					return false;
				}

				foreach (Coordinate move in moves)
				{	
					// choose
					PlaceChessPiece(ref board, move.X, move.Y, moveNumber);

					// explore
					var result = KnightsTourHelper(ref board, move.X, move.Y, moveNumber + 1);
					if (result)
					{
						return true;
					}

					// un-choose
					RemoveChessPiece(ref board, move.X, move.Y);
					
				}

				return false;
			}
		}

		static List<Coordinate> FindKnightsPossibleMoves(int[,] board, int row, int col)
		{
			var moves = new List<Coordinate>();

			// Knight's available moves: 
			// up right,  up left, down right, down left
			// left sideways up, left sideways down, right sideways up, right sideways down

			int[] xVal = new int[] { -2, -2, 2, 2, -1, 1, -1, 1 };
			int[] yVal = new int[] { 1, -1, 1, -1, -2, -2, 2, 2 };

			for (int i = 0; i < 8; i++)
			{
				int rowVal = row + xVal[i];
				int colVal = col + yVal[i];

				if (rowVal >= 0 && rowVal < 8 && colVal >= 0 && colVal < 8 && CanPlaceChessPiece(board, rowVal, colVal))
				{
					moves.Add(new Coordinate() { X = rowVal, Y = colVal });
				}
			}

			return moves;
		}

		static bool IsBoardFull(int[,] board)
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (board[i, j] == 0)
						return false;
				}
			}

			return true;
		}

		public void Main_Chess()
		{
			int[,] board = new int[8,8];
			
			//QueensTour(board);

			KnightsTour(board);
		}
	}
}
