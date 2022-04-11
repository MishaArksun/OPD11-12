using NUnit.Framework;
using OPD11;

namespace OPD11Tests
{
    public class Tests
    {
        [Test]
        public void TestBySumAsc()
        {
            int[][] actual = { 
                new[] { 2, 3, 4 },
                new[] { 0, 0, 5, 0, 0 },
                new[] { 1, 1000 } };

            int[][] expected = {
                new[] { 0, 0, 5, 0, 0 },                                 
                new[] { 2, 3, 4 },                                 
                new[] { 1, 1000 } };

            new Bubble(actual, PropertyOption.getSum).sort(true);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBySumDesc()
        {
            int[][] actual = {
                new[] { 2, 3, 4 },
                new[] { 0, 0, 5, 0, 0 },
                new[] { 1, 1000 } };

            int[][] expected = {
                new[] { 1, 1000 },
                new[] { 2, 3, 4 },
                new[] { 0, 0, 5, 0, 0 } };

            new Bubble(actual, PropertyOption.getSum).sort(false);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestByMaxAsc()
        {
            int[][] actual = {
                new[] { 2, 3, 4 },
                new[] { 0, 0, 5, 0, 0 },
                new[] { 1, 1000 } };

            int[][] expected = {                
                new[] { 2, 3, 4 },
                new[] { 0, 0, 5, 0, 0 },
                new[] { 1, 1000 } };

            new Bubble(actual, PropertyOption.getMax).sort(true);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestByMaxDesc()
        {
            int[][] actual = {
                new[] { 2, 3, 4 },
                new[] { 0, 0, 5, 0, 0 },
                new[] { 1, 1000 } };

            int[][] expected = {
                new[] { 1, 1000 },
                new[] { 0, 0, 5, 0, 0 },
                new[] { 2, 3, 4 } };

            new Bubble(actual, PropertyOption.getMax).sort(false);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestByMinAsc()
        {
            int[][] actual = {
                new[] { 2, 3, 4 },
                new[] { 0, 0, 5, 0, 0 },
                new[] { 1, 1000 } };

            int[][] expected = {
                new[] { 0, 0, 5, 0, 0 },
                new[] { 1, 1000 },
                new[] { 2, 3, 4 } };

            new Bubble(actual, PropertyOption.getMin).sort(true);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestByMinDesc()
        {
            int[][] actual = {
                new[] { 2, 3, 4 },
                new[] { 0, 0, 5, 0, 0 },
                new[] { 1, 1000 } };

            int[][] expected = {
                new[] { 2, 3, 4 },
                new[] { 1, 1000 },
                new[] { 0, 0, 5, 0, 0 } };

            new Bubble(actual, PropertyOption.getMin).sort(false);

            Assert.AreEqual(expected, actual);
        }
    }
}