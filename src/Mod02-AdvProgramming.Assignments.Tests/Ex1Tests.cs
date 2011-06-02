namespace Mod02_AdvProgramming.Assignments.Tests {
    using NUnit.Framework;

    [TestFixture]
    public class Ex1Tests {
        [Test]
        public void LessThanShouldReturnOnlyNonNullableElementsGreaterThanReferenceForNullableAndNonNullableElements() {
            // Arrange

            // Act
            var seq = Ex1.LessThan(new int?[] { 21, null, 34, null, null, 98, 72, 33, null, 9 },
                34);

            // Assert
            Assert.AreEqual(3, seq.Count);
            Assert.AreEqual(21, seq[0]);
            Assert.AreEqual(33, seq[1]);
            Assert.AreEqual(9, seq[2]);

        }

        [Test]
        public void LessThanShouldReturnAnEmptySequenceWhenAllElementsAreNullable() {
            // Arrange

            // Act
            var seq = Ex1.LessThan(new int?[] { null, null, null, null, null }, 34);

            // Assert
            Assert.AreEqual(0, seq.Count);
        }

        [Test]
        public void LessThanShouldReturnAnEmptySequenceWhenAllElementsAreNullableOrAboveReference() {
            // Arrange

            // Act
            var seq = Ex1.LessThan(new int?[] { 21, null, 34, null, null, 98, 72, 33, null, 9 },
                1);

            // Assert
            Assert.AreEqual(0, seq.Count);
        }

        [Test]
        public void LessThanShouldReturnAnEmptySequenceForANullSequence() {
            // Arrange

            // Act
            var seq = Ex1.LessThan(null, 1);

            // Assert
            Assert.AreEqual(0, seq.Count);
        }
    }
}
