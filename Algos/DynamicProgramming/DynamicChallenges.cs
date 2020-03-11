using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class DynamicChallenges
    {
        public int ClimbStairs(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i < n+1; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];

            }

            return dp[n];
        }

        public void Main()
        {
            var res = ClimbStairs(4);

            Console.WriteLine(res);

            Console.ReadLine();
        }
    }
}
