using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    /// <summary>
    /// a class to represent various summing to a target given an arrary of numbers
    /// </summary>
    public static class Summing
    {

        #region CanSum
        public static void RunCanSum()
        {
            Console.WriteLine(canSum(7, new int[] { 2, 3 }));        //true
            Console.WriteLine(canSum(7, new int[] { 5, 3, 4, 7 }));    //true
            Console.WriteLine(canSum(7, new int[] { 2, 4 }));        //false
            Console.WriteLine(canSum(8, new int[] { 2, 3, 5 }));      //true
            Console.WriteLine(canSum(300, new int[] { 7, 14 }));     //false
        }

        private static bool canSum(int targetSum, int[] numbers, Dictionary<int, bool>? memo = null)
        {
            if (memo == null)
                memo = new();

            if (memo.ContainsKey(targetSum)) return memo[targetSum];

            if (targetSum == 0) return true;
            if (targetSum < 0) return false;

            foreach (int i in numbers)
            {
                int remainder = targetSum - i;
                if (canSum(remainder, numbers, memo))
                {
                    memo[targetSum] = true;
                    return memo[targetSum];
                }
            }

            memo[targetSum] = false;

            return memo[targetSum];
        }
        #endregion

        #region HowSum

        public static void RunHowSum()
        {
            GetHowSumList(7, new List<int> { 2, 3 }); //[3,2,2]
            GetHowSumList(7, new List<int> { 5, 3, 4, 7 });//[4,3]
            GetHowSumList(7, new List<int> { 2, 4 });//null
            GetHowSumList(8, new List<int> { 2, 3, 5 });//[2,2,2,2]
            GetHowSumList(300, new List<int> { 7, 14 });//null   
        }


        private static void GetHowSumList(int targetSum, List<int> numbers)
        {
            List<int>? list = howSum(targetSum, numbers);
            Console.WriteLine(list == null ? "null" : string.Join(", ", list));

        }

        private static List<int>? howSum(int targetSum, List<int> numbers, Dictionary<int, List<int>?>? memo = null)
        {
            if (memo == null)
                memo = new();

            if (memo.ContainsKey(targetSum)) return memo[targetSum];
            if (targetSum == 0) return new();
            if (targetSum < 0) return null;

            foreach (var number in numbers)
            {
                int remainder = targetSum - number;
                List<int>? remainderResult = howSum(remainder, numbers, memo);
                if (remainderResult != null)
                {
                    remainderResult.Add(number);
                    memo[targetSum] = remainderResult;
                    return memo[targetSum];
                }
            }
            memo[targetSum] = null;
            return memo[targetSum];
        }



        #endregion

        #region BestSum

        public static void RunBestSum()
        {
            GetBestSumList(7, new List<int> { 5, 3, 4, 7 }); //[7]
            GetBestSumList(8, new List<int> { 2, 3, 5 });//[3,5]
            GetBestSumList(8, new List<int> { 1, 4, 5 });//[4,4]
            GetBestSumList(100, new List<int> { 1, 2, 5, 25 });//[25,25,25,25] 
        }


        private static void GetBestSumList(int targetSum, List<int> numbers)
        {
            List<int>? list = bestSum(targetSum, numbers);
            Console.WriteLine(list == null ? "null" : string.Join(", ", list));

        }

        private static List<int>? bestSum(int targetSum, List<int> numbers, Dictionary<int, List<int>?>? memo = null)
        {
            if (memo == null)
                memo = new();

            if (memo.ContainsKey(targetSum)) return memo[targetSum];
            if (targetSum == 0) return new();
            if (targetSum < 0) return null;

            List<int>? shortestList = null;

            foreach (var number in numbers)
            {
                int remainder = targetSum - number;
                List<int>? remainderResult = bestSum(remainder, numbers, memo);
                if (remainderResult != null)
                {
                    List<int>? combination = new(remainderResult);
                    combination.Add(number);
                    //memo[targetSum] = remainderResult;
                    if (shortestList == null || combination.Count < shortestList.Count)
                    {
                        shortestList = combination;
                    }
                }
            }
            memo[targetSum] = shortestList;
            return shortestList;

            #endregion
        }
    }
}
