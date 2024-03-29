using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomList;
using System;
namespace UnitTest
{ 
    [TestClass]
    public class UnitTest1
    {
        //Equals returns true with full array and count equality 
        [TestMethod]
        public void TestEquals_ExpectedOutputTrue()
        {
            CustomList<int> expected = new CustomList<int>(new int[] { 1, 2, 3, 4 });
            CustomList<int> test = new CustomList<int>(new int[] { 1, 2, 3, 4 });

            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.IsTrue( expected[i] == test[i]);
            }

            Assert.IsTrue( expected.Count() == test.Count());
        }

        public void TestEquals_ExpectedOutputFalse()
        {
            CustomList<int> expected = new CustomList<int>(new int[] { 1, 2, 3, 4 });
            CustomList<int> test = new CustomList<int>(new int[] { 1, 2, -1, 4 });

            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.IsTrue(expected[i] == test[i]);
            }

            Assert.IsTrue(expected.Count() == test.Count());
        }


        [TestMethod]
        public void TestCustomList_NegativeLengthThrowsErr()
        {
            try
            {
                new CustomList<int>(-5);
            } catch( Exception E )
            {
                Assert.IsTrue(true);
            }

        }   

        [TestMethod]
        public void TestRemove_ReturnTrue()
        {
            CustomList<int> test = new CustomList<int>(new int[] { 1, 2, 2, 3, 4 });
            CustomList<int> expected = new CustomList<int>(new int[]{ 1, 2, 3, 4 });

            test.Remove(1);
            Assert.IsTrue(expected.Equals(test));
        }

        [TestMethod]
        public void TestAdd_ExpectedOutputTrue()
        {
            CustomList<int> expected = new CustomList<int>(new int[] { 1, 2, 3, 4, 5 });
            CustomList<int> test = new CustomList<int>(new int[] { 1, 2, 3, 4} );
            test.Add(5);

            Assert.IsTrue(expected.Equals(test));
        }

        [TestMethod]
        public void TestAdd_AddByNull()
        {
            CustomList<int> expected = new CustomList<int>(new int[] { 1, 2, 3, 4 });
            CustomList<int> test = new CustomList<int>(new int[] { 1, 2, 3, 4 });
            test.Add(new CustomList<int>());

            Assert.IsTrue(expected.Equals(test));
        }


        [TestMethod]
        public void TestAdd_AddCustomList_ExpectedOutputTrue()
        {
            CustomList<int> expected = new CustomList<int>(new int[] { 1, 2, 3, 4, 5 });
            CustomList<int> test = new CustomList<int>(new int[] { 1, 2, 3, 4 });
            test.Add(new CustomList<int>(new int[] { 5 }));

            Assert.IsTrue(expected.Equals(test));
        }

        [TestMethod]
        public void TestPlusOp_ExpectedOutputTrue()
        {
            CustomList<int> expected = new CustomList<int>(new int[] { 1, 2, 3, 4, 5 });
            CustomList<int> test = new CustomList<int>(new int[] { 1, 2, 3 }) + new CustomList<int>(new int[] { 4, 5 });

            Assert.IsTrue(expected.Equals(test));
        }

        [TestMethod]
        public void TestPlusOp_AddByNull()
        {
            CustomList<int> test = new CustomList<int>(new int[] { 1, 2, 4, 5 }) + new CustomList<int>();
            CustomList<int> expected = new CustomList<int>(new int[] { 1, 2, 4, 5 });
            Assert.IsTrue(expected.Equals(test));
        }

        [TestMethod]
        public void TestSubtractOp_ExpectedOutputTrue()
        {
            CustomList<int> test = new CustomList<int>(new int[] { 1, 3, 2, 3, 4, 5 }) - new CustomList<int>(new int[] { 3 });
            CustomList<int> expected = new CustomList<int>(new int[] { 1, 2, 4, 5 });
            Assert.IsTrue(expected.Equals(test));
        }

        [TestMethod]
        public void TestSubtractOp_subtractingByNull()
        {
            CustomList<int> test = new CustomList<int>(new int[] { 1, 2, 4, 5 }) - new CustomList<int>();
            CustomList<int> expected = new CustomList<int>(new int[] { 1, 2, 4, 5 });
            Assert.IsTrue(expected.Equals(test));
        }

        [TestMethod]
        public void TestZip_ExpectedOutputTrue()
        {
            CustomList<int> expected = new CustomList<int>(new int[] { 1, 2, 3, 4, 5 });
            CustomList<int> test = CustomList<int>.Zip(new CustomList<int>(new int[] { 1, 3, 5 }), new CustomList<int>(new int[] { 2, 4 }));
            Assert.IsTrue(expected.Equals(test));
        }

        [TestMethod]
        public void TestZip_ZipppingByNull()
        {
            CustomList<int> expected = new CustomList<int>(new int[] { 1, 3, 5 });
            CustomList<int> test = CustomList<int>.Zip(new CustomList<int>(new int[] { 1, 3, 5 }), new CustomList<int>());
            Assert.IsTrue(expected.Equals(test));
        }

        [TestMethod]
        public void TestFilter_ExpectedOutputTrue()
        {
            CustomList<int> expected = new CustomList<int>(new int[] { 2, 2, 2 });
            CustomList<int> test = new CustomList<int>(new int[] { 1, 2, 3, 2, 2, 1 }).Filter
                ((x) => x == 2);

            Assert.IsTrue(expected.Equals(test));
        }

        [TestMethod]
        public void TestMap_ExpectedOutputTrue()
        {
            int expected = 15;
            int test = 0;
            new CustomList<int>(new int[] { 1, 2, 3, 4, 5 }).Map((x) => test += x);

            Assert.IsTrue(expected == test);
        }

        [TestMethod]
        public void TestFind_ExpectedOutput()
        {
            int expected = 1;
            int test = (new CustomList<int>(new int[] { 4, 5, 6, 7, 8, 9 })).Find(5);
            Assert.IsTrue(expected == test);
        }

        [TestMethod]
        public void TestSort_ExpectedOutput()
        {
            CustomList<int> expected = new CustomList<int>(new int[] { 4, 5, 6, 7, 8, 9});
            CustomList<int> a = new CustomList<int>(new int[] {7, 8, 9, 4, 5, 6});

            Assert.IsTrue(a.Sort(a).Equals(expected));
        }
    }
}
