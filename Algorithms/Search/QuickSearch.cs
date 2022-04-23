using System.Diagnostics;
using TestApp.Utils;

namespace TestApp.Algorithms.Search
{
    public class QuickSearch
    {
        public int NumberToFind { get; }
        public int ArrayCount { get; }

        private int Loop { get; set; }
        private List<int> Array { get; set; }
        private const string NormalSearchFor = "Normal Search For";
        private const string NormalSearchForEach = "Normal Search ForEach";
        private const string BinaryWhile = "Binary Search While";
        private const string BinaryRecursive = "Binary Search Recursive";
        private const string LambdaWhereSearch = "Lambda Search Where";
        private const string LambdaFindSearch = "Lambda Search Find";
        private const string LinqSearch = "Linq Search Where";
        
        public QuickSearch(int numberToFind, int arrayLimit)
        {
            Loop = 0;
            NumberToFind = numberToFind;
            Array = ArrayUtil.GenerateOrdenedAndDuplicatedValuesArray(arrayLimit);
            ArrayCount = Array.Count;
        }

        private int BinarySearchWithWhile(List<int> array, int number)
        {
            var lowerBound = 0;
            var upperBound = array.Count - 1;

            while (lowerBound <= upperBound)
            {
                Loop++;
                var midPoint = (lowerBound + upperBound) / 2;
                var selectedNumber = array[midPoint];

                if (selectedNumber > number)
                    upperBound = midPoint - 1;
                else if (selectedNumber < number)
                    lowerBound = midPoint + 1;
                else
                    return selectedNumber;
            };
            
            return 0;
        }

        private int BinarySearchRecursive(List<int> array, int number, int lowerBound, int upperBound)
        {
            Loop++;
            int midPoint = (lowerBound + upperBound) / 2;
            var selectedNumber = array[midPoint];

            if (selectedNumber == number)
                return number;
            else if (lowerBound >= upperBound)
                return 0;
            else if (selectedNumber > number)
                return BinarySearchRecursive(array, number, lowerBound, midPoint - 1);
            else
                return BinarySearchRecursive(array, number, midPoint + 1, upperBound);
        }

        public void FindNumberBinarySearchWhile()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = BinarySearchWithWhile(Array, NumberToFind);

            timer.Stop();
            PrintUtil.PrintResultAndTimelapse(result != 0, BinaryWhile, timer.Elapsed.TotalMilliseconds, Loop);
        }

        public void FindNumberBinarySearchRecursive()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = BinarySearchRecursive(Array, NumberToFind, 1, Array.Count - 1);

            timer.Stop();
            PrintUtil.PrintResultAndTimelapse(result != 0, BinaryRecursive, timer.Elapsed.TotalMilliseconds, Loop);
        }

        public void FindNumberWithNormalSearchFor()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = ForSearch();

            timer.Stop();
            PrintUtil.PrintResultAndTimelapse(result, NormalSearchFor, timer.Elapsed.TotalMilliseconds, Loop);
        }

        public void FindNumberWithNormalSearchForEach()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = ForEachSearch();

            timer.Stop();
            PrintUtil.PrintResultAndTimelapse(result, NormalSearchForEach, timer.Elapsed.TotalMilliseconds, Loop);
        }

        private bool ForSearch()
        {
            for (int i = 0; i < Array.Count; i++)
            {
                Loop++;
                var numberSelected = Array[i];
                if (NumberToFind == numberSelected)
                    return true;
            }

            return false;
        }

        private bool ForEachSearch()
        {
            foreach (var item in Array)
            {
                Loop++;
                if (item == NumberToFind)
                    return true;
            }

            return false;
        }

        public void FindNumberWithLambdaWhere()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = Array.Where(x => x.Equals(NumberToFind)).FirstOrDefault();

            timer.Stop();
            PrintUtil.PrintResultAndTimelapse(result != 0, LambdaWhereSearch, timer.Elapsed.TotalMilliseconds, Loop);
        }

        public void FindNumberWithLambdaFind()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = Array.Find(x => x.Equals(NumberToFind));

            timer.Stop();
            PrintUtil.PrintResultAndTimelapse(result != 0, LambdaFindSearch, timer.Elapsed.TotalMilliseconds, Loop);
        }

        public void FindNumberWithLinq()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = from number in Array
                         where number == NumberToFind
                         select number;

            var resultInt = result.FirstOrDefault();

            timer.Stop();
            PrintUtil.PrintResultAndTimelapse(resultInt != 0, LinqSearch, timer.Elapsed.TotalMilliseconds, Loop);
        }
    }
}