using TestApp.Utils;

namespace TestApp.Algorithms.Ordenation
{
    public class QuickSort
    {
		private const int Limit = 999;

		public List<int> Array { get; set; }

		public QuickSort()
        {
			Array = ArrayUtil.GenerateRandomArray(Limit);
		}

		public void Start()
		{
			int inicio = 0;
			int fim = Array.Count - 1;

			var result = QuickSortVetor(Array, inicio, fim);

			PrintUtil.PrintArrayInLine(result);
		}

		private List<int> QuickSortVetor(List<int> array, int startPoint, int endPoint)
		{
			if (startPoint < endPoint)
			{
				int point = array[startPoint];
				int start = startPoint + 1;
				int end = endPoint;

				while (start <= end)
				{
					if (array[start] <= point)
						start++;
					else if (point < array[end])
						end--;
					else
					{
						int troca = array[start];
						array[start] = array[end];
						array[end] = troca;
						start++;
						end--;
					}
				}

				array[startPoint] = array[end];
				array[end] = point;

				QuickSortVetor(array, startPoint, end - 1);
				QuickSortVetor(array, end + 1, endPoint);
			}
			return array;
		}


	}
}