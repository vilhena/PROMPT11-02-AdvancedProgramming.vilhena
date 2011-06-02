namespace Mod02_AdvProgramming.Assignments.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class Ex3Tests {

        #region Private utility methods

        private int CheckFibonacciValues(IEnumerator<int> fsEnum, int max) {
            int prev = 1, beforePrev = 0, newValue;

            int i;
            for (i = 0; i < max && fsEnum.MoveNext(); i++) {
                newValue = beforePrev + prev;
                Assert.AreEqual(beforePrev, fsEnum.Current);

                beforePrev = prev;
                prev = newValue;
            }

            return i;
        }
        #endregion


        #region Test methods

        [Test]
        public void FibonacciSequenceWithoutLimitShouldReturnInfiniteAndCorrectValues()
        {
            // Arrange
            Ex3.FibonacciSequence fs = new Ex3.FibonacciSequence();

            // Act
            IEnumerator<int> fsEnum = fs.GetEnumerator();

            // Assert
            // Infinite is a lot. Lets check the first 100. Should be enough.
            const int LIMIT = 100;
            Assert.AreEqual(LIMIT, CheckFibonacciValues(fsEnum, LIMIT));
        }

        [Test]
        public void FibonacciSequenceWithLimitShouldReturnFiniteAndCorrectValues()
        {
            const int LIMIT = 20;
            // Arrange
            Ex3.FibonacciSequence fs = new Ex3.FibonacciSequence(LIMIT);

            // Act
            IEnumerator<int> fsEnum = fs.GetEnumerator();

            // Assert
            Assert.AreEqual(LIMIT, CheckFibonacciValues(fsEnum, LIMIT));
        }


        [Test]
        public void FibonacciSequenceWithLimitShouldReturnAnEmptySequenceWith0Limit()
        {
            // Arrange
            Ex3.FibonacciSequence fs = new Ex3.FibonacciSequence(0);

            // Act
            IEnumerator<int> fsEnum = fs.GetEnumerator();

            // Assert
            Assert.IsFalse(fsEnum.MoveNext());
        }

        #endregion

    }
}
