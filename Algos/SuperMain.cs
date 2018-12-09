using System;

namespace Algos
{
    class SuperMain
    {
        public static void Main(string[] args)
        {
            // use this method to initiate sub programs 
            SlidingWindow sw = new SlidingWindow();
            sw.Main(args);

			Console.ReadLine();
        }
    }
}
