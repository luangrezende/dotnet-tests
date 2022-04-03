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

                //teste apenas
                //NumerosJogados.Add(numeroSorteado);

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
            var pointsLimit = 6;
            var points = 0;

            foreach (var numbersPlayed in NumberPlayed)
            {
                points = 0;
                foreach (var number in sortedNumber)
                {
                    var contais = numbersPlayed.Contains(number);

                    if (contais)
                        points++;
                }
            }

            return points >= pointsLimit;
        }

        public void GeneratePlayedNumbers()
        {
            var limit = 150;
            var quantityGeneratedNumbers = 0;

            while (limit > quantityGeneratedNumbers)
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
