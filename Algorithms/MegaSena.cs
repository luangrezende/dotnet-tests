using TestApp.Enums;

namespace TestApp.Algorithms
{
    public class MegaSena
    {
        public List<List<int>> NumberPlayed { get; set; }

        public MegaSena() {
            NumberPlayed = new List<List<int>>();
            GeneratePlayedNumbers();
        }

        public void GetWinner()
        {
            var findingNumber = true;

            while (findingNumber)
            {
                var sortedNumber = GenereteSortedNumber();

                //to test only
                //NumberPlayed.Add(sortedNumber);

                var containsWinner = VerifyIfAllNumbersExists(sortedNumber);

                if (containsWinner)
                    Console.WriteLine("The list contains the number sorted - Loading again...");
                else
                {
                    Console.WriteLine($"Sorted Number: {string.Join(", ", sortedNumber)}");
                    findingNumber = false;
                }
            }
        }

        private bool VerifyIfAllNumbersExists(List<int> sortedNumber)
        {
            foreach (var numbersPlayed in NumberPlayed)
            {
                var points = 0;
                foreach (var number in sortedNumber)
                {
                    var contais = numbersPlayed.Contains(number);

                    if (contais)
                        points++;
                }

                if (points >= (int)MegaSenaEnum.pointsLimit)
                    return true;
            }

            return false;
        }

        public void GeneratePlayedNumbers()
        {
            var quantityGeneratedNumbers = 0;

            while ((int)MegaSenaEnum.limitPlays > quantityGeneratedNumbers)
            {
                NumberPlayed.Add(GenereteSortedNumber());
                quantityGeneratedNumbers++;
            }
        }

        public List<int> GenereteSortedNumber()
        {
            var sortedNumbers = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                var random = new Random();
                var generatedNumber = random.Next(1, 99);

                sortedNumbers.Add(generatedNumber);
            }

            sortedNumbers.Sort();
            return sortedNumbers;
        }
    }
}
