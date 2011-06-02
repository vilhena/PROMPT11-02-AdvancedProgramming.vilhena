namespace Mod02_AdvProgramming.Assignments.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class Ex4Tests {
        [Test]
        public void CountRepeatedShouldReturnAPairSequenceWhenThereAreRepeatedElements() {
            // Arrange
            int[] v = { 0, 1, 1, 2, 3, 3, 3, 4, 5 };

            // Act
            IEnumerable<Ex4.Pair<int, int>> repeated = Ex4.CountRepeated(v);

            // Assert
            Assert.AreEqual(2, repeated.Count());
        }

        [Test]
        public void CountRepeatedShouldReturnAnEmptySequenceWhenThereAreNoRepeatedElements() {
            // Arrange
            int[] v = { 0, 1, 2, 3, 4, 5, 2, 1 };

            // Act
            IEnumerable<Ex4.Pair<int, int>> repeated = Ex4.CountRepeated(v);


            // Assert
            Assert.AreEqual(0, repeated.Count());
        }

        [Test]
        public void CountRepeatedShouldReturnAnEmptySequenceForANullSequence() {
            // Arrange

            // Act
            IEnumerable<Ex4.Pair<int, int>> repeated = Ex4.CountRepeated<int>(null);

            // Assert
            Assert.AreEqual(0, repeated.Count());
        }
    }
}