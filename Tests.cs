using System.Diagnostics;
using TestApp.Algorithms;
using TestApp.Algorithms.Search;
using TestApp.Utils;

namespace TestApp
{
    public static class Tests
    {
        public static void StartTests()
        {
            //QuickSearchTests();
            MegaSenaTests();
        }

        public static void QuickSearchTests()
        {
            var quickSearch = new QuickSearch(58000, 9999999);
            
            Console.WriteLine($"[QUICK SEARCH]");
            Console.WriteLine($"Array Lenght: {quickSearch.ArrayCount}");
            Console.WriteLine($"Number to find: {quickSearch.NumberToFind}");

            quickSearch.FindNumberBinarySearchWhile();
            quickSearch.FindNumberBinarySearchRecursive();
            quickSearch.FindNumberWithNormalSearchFor();
            quickSearch.FindNumberWithNormalSearchForEach();
            quickSearch.FindNumberWithLambdaWhere();
            quickSearch.FindNumberWithLambdaFind();
            quickSearch.FindNumberWithLinq();
        }

        public static void MegaSenaTests()
        {
            Console.WriteLine($"[MEGASENA]");
            Console.WriteLine($"This algorithm will find a number that are not played yet");

            var megaSena = new MegaSena(999999, 6);

            Stopwatch timer = new();
            timer.Start();

            var resultNormal = megaSena.GetWinnerWithNormalMethod();
            timer.Stop();

            Console.WriteLine($"Winner Number: {string.Join(", ", resultNormal)}");
            PrintUtil.PrintResultAndTimelapse(true, "MegaSenaTests - Normal", timer.Elapsed.TotalMilliseconds, 0);

            timer.Reset();
            timer.Start();

            var resultBinary = megaSena.GetWinnerWithNormalMethod();
            timer.Stop();

            Console.WriteLine($"Winner Number: {string.Join(", ", resultBinary)}");
            PrintUtil.PrintResultAndTimelapse(true, "MegaSenaTests - Binary", timer.Elapsed.TotalMilliseconds, 0);
        }
    }
}
