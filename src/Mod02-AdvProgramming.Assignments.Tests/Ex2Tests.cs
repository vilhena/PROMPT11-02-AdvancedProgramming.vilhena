namespace Mod02_AdvProgramming.Assignments.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class Ex2Tests
    {
        #region Test methods

        [Test]
        public void GenerateFansWithNullClubsShouldProduceNullFans()
        {
            // Arrange
            string[] clubs = null;

            // Act
            var fans = Ex2.GenerateFans(clubs);

            // Assert
            Assert.AreEqual(null, fans);
        }

        [Test]
        public void GenerateFansWith0ClubsShouldProduce0Fans()
        {
            // Arrange
            var clubs = new string[] { };

            // Act
            var fans = Ex2.GenerateFans(clubs);

            // Assert
            Assert.AreEqual(0, fans.Length);
        }

        [Test]
        public void GenerateFansShouldProduceSloganIncludingTheClubName()
        {
            // Arrange
            var clubs = new string[] { "Benfica" };

            // Act
            var fans = Ex2.GenerateFans(clubs);

            // Assert
            Assert.IsTrue(fans[0]().Slogan.ToLower().Contains(clubs[0].ToLower()));
        }

        [Test]
        public void GenerateFansForDifferentClubsShouldReturnDifferentLabels()
        {
            // Arrange
            var clubs = new string[] { "Atletico", "Belenenses", "Benfica" };

            // Act
            var fans = Ex2.GenerateFans(clubs);

            // Assert
            Assert.AreNotEqual(fans[0]().Label, fans[1]().Label);
            Assert.AreNotEqual(fans[1]().Label, fans[2]().Label);
            Assert.AreNotEqual(fans[2]().Label, fans[0]().Label);
        }

        [Test]
        public void GenerateFansForDifferentClubsShouldReturnDifferentSlogans()
        {
            // Arrange
            var clubs = new string[] { "Atletico", "Belenenses", "Benfica" };

            // Act
            var fans = Ex2.GenerateFans(clubs);

            // Assert
            Assert.AreNotEqual(fans[0]().Slogan, fans[1]().Slogan);
            Assert.AreNotEqual(fans[1]().Slogan, fans[2]().Slogan);
            Assert.AreNotEqual(fans[2]().Slogan, fans[0]().Slogan);
        }

        #endregion
    }
}