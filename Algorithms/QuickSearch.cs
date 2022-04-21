using System.Diagnostics;

namespace TestApp.Algorithms
{
    public class QuickSearch
    {
        private const string NormalSearchFor = "Normal Search For";
        private const string NormalSearchForEach = "Normal Search ForEach";
        private const string BinaryWhile = "Binary Search While";
        private const string BinaryRecursive = "Binary Search Recursive";
        private const string LambdaWhereSearch = "Lambda Search Where";
        private const string LambdaFindSearch = "Lambda Search Find";
        private const string LinqSearch = "Linq Search Where";
        private const int NumberToFind = 999999;

        public int Loop { get; set; }
        public List<int> Array { get; set; }

        public QuickSearch()
        {
            Loop = 0;
            Array = GenerateArray(9999999);
        }

        public void Start()
        {
            Console.WriteLine($"Array Lenght: {Array.Count}");
            Console.WriteLine($"Number to find: {NumberToFind}");

            FindNumberBinarySearchWhile();
            FindNumberBinarySearchRecursive();
            FindNumberWithNormalSearchFor();
            FindNumberWithNormalSearchForEach();
            FindNumberWithLambdaWhere();
            FindNumberWithLambdaFind();
            FindNumberWithLinq();
        }

        private static List<int> GenerateArray(int count)
        {
            var index = 1;
            List<int> list = new();

            while (list.Count < count)
            {
                Random random = new();
                var look = random.Next(1, 4);

                if (look == 2)
                    list.Add(index);

                list.Add(index);
                index++;
            }

            return list;
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

        private void FindNumberBinarySearchWhile()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = BinarySearchWithWhile(Array, NumberToFind);

            timer.Stop();
            PrintResult(result != 0, BinaryWhile, timer.Elapsed.TotalMilliseconds, Loop);
        }

        private void FindNumberBinarySearchRecursive()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = BinarySearchRecursive(Array, NumberToFind, 1, Array.Count - 1);

            timer.Stop();
            PrintResult(result != 0, BinaryRecursive, timer.Elapsed.TotalMilliseconds, Loop);
        }

        private void FindNumberWithNormalSearchFor()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = ForSearch();

            timer.Stop();
            PrintResult(result, NormalSearchFor, timer.Elapsed.TotalMilliseconds, Loop);
        }

        private void FindNumberWithNormalSearchForEach()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = ForSearchEach();

            timer.Stop();
            PrintResult(result, NormalSearchForEach, timer.Elapsed.TotalMilliseconds, Loop);
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

        private bool ForSearchEach()
        {
            foreach (var item in Array)
            {
                Loop++;
                if (item == NumberToFind)
                    return true;
            }

            return false;
        }

        private void FindNumberWithLambdaWhere()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = Array.Where(x => x.Equals(NumberToFind)).FirstOrDefault();

            timer.Stop();
            PrintResult(result != 0, LambdaWhereSearch, timer.Elapsed.TotalMilliseconds, Loop);
        }

        private void FindNumberWithLambdaFind()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = Array.Find(x => x.Equals(NumberToFind));

            timer.Stop();
            PrintResult(result != 0, LambdaFindSearch, timer.Elapsed.TotalMilliseconds, Loop);
        }

        private void FindNumberWithLinq()
        {
            Loop = 0;
            Stopwatch timer = new();
            timer.Start();

            var result = from number in Array
                         where number == NumberToFind
                         select number;

            var resultInt = result.FirstOrDefault();

            timer.Stop();
            PrintResult(resultInt != 0, LinqSearch, timer.Elapsed.TotalMilliseconds, Loop);
        }

        private static void PrintResult(bool success, string searchType, double milliseconds, int loop)
        {
            if (success)
                Console.WriteLine($"[{searchType}][Timer: {milliseconds}] {loop} loops before find the number.");
            else
                Console.WriteLine($"[{searchType}][Timer: {milliseconds}] {loop} loops, number not fount.");
        }
    }
}