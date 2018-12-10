using System;

namespace Algos
{
    class SuperMain
    {
        public static void Main(string[] args)
        {
			// use this method to initiate sub programs 
			ChessBoard cb = new ChessBoard();
			cb.Main_Chess();

			Console.ReadLine();
        }
    }
}
