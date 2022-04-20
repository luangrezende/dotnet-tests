namespace TestApp.Algorithms
{
    public class QuickSearch
    {
        public int Loop { get; set; }
        public int NumberToFind { get; set; }
        public List<int> Array { get; set; }

        public QuickSearch()
        {
            Loop = 0;
            NumberToFind = 5800;
            Array = GenerateArray(9999);
        }

        public void Start()
        {
            Console.WriteLine($"Array Lenght: {Array.Count}");
            Console.WriteLine($"Number to Find: {NumberToFind}");

            SearchWithBinarySearch();
            PrintResultNormalSearch();
        }

        public static List<int> GenerateArray(int count)
        {
            var index = 1;
            List<int> list = new();

            while (list.Count < count)
            {
                Random random = new();
                var look = random.Next(1, 3);

                if (look == 2)
                    list.Add(index);

                list.Add(index);
                index++;
            }

            return list;
        }

        public int BinarySearchWithWhile(int[] array, int number)
        {
            var lowerBound = 0;
            var upperBound = array.Length - 1;

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

        public int BinarySearchRecursive(List<int> array, int number, int lowerBound, int upperBound)
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

        public void SearchWithBinarySearch()
        {
            Loop = 0;
            var result = BinarySearchRecursive(Array, NumberToFind, 1, Array.Count - 1);
            //var result = BinarySearchWithWhile(PrimaryArray, NumberToFind);

            if (result != 0)
                Console.WriteLine($"[Binary Search] {Loop} loops before find the number.");
            else
                Console.WriteLine($"[Binary Search] {Loop} loops, number not fount.");
        }

        public void PrintResultNormalSearch()
        {
            Loop = 0;
            var result = CompareTwoArraysWithNormalSearch();

            if (result)
                Console.WriteLine($"[Normal Search] {Loop} loops before find the number.");
            else
                Console.WriteLine($"[Normal Search] {Loop} loops, number not fount.");
        }

        public bool CompareTwoArraysWithNormalSearch()
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
    }
}