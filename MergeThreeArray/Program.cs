using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeThreeArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = GenerateRandomArray(10, 1, 100);
            int[] array2 = GenerateRandomArray(10, 1, 100);
            int[] array3 = GenerateRandomArray(10, 1, 100);

            Console.WriteLine("Array 1: " + string.Join(", ", array1));
            Console.WriteLine("Array 2: " + string.Join(", ", array2));
            Console.WriteLine("Array 3: " + string.Join(", ", array3));

            int[] mergedArray = MergeAndSortArrays(array1, array2, array3);

            Console.WriteLine("Merged and Sorted Array:");
            Console.WriteLine(string.Join(" ", mergedArray));
        }
        static int[] GenerateRandomArray(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }
            return array;
        }

        static int[] MergeAndSortArrays(int[] arr1, int[] arr2, int[] arr3)
        {
            int totalSize = arr1.Length + arr2.Length + arr3.Length;
            int[] mergedArray = new int[totalSize];

            int i = 0, j = 0, k = 0, m = 0;

            // Merge arrays by placing elements in sorted order directly
            while (i < arr1.Length && j < arr2.Length && k < arr3.Length)
            {
                if (arr1[i] <= arr2[j] && arr1[i] <= arr3[k])
                {
                    mergedArray[m++] = arr1[i++];
                }
                else if (arr2[j] <= arr1[i] && arr2[j] <= arr3[k])
                {
                    mergedArray[m++] = arr2[j++];
                }
                else
                {
                    mergedArray[m++] = arr3[k++];
                }
            }

            // Merge remaining elements from arr1 and arr2
            while (i < arr1.Length && j < arr2.Length)
            {
                mergedArray[m++] = arr1[i] <= arr2[j] ? arr1[i++] : arr2[j++];
            }

            // Merge remaining elements from arr2 and arr3
            while (j < arr2.Length && k < arr3.Length)
            {
                mergedArray[m++] = arr2[j] <= arr3[k] ? arr2[j++] : arr3[k++];
            }

            // Merge remaining elements from arr1 and arr3
            while (i < arr1.Length && k < arr3.Length)
            {
                mergedArray[m++] = arr1[i] <= arr3[k] ? arr1[i++] : arr3[k++];
            }

            // Append remaining elements
            while (i < arr1.Length)
            {
                mergedArray[m++] = arr1[i++];
            }

            while (j < arr2.Length)
            {
                mergedArray[m++] = arr2[j++];
            }

            while (k < arr3.Length)
            {
                mergedArray[m++] = arr3[k++];
            }

            return mergedArray;
        }
    }
}
