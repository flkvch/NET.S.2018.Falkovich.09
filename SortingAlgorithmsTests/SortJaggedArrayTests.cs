using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Tests
{
    public class ByMax : IComparer <int[]>
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

            if (lhs == null)
            {
                if (isAscending)
                {
                    return -1;
                }

                return 1;
            }

            if (rhs == null)
            {
                if (isAscending)
                {
                    return 1;
                }

                return -1;
            }

            try
            {
                int result = checked(lhs.Max() - rhs.Max());
                if (isAscending)
                {
                    return result;
                }

                return -result;
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Can't compare maxs of arrays. ");
            }
        }
    }

    public class ByMin : IComparer<int[]>
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

            if (lhs == null)
            {
                if (isAscending)
                {
                    return -1;
                }

                return 1;
            }

            if (rhs == null)
            {
                if (isAscending)
                {
                    return 1;
                }

                return -1;
            }

            int result = 0;
            try
            {
                checked
                {
                    result = lhs.Min() - rhs.Min();
                }
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Can't compare mins of arrays. ");
            }

            if (isAscending)
            {
                return result;
            }

            return -result;
        }
    }

    public class BySum : IComparer<int[]>
    {
        private bool isAscending;

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
                if (isAscending)
                {
                    return -1;
                }

                return 1;
            }

            if (rhs == null)
            {
                if (isAscending)
                {
                    return 1;
                }

                return -1;
            }

            int result = 0;
            try
            {
                checked
                {
                    result = lhs.Sum() - rhs.Sum();
                }
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Can't compare sums of arrays. ");
            }

            if (isAscending)
            {
                return result;
            }

            return -result;
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
                    null,
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
                    null,
                    new int[]{ 0 },
                    new int[]{ 5, 9, -8, 38, 24, -17 },//51
                    new int[]{ 22, 6, 48, -1, 8},//83
                    new int[]{ 2, 21, 0, 89, -89, 78 }, //101
                    new int[]{ 61, 35, 94, 81, 33, 17, 20, 10 },//351
                    new int[]{ -5, 1, 892, 78, 9, 0 }, //975
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
                    new int[]{ 0 },
                    null
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
                    null,
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
                    new int[]{ 0 },
                    null
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
                    null,
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
                  null
              } 
            };

        private int[][] nullArray = null;
        private int[][] emptyArray = { };

        [Test]
        public void BubbleSortTest_SumAsc1()
        {
            array[0].BubbleSort(new BySum(true));
            CollectionAssert.AreEqual(array[0], resultSumAsc[0]);
        }

        [Test]
        public void BubbleSortTest_SumAsc11()
        {
            array[0].BubbleSort(new BySum(true).Compare);
            CollectionAssert.AreEqual(array[0], resultSumAsc[0]);
        }

        [Test]
        public void BubbleSortTest_SumAsc2()
        {
            array[1].BubbleSort(new BySum(true));
            CollectionAssert.AreEqual(array[1], resultSumAsc[1]);
        }

        [Test]
        public void BubbleSortTest_SumAsc22()
        {
            array[1].BubbleSort(new BySum(true).Compare);
            CollectionAssert.AreEqual(array[1], resultSumAsc[1]);
        }

        [Test]
        public void BubbleSortTest_SumDesc1()
        {
            array[0].BubbleSort(new BySum(false));
            CollectionAssert.AreEqual(array[0], resultSumDesc[0]);
        }

        [Test]
        public void BubbleSortTest_SumDesc11()
        {
            array[0].BubbleSort(new BySum(false).Compare);
            CollectionAssert.AreEqual(array[0], resultSumDesc[0]);
        }

        [Test]
        public void BubbleSortTest_SumDesc2()
        {
            array[1].BubbleSort(new BySum(false));
            CollectionAssert.AreEqual(array[1], resultSumDesc[1]);
        }

        [Test]
        public void BubbleSortTest_SumDesc22()
        {
            array[1].BubbleSort(new BySum(false).Compare);
            CollectionAssert.AreEqual(array[1], resultSumDesc[1]);
        }

        [Test]
        public void BubbleSortTest_MaxAsc1()
        {
            array[0].BubbleSort(new ByMax(true));
            CollectionAssert.AreEqual(array[0], resultMaxAsc[0]);
        }

        [Test]
        public void BubbleSortTest_MaxAsc11()
        {
            array[0].BubbleSort(new ByMax(true).Compare);
            CollectionAssert.AreEqual(array[0], resultMaxAsc[0]);
        }

        [Test]
        public void BubbleSortTest_MaxAsc2()
        {
            array[1].BubbleSort(new ByMax(true));
            CollectionAssert.AreEqual(array[1], resultMaxAsc[1]);
        }

        [Test]
        public void BubbleSortTest_MaxAsc22()
        {
            array[1].BubbleSort(new ByMax(true).Compare);
            CollectionAssert.AreEqual(array[1], resultMaxAsc[1]);
        }

        [Test]
        public void BubbleSortTest_MaxDesc1()
        {
            array[0].BubbleSort(new ByMax(false));
            CollectionAssert.AreEqual(array[0], resultMaxDesc[0]);
        }

        public void BubbleSortTest_MaxDesc11()
        {
            array[0].BubbleSort(new ByMax(false).Compare);
            CollectionAssert.AreEqual(array[0], resultMaxDesc[0]);
        }

        [Test]
        public void BubbleSortTest_MaxDesc2()
        {
            array[1].BubbleSort(new ByMax(false));
            CollectionAssert.AreEqual(array[1], resultMaxDesc[1]);
        }

        [Test]
        public void BubbleSortTest_MaxDesc22()
        {
            array[1].BubbleSort(new ByMax(false).Compare);
            CollectionAssert.AreEqual(array[1], resultMaxDesc[1]);
        }

        [Test]
        public void BubbleSortTest_MinAsc1()
        {
            array[0].BubbleSort(new ByMin(true));
            CollectionAssert.AreEqual(array[0], resultMinAsc[0]);
        }

        [Test]
        public void BubbleSortTest_MinAsc11()
        {
            array[0].BubbleSort(new ByMin(true).Compare);
            CollectionAssert.AreEqual(array[0], resultMinAsc[0]);
        }

        [Test]
        public void BubbleSortTest_MinAsc2()
        {
            array[1].BubbleSort(new ByMin(true));
            CollectionAssert.AreEqual(array[1], resultMinAsc[1]);
        }

        [Test]
        public void BubbleSortTest_MinAsc22()
        {
            array[1].BubbleSort(new ByMin(true).Compare);
            CollectionAssert.AreEqual(array[1], resultMinAsc[1]);
        }

        [Test]
        public void BubbleSortTest_MinDesc1()
        {
            array[0].BubbleSort(new ByMin(false));
            CollectionAssert.AreEqual(array[0], resultMinDesc[0]);
        }

        [Test]
        public void BubbleSortTest_MinDesc11()
        {
            array[0].BubbleSort(new ByMin(false).Compare);
            CollectionAssert.AreEqual(array[0], resultMinDesc[0]);
        }

        [Test]
        public void BubbleSortTest_MinDesc2()
        {
            array[1].BubbleSort(new ByMin(false));
            CollectionAssert.AreEqual(array[1], resultMinDesc[1]);
        }

        [Test]
        public void BubbleSortTest_MinDesc22()
        {
            array[1].BubbleSort(new ByMin(false).Compare);
            CollectionAssert.AreEqual(array[1], resultMinDesc[1]);
        }

        [Test]
        public void BubbleSortTest_nullarray()
            => Assert.Throws<ArgumentNullException>(() => nullArray.BubbleSort(new ByMax(true)));

        [Test]
        public void BubbleSortTest_emptyarray()
        => Assert.Throws<ArgumentException>(() => emptyArray.BubbleSort(new ByMax(true)));
    }
}