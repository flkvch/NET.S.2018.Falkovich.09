using System;

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
        public static int[][] BubbleSort(this int[][] array, bool ascendingOrder, string sortingBy)
        {
            array.BubbleSort2(ascendingOrder, sortingBy);
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
        public static void BubbleSort2(this int[][] array, bool ascendingOrder, string sortingBy)
        {
            if (array == null) 
            {
                throw new ArgumentNullException("Jagged array shouldn't be null.", nameof(array));
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    throw new ArgumentNullException("Elements of jagged array shouldn't be null.", nameof(array));
                }

                if (array[i].Length == 0)
                {
                    throw new ArgumentNullException("Elements of jagged array shouldn't be empty.", nameof(array));
                }
            }

            if (array.Length == 1)
            {
                return;
            }

            switch (sortingBy)
            {
                case "Sum":
                    {
                        SortBySum(array, ascendingOrder);
                        break;
                    }

                case "Max Element":
                    {
                        SortByMaxEl(array, ascendingOrder);
                        break;
                    }

                case "Min Element":
                    {
                        SortByMinEl(array, ascendingOrder);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException("There is no such sorting of jagged array", nameof(sortingBy));
                    }                   
            }
        }

        private static void SortByMinEl(int[][] jaggedArray, bool ascendingOrder)
        {
            int[] minsArray = new int[jaggedArray.Length];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                minsArray[i] = jaggedArray[i][0];
                for (int j = 1; j < jaggedArray[i].Length; j++)
                {
                    if (jaggedArray[i][j] < minsArray[i])
                    {
                        minsArray[i] = jaggedArray[i][j];
                    }
                }
            }

            BubbleSort(minsArray, jaggedArray, ascendingOrder);
        }

        private static void SortByMaxEl(int[][] jaggedArray, bool ascendingOrder)
        {
            int[] maxsArray = new int[jaggedArray.Length];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                maxsArray[i] = jaggedArray[i][0];
                for (int j = 1; j < jaggedArray[i].Length; j++)
                {
                    if (jaggedArray[i][j] > maxsArray[i]) 
                    {
                        maxsArray[i] = jaggedArray[i][j];
                    }
                }
            }

            BubbleSort(maxsArray, jaggedArray, ascendingOrder);
        }

        private static void SortBySum(int[][] array, bool ascendingOrder)
        {
            int[] sumsArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sumsArray[i] += array[i][j];
                }
            }

            BubbleSort(sumsArray, array, ascendingOrder);
        }

        private static void BubbleSort(int[] array, int[][] jaggedArray, bool ascendingOrder)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            if (!ascendingOrder) 
            {
                Reverse(jaggedArray);
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