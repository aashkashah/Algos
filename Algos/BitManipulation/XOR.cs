using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
	public class XOR
	{
		static int lonelyinteger(int[] a)
		{
			int res = a[0];
			for (int i = 1; i < a.Length; i++)
			{
				res = res ^ a[i];
			}

			return res;
		}

		public void Main_Bit(string[] args)
		{
			int result = lonelyinteger(new int[] { 1, 2, 3, 1, 2, 5, 5 });
			Console.WriteLine(result);

		}
	}
}
