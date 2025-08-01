using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrapItUpSample
{
    internal class SortAlgorithm
    {
        public void BubbleSort()
        {
            int[] numbers = { 9, 3, 7, 1, 5 };

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        // Swap
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));  // Output: 1, 3, 5, 7, 9

        }
        public void BinarySearch()
        {
            int[] sorted = { 1, 3, 5, 7, 9 };
            int target = 5;
            int left = 0, right = sorted.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (sorted[mid] == target)
                {
                    Console.WriteLine($"Found {target} at index {mid}");
                    break;
                }
                else if (sorted[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

        }
        public void LINQSort()
        {
            int[] nums = { 9, 3, 7, 1, 5 };
            var sortedNums = nums.OrderBy(n => n).ToList();

            int target = 5;
            var found = sortedNums.FirstOrDefault(n => n == target);

            Console.WriteLine($"Sorted: {string.Join(", ", sortedNums)}");
            Console.WriteLine($"Found: {found}");

        }
    }
}
