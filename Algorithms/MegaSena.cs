namespace TestApp.Algorithms
{
    public class MegaSena
    {
        public int LimitPlays { get; }
        public int PointsLimit { get; }

        public List<List<int>> NumberPlayed { get; set; }

        public MegaSena(int limitPlays, int limitPoints) {
            LimitPlays = limitPlays;
            PointsLimit = limitPoints;
            NumberPlayed = new List<List<int>>();
            GeneratePlayedNumbers();
        }

        public List<int> GetWinnerWithNormalMethod()
        {
            var findingNumber = true;
            var sortedNumber = new List<int>();

            while (findingNumber)
            {
                sortedNumber = GenereteSortedNumber();
                findingNumber = VerifyIfAllNumbersExists(sortedNumber);
            }
            return sortedNumber;
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

                if (points >= PointsLimit)
                    return true;
            }

            return false;
        }

        private void GeneratePlayedNumbers()
        {
            var quantityGeneratedNumbers = 0;

            while (LimitPlays > quantityGeneratedNumbers)
            {
                NumberPlayed.Add(GenereteSortedNumber());
                quantityGeneratedNumbers++;
            }
        }

        private static List<int> GenereteSortedNumber()
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