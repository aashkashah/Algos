using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class SuperMain
    {
        public static void Main(string[] args)
        {
            // use this method to initiate sub programs 
            BalancedBrackets bb = new BalancedBrackets();
            bb.Main_Stack(args);

            Console.ReadLine();
        }
    }
}
