using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public static class Fibonacci
    {
        public static void Run()
        {
            Console.WriteLine(fib(10));
            Console.WriteLine(fib(25));
            Console.WriteLine(fib(50));
        }

        private static ulong fib(int n, Dictionary<int, ulong>? memo = null)
        {

            if (memo == null)
                memo = new();

            if (memo.ContainsKey(n))
                return memo[n];

            if (n <= 2)
                return 1;

            memo[n] = fib(n - 1, memo) + fib(n - 2, memo);

            return memo[n];
        }
    }
}
