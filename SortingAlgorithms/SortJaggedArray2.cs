using System;
using System.Collections.Generic;

namespace SortingAlgorithms2
{
    public static class SortJaggedArray2
    {
        /// <summary>
        /// BubbleSort for jagged arrays.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Jagged array shouldn't be null. - array
        /// or
        /// Can't sort the array without comparer criteria. - Comparison
        /// </exception>
        /// <exception cref="ArgumentException">Jagged array shouldn't be empty. - array</exception>
        public static void BubbleSort(this int[][] array, IComparer<int[]> comparer)
        {
            BubbleSort(array, comparer.Compare);
        }

        /// <summary>
        /// BubbleSort for jagged arrays.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="Comparison">The comparison.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Jagged array shouldn't be null. - array
        /// or
        /// Can't sort the array without comparer criteria. - Comparison
        /// </exception>
        /// <exception cref="System.ArgumentException">Jagged array shouldn't be empty. - array</exception>
        public static void BubbleSort(this int[][] array, Func<int[], int[], int> comparison)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Jagged array shouldn't be null.", nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Jagged array shouldn't be empty.", nameof(array));
            }

            if (comparison == null)
            {
                throw new ArgumentNullException("Can't sort the array without comparer criteria.", nameof(comparison));
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
                        if (comparison(array[j], array[j + 1]) > 0)
                        {
                            Swap(ref array[j], ref array[j + 1]);
                            check = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Swaps two <typeparamref name="T"/> in the array
        /// </summary>
        /// <typeparam name="T">
        /// The type.
        /// </typeparam>
        /// <param name="el1">The first reference</param>
        /// <param name="el2">The second reference</param>
        private static void Swap<T>(ref T el1, ref T el2)
        {
            T temp = el1;
            el1 = el2;
            el2 = temp;
        }
    }
}
