using NUnit.Framework;
using System;
using System.Linq;

namespace SortingAlgorithms.Tests
{
    public class ByMax : SortJaggedArray.IComparer
    {
        bool isAscending;

        public ByMax(bool isAscending)
        {
            this.isAscending = isAscending;
        }

        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null && rhs == null)
            {
                return 0;
            }

            if (lhs.Length == 0 && rhs.Length == 0)
            {
                return 0;
            }

            if (lhs == null || lhs.Length == 0)
            {
                if (isAscending == true)
                {
                    return -1;
                }

                return 1;
            }

            if (rhs == null || rhs.Length == 0)
            {
                if (isAscending == true)
                {
                    return 1;
                }

                return -1;
            }

            if (isAscending == true)
            {
                return lhs.Max() - rhs.Max();
            }

            return rhs.Max() - lhs.Max();
        }
    }

    public class ByMin : SortJaggedArray.IComparer
    {
        bool isAscending;

        public ByMin(bool isAscending)
        {
            this.isAscending = isAscending;
        }

        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null && rhs == null)
            {
                return 0;
            }

            if (lhs.Length == 0 && rhs.Length == 0)
            {
                return 0;
            }

            if (lhs == null || lhs.Length == 0)
            {
                if (isAscending == true)
                {
                    return -1;
                }

                return 1;
            }

            if (rhs == null || rhs.Length == 0)
            {
                if (isAscending == true)
                {
                    return 1;
                }

                return -1;
            }

            if (isAscending == true)
            {
                return lhs.Min() - rhs.Min();
            }

            return rhs.Min() - lhs.Min();
        }
    }

    public class BySum : SortJaggedArray.IComparer
    {
        bool isAscending;

        public BySum(bool isAscending)
        {
            this.isAscending = isAscending;
        }

        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null && rhs == null)
            {
                return 0;
            }

            if (lhs == null)
            {
                if (isAscending == true)
                {
                    return -1;
                }

                return 1;
            }

            if (rhs == null)
            {
                if (isAscending == true)
                {
                    return 1;
                }

                return -1;
            }

            if (isAscending == true)
            {
                return lhs.Sum() - rhs.Sum();
            }

            return rhs.Sum() - lhs.Sum();
        }
    }

    [TestFixture]
    public class SortJaggedArrayTests 
    {
        private readonly int[][][] array =
            {
                new int[][]{
                    new int[]{ 1, 2, 8, 9 },
                    new int[]{ 2, 21, 0 },
                    new int[]{ 5 },
                    new int[]{ 20, 10 }},
                new int[][]{
                    new int[]{ -5, 1, 892, 78, 9, 0 }, //975
                    new int[]{ 2, 21, 0, 89, -89, 78 }, //101
                    new int[]{ 5, 9, -8, 38, 24, -17 },//51
                    new int[]{ 61, 35, 94, 81, 33, 17, 20, 10 },//351
                    new int[]{ 22, 6, 48, -1, 8},//83
                    new int[]{ 0 }
            }
        };

        private readonly int[][][] resultSumAsc =
        {
             new int[][]{
                 new int[]{ 5 },
                new int[]{ 1, 2, 8, 9 },
                new int[]{ 2, 21, 0 },
                new int[]{ 20, 10 }},
             new int[][]{
                    new int[]{ 0 },
                    new int[]{ 5, 9, -8, 38, 24, -17 },//51
                    new int[]{ 22, 6, 48, -1, 8},//83
                    new int[]{ 2, 21, 0, 89, -89, 78 }, //101
                    new int[]{ 61, 35, 94, 81, 33, 17, 20, 10 },//351
                    new int[]{ -5, 1, 892, 78, 9, 0 } //975
             }
        };

        private readonly int[][][] resultSumDesc =
        {
            new int[][]{
                new int[]{ 20, 10 },
                new int[]{ 2, 21, 0 },
                new int[]{ 1, 2, 8, 9 },
                new int[]{ 5 }},
            new int[][]{
                    new int[]{ -5, 1, 892, 78, 9, 0 }, //975
                    new int[]{ 61, 35, 94, 81, 33, 17, 20, 10 },//351
                    new int[]{ 2, 21, 0, 89, -89, 78 }, //101
                    new int[]{ 22, 6, 48, -1, 8},//83
                    new int[]{ 5, 9, -8, 38, 24, -17 },//51
                    new int[]{ 0 }
            }
            };

        private readonly int[][][] resultMaxAsc =
        {
             new int[][]{
                new int[]{ 5 },
                new int[]{ 1, 2, 8, 9 },
                new int[]{ 20, 10 },
                new int[]{ 2, 21, 0 } },
              new int[][]{
                    new int[]{ 0 },
                    new int[]{ 5, 9, -8, 38, 24, -17 },
                    new int[]{ 22, 6, 48, -1, 8},
                    new int[]{ 2, 21, 0, 89, -89, 78 },
                    new int[]{ 61, 35, 94, 81, 33, 17, 20, 10 },
                    new int[]{ -5, 1, 892, 78, 9, 0 }
              }
            };

        private readonly int[][][] resultMaxDesc =
        {
              new int[][]{
                new int[]{ 2, 21, 0 },
                new int[]{ 20, 10 },
                new int[]{ 1, 2, 8, 9 },
                new int[]{ 5 } },
              new int[][]{
                    new int[]{ -5, 1, 892, 78, 9, 0 },
                    new int[]{ 61, 35, 94, 81, 33, 17, 20, 10 },
                    new int[]{ 2, 21, 0, 89, -89, 78 },
                    new int[]{ 22, 6, 48, -1, 8},
                    new int[]{ 5, 9, -8, 38, 24, -17 },
                    new int[]{ 0 }
              }
            };

        private readonly int[][][] resultMinAsc =
        {
              new int[][]{
                 new int[]{ 2, 21, 0 },
                 new int[]{ 1, 2, 8, 9 },
                 new int[]{ 5 },
                 new int[]{ 20, 10 } },
              new int[][]{
                    new int[]{ 2, 21, 0, 89, -89, 78 },
                    new int[]{ 5, 9, -8, 38, 24, -17 },
                    new int[]{ -5, 1, 892, 78, 9, 0 },
                    new int[]{ 22, 6, 48, -1, 8},
                    new int[]{ 0 },                    
                    new int[]{ 61, 35, 94, 81, 33, 17, 20, 10 }
              }
            };

        private readonly int[][][] resultMinDesc =
        {
              new int[][]{
                new int[]{ 20, 10 },
                new int[]{ 5 },
                new int[]{ 1, 2, 8, 9 },
                new int[]{ 2, 21, 0 } },
              new int[][]{
                  new int[]{ 61, 35, 94, 81, 33, 17, 20, 10 },
                  new int[]{ 0 },
                  new int[]{ 22, 6, 48, -1, 8},
                  new int[]{ -5, 1, 892, 78, 9, 0 },
                  new int[]{ 5, 9, -8, 38, 24, -17 },
                  new int[]{ 2, 21, 0, 89, -89, 78 },
              } 
            };

        private int[][] nullArray = null;
        private int[][] emptyArray = { };

        [Test]
        public void BubbleSortTest_SumAsc1() => CollectionAssert.AreEqual(array[0].BubbleSort(new BySum(true)), resultSumAsc[0]);

        [Test]
        public void BubbleSortTest_SumAsc2() => CollectionAssert.AreEqual(array[1].BubbleSort(new BySum(true)), resultSumAsc[1]);

        [Test]
        public void BubbleSortTest_SumDesc1() => CollectionAssert.AreEqual(array[0].BubbleSort(new BySum(false)), resultSumDesc[0]);

        [Test]
        public void BubbleSortTest_SumDesc2() => CollectionAssert.AreEqual(array[1].BubbleSort(new BySum(false)), resultSumDesc[1]);

        [Test]
        public void BubbleSortTest_MaxAsc1() => CollectionAssert.AreEqual(array[0].BubbleSort(new ByMax(true)), resultMaxAsc[0]);

        [Test]
        public void BubbleSortTest_MaxAsc2() => CollectionAssert.AreEqual(array[1].BubbleSort(new ByMax(true)), resultMaxAsc[1]);

        [Test]
        public void BubbleSortTest_MaxDesc1() => CollectionAssert.AreEqual(array[0].BubbleSort(new ByMax(false)), resultMaxDesc[0]);

        [Test]
        public void BubbleSortTest_MaxDesc2() => CollectionAssert.AreEqual(array[1].BubbleSort(new ByMax(false)), resultMaxDesc[1]);

        [Test]
        public void BubbleSortTest_MinAsc1() => CollectionAssert.AreEqual(array[0].BubbleSort(new ByMin(true)), resultMinAsc[0]);

        [Test]
        public void BubbleSortTest_MinAsc2() => CollectionAssert.AreEqual(array[1].BubbleSort(new ByMin(true)), resultMinAsc[1]);

        [Test]
        public void BubbleSortTest_MinDesc1() => CollectionAssert.AreEqual(array[0].BubbleSort(new ByMin(false)), resultMinDesc[0]);

        [Test]
        public void BubbleSortTest_MinDesc2() => CollectionAssert.AreEqual(array[1].BubbleSort(new ByMin(false)), resultMinDesc[1]);

        [Test]
        public void BubbleSortTest_nullarray()
            => Assert.Throws<ArgumentNullException>(() => nullArray.BubbleSort(new ByMax(true)));

        [Test]
        public void BubbleSortTest_emptyarray()
        => Assert.Throws<ArgumentException>(() => emptyArray.BubbleSort(new ByMax(true)));
    }
}