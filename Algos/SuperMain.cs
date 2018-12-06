using System;

namespace Algos
{
    class SuperMain
    {
        public static void Main(string[] args)
        {
			// use this method to initiate sub programs 
			XOR xor = new XOR();
			xor.Main_Bit(args);

            Console.ReadLine();
        }
    }
}
