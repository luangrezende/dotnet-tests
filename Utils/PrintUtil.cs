namespace TestApp.Utils
{
    public static class PrintUtil
    {
        public static void PrintArrayInLine(List<int> array)
        {
            var arrayCount = array.Count - 1;
            var text = "";
            var startPoint = 0;
            var endPoint = arrayCount - 3;

            Console.WriteLine("[RESULT]");

            while (startPoint <= 3)
            {
                text += $"{array[startPoint]}, ";
                startPoint++;
            };

            text = $"{text.Remove(text.Length - 2)} ... ";

            while (endPoint <= arrayCount)
            {
                text += $"{array[endPoint]}, ";
                endPoint++;
            };

            Console.Write(text.Remove(text.Length - 2));
        }

        public static void PrintResultAndTimelapse(bool success, string methodName, double milliseconds, int loop)
        {
            if (success)
                Console.WriteLine($"[{methodName}][Timer: {milliseconds}] {loop} loops before find the number.");
            else
                Console.WriteLine($"[{methodName}][Timer: {milliseconds}] {loop} loops, number not fount.");
        }
    }
}
