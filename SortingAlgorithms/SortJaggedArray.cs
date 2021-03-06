﻿using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    /// <summary>
    /// Class for sorting jagged arrays
    /// </summary>
    public static class SortJaggedArray
    {
       /// <summary>
        /// BubbleSort for jagged arrays.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="Comparison">The comparison.</param>
        public static void BubbleSort(this int[][] array, Func<int[], int[], int> comparison)
        {
            IComparer<int[]> icomparer = new ComparisonAdapter(comparison);
            BubbleSort(array, icomparer);
        }

        /// <summary>
        /// BubbleSort for jagged arrays.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Jagged array shouldn't be null. - array</exception>
        /// <exception cref="ArgumentException">Jagged array shouldn't be empty. - array</exception>
        public static void BubbleSort(this int[][] array, IComparer<int[]> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Jagged array shouldn't be null.", nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Jagged array shouldn't be empty.", nameof(array));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("Can't sort the array without comparer criteria.", nameof(comparer));
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

        private class ComparisonAdapter : IComparer<int[]>
        {
            private readonly Func<int[], int[], int> _comparison;

            public ComparisonAdapter(Func<int[], int[], int> comparison)
            {
                _comparison = comparison;
            }

            public int Compare(int[] lhs, int[] rhs)
            {
                return _comparison(lhs, rhs);
            }
        }
    }
}