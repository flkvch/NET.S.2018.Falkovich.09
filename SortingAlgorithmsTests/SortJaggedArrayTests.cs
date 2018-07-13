using NUnit.Framework;
using System;

namespace SortingAlgorithms.Tests
{
    [TestFixture()]
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
        public void BubbleSortTest_SumAsc1() => CollectionAssert.AreEqual(array[0].BubbleSort(true, "Sum"), resultSumAsc[0]);

        [Test]
        public void BubbleSortTest_SumAsc2() => CollectionAssert.AreEqual(array[1].BubbleSort(true, "Sum"), resultSumAsc[1]);

        [Test]
        public void BubbleSortTest_SumDesc1() => CollectionAssert.AreEqual(array[0].BubbleSort(false, "Sum"), resultSumDesc[0]);

        [Test]
        public void BubbleSortTest_SumDesc2() => CollectionAssert.AreEqual(array[1].BubbleSort(false, "Sum"), resultSumDesc[1]);

        [Test]
        public void BubbleSortTest_MaxAsc1() => CollectionAssert.AreEqual(array[0].BubbleSort(true, "Max Element"), resultMaxAsc[0]);

        [Test]
        public void BubbleSortTest_MaxAsc2() => CollectionAssert.AreEqual(array[1].BubbleSort(true, "Max Element"), resultMaxAsc[1]);

        [Test]
        public void BubbleSortTest_MaxDesc1() => CollectionAssert.AreEqual(array[0].BubbleSort(false, "Max Element"), resultMaxDesc[0]);

        [Test]
        public void BubbleSortTest_MaxDesc2() => CollectionAssert.AreEqual(array[1].BubbleSort(false, "Max Element"), resultMaxDesc[1]);

        [Test]
        public void BubbleSortTest_MinAsc1() => CollectionAssert.AreEqual(array[0].BubbleSort(true, "Min Element"), resultMinAsc[0]);

        [Test]
        public void BubbleSortTest_MinAsc2() => CollectionAssert.AreEqual(array[1].BubbleSort(true, "Min Element"), resultMinAsc[1]);

        [Test]
        public void BubbleSortTest_MinDesc1() => CollectionAssert.AreEqual(array[0].BubbleSort(false, "Min Element"), resultMinDesc[0]);

        [Test]
        public void BubbleSortTest_MinDesc2() => CollectionAssert.AreEqual(array[1].BubbleSort(false, "Min Element"), resultMinDesc[1]);

        [Test]
        public void BubbleSortTest_InValidMetod()
            => Assert.Throws<ArgumentException>(() => array[0].BubbleSort(true, "Mult"));

        [Test]
        public void BubbleSortTest_nullarray()
            => Assert.Throws<ArgumentNullException>(() => nullArray.BubbleSort(true, "Sum"));

        [Test]
        public void BubbleSortTest_emptyarray()
        => Assert.Throws<ArgumentException>(() => emptyArray.BubbleSort(true, "Mult"));
    }
}