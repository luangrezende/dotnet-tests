namespace TestApp.Utils
{
    public static class ArrayUtil
    {
        public static List<int> GenerateOrdenedAndDuplicatedValuesArray(int count)
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

        public static List<int> GenerateRandomArray(int count)
        {
            List<int> list = new();

            while (list.Count < count)
            {
                Random random = new();
                var randomNumber = random.Next(1, 999);

                list.Add(randomNumber);
            }

            return list;
        }
    }
}
