using System;
using System.Collections;

namespace SortingAlgorithms
{
    /// <summary>
    /// Class for sorting jagged arrays
    /// </summary>
    public static class SortJaggedArray
    {
        public interface IComparer
        {
            int Compare(int[] lhs, int[] rhs);
        }

        /// <summary>
        /// BubbleSort for jagged arrays.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="ascendingOrder">if set to <c>true</c> [ascending order].</param>
        /// <param name="sortingBy">The method of sorting.</param>
        /// <returns>
        /// Sorted array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Jagged array shouldn't be null. - array
        /// or
        /// Elements of jagged array shouldn't be null. - array
        /// or
        /// Elements of jagged array shouldn't be empty. - array
        /// </exception>
        /// <exception cref="ArgumentException">There is no such sorting of jagged array - sortingBy</exception>
        public static int[][] BubbleSort(this int[][] array, IComparer comparer)
        {
            array.BubbleSorting(comparer);
            return array;
        }

        /// <summary>
        /// BubbleSort for jagged arrays
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="ascendingOrder">if set to <c>true</c> [ascending order].</param>
        /// <param name="sortingBy">The method of sorting.</param>
        /// <exception cref="ArgumentNullException">
        /// Jagged array shouldn't be null. - array
        /// or
        /// Elements of jagged array shouldn't be null. - array
        /// or
        /// Elements of jagged array shouldn't be empty. - array
        /// </exception>
        /// <exception cref="ArgumentException">There is no such sorting of jagged array - sortingBy</exception>
        private static void BubbleSorting(this int[][] array, IComparer comparer)
        {
            if (array == null) 
            {
                throw new ArgumentNullException("Jagged array shouldn't be null.", nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Jagged array shouldn't be empty.", nameof(array));
            }

            if (array.Length == 1)
            {
                return;
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                bool check = true;
                while (check)
                {
                    check = false;
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (comparer.Compare(array[j], array[j + 1]) > 0)
                        {
                            Swap(ref array[j], ref array[j + 1]);
                            check = true;
                        }
                    }
                }
            }
        }

        private static void Reverse(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length / 2; i++)
            {
                Swap(ref jaggedArray[i], ref jaggedArray[jaggedArray.Length - 1 - i]);
            }
        }

        /// <summary>
        /// Swaps two referenses of the arays in jagged array
        /// </summary>
        /// <param name="el1">
        /// The first reference
        /// </param>
        /// <param name="el2">
        /// The second reference 
        /// </param>
        private static void Swap<T>(ref T el1, ref T el2)
        {
            T temp = el1;
            el1 = el2;
            el2 = temp;
        }
    }
}