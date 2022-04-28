using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DynamicProgramming
{
    public static class GridTraveler
    {
        public static void Run()
        {
            Console.WriteLine(gridTraveler(1, 1)); //1
            Console.WriteLine(gridTraveler(2, 3)); //3
            Console.WriteLine(gridTraveler(3, 2)); //3
            Console.WriteLine(gridTraveler(3, 3)); //6
            Console.WriteLine(gridTraveler(18, 18)); //2333606220
            Console.WriteLine(gridTraveler(500,500));
        }

        private static ulong gridTraveler(int m, int n, Dictionary<string, ulong>? memo = null)
        {
            if (memo == null)
                memo = new();

            string key = m <= n ?  $"{m},{n}" : $"{n},{m}";

            if(memo.ContainsKey(key)) return memo[key];
            if (m == 1 && n == 1) return 1;
            if (m == 0 || n == 0) return 0;

            memo[key] = gridTraveler(m-1, n, memo) + gridTraveler(m, n-1, memo);

            return memo[key];
        }
    }
    
}
