using System.Collections.Generic;
using System.Linq;

namespace Sort_Form
{
    static class Sorter
    {
		public static int compare_times = 0, swap_times = 0;


		public static void sort_Selection(int[] arr)
        {
			int n = arr.Length;

			// One by one move boundary of unsorted subarray 
			for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                {

					compare_times++;
					if (arr[j] < arr[min_idx])
                        min_idx = j;
                }
				// Swap the found minimum element with the first element 

				swap_times++;
				int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
		}


		public static void sort_Insertion(int[] arr)
        {

			int n = arr.Length;
			for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1], that are greater than key, to one position ahead of their current one
                while (j >= 0 && arr[j] > key)
                {

					compare_times++;
					swap_times++;
					arr[j + 1] = arr[j];
                    j = j - 1;
                }
				compare_times++;

				arr[j + 1] = key;
			}

		}


		public static void sort_Swap(int[] arr)
		{

			int n = arr.Length;
			for (int i = 0; i < n - 1; i++)
				for (int j = 0; j < n - i - 1; j++)
				{
					compare_times++;
					if (arr[j] > arr[j + 1])
					{


						// swap temp and arr[i] 
						//
						swap_times++;

						int temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
					}
				}

		}


		public static void Quick_Sort(int[] arr, int left, int right)
        {

			//
			compare_times++;
			if (left < right)
            {
                int pivot = Partition(arr, left, right);
				//
				compare_times++;
				if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
				//
				compare_times++;
				if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

		}

		private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
				compare_times++;
				while (arr[left] < pivot)
                {
                    left++;
					compare_times++;
				}

				compare_times++;
				while (arr[right] > pivot)
                {
                    right--;
					compare_times++;
				}

				compare_times++;
				if (left < right)
                {
					compare_times++;
					if (arr[left] == arr[right])
						return right;

					swap_times++;
					int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }


		public static string[] CustomPrep(int[] arr)
		{
			string[] ret_val = new string[arr.Length];
			int max_length = arr.Max().ToString().Length; // get max value length for the next step
			for (int i = 0; i < arr.Length; i++)
			{
				ret_val[i] = arr[i].ToString($"D{max_length}");
			}
			return ret_val;
		}

		public static int[] Custom_Sort(string[] arr)
		{
			// first we divide every 'number' in 10 groups by their first number
			List<List<string>> addresses = new List<List<string>>(10);
			for (int i = 0; i < addresses.Capacity; i++)
			{
				addresses.Add(new List<string>());
			}

			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i][0] == '0')
				{
					addresses[0].Add(arr[i]);
					compare_times++;
				}
				else if (arr[i][0] == '1')
				{
					addresses[1].Add(arr[i]);
					compare_times+=2;
				}
				else if (arr[i][0] == '2')
				{
					addresses[2].Add(arr[i]);
					compare_times+=3;
				}
				else if (arr[i][0] == '3')
				{
					addresses[3].Add(arr[i]);
					compare_times+=4;
				}
				else if (arr[i][0] == '4')
				{
					addresses[4].Add(arr[i]);
					compare_times+=5;
				}
				else if (arr[i][0] == '5')
				{
					compare_times+=6;
					addresses[5].Add(arr[i]);
				}
				else if (arr[i][0] == '6')
				{
					compare_times+=7;
					addresses[6].Add(arr[i]);
				}
				else if (arr[i][0] == '7')
				{
					compare_times+=8;
					addresses[7].Add(arr[i]);
				}
				else if (arr[i][0] == '8')
				{
					compare_times+=9;
					addresses[8].Add(arr[i]);
				}
				if (arr[i][0] == '9')
				{
					compare_times+=10;
					addresses[9].Add(arr[i]);
				}
			} // sorting by first number to 10 groups
			 

			int prev_length = 0;
			int[] ret_val = new int[arr.Length];
			// concatenate arrays after individually sorting them
			foreach (var item in addresses)
			{
				Insertion_Strings(item.ToArray()).CopyTo(ret_val, prev_length);
				prev_length += item.ToArray().Length;
			}
			return ret_val;
		}

		// this one is prob the wors for this, hence the output statistics
		// could be worse though. it was worse before
		private static int[] Insertion_Strings(string[] arr)
		{
			int[] vals = new int[arr.Length];
			int k = 0;
			foreach (var item in arr)
			{
				vals[k] = int.Parse(item);
				k++;
			}
			int n = vals.Length;
			for (int i = 1; i < n; ++i)
			{
				int key = vals[i];
				int j = i - 1;

				// Move elements of arr[0..i-1], that are greater than key, to one position ahead of their current one
				while (j >= 0 && vals[j] > key)
				{

					compare_times++;
					swap_times++;
					vals[j + 1] = vals[j];
					j = j - 1;
				}
				compare_times++;

				vals[j + 1] = key;
			}
			return vals;
		}

	}
}
