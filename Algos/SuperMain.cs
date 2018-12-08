using System;

namespace Algos
{
    class SuperMain
    {
        public static void Main(string[] args)
        {
			// use this method to initiate sub programs 
			Test t = new Test();
			t.Main(args);

			Console.ReadLine();
        }
    }
}
