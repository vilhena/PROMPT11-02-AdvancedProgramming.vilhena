using System.Diagnostics;

namespace Mod02_AdvProgramming.Assignments.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using Mod02_AdvProgramming.Data;
    using System.Linq;

    [TestFixture]
    public class Ex5Tests
    {
        #region Setup AndTearDown methods

        [TestFixtureSetUp]
        void SetUpFixture()
        {
            
        }

        #endregion Setup AndTearDown methods

        #region Test methods

        [Test]
        public void CustomerCountriesSortedShouldReturn21Countries()
        {
            // Arrange

            // Act
            var countries = Ex5.CustomerCountriesSorted();

            // Assert
            Assert.AreEqual(21, countries.Count());
        }

        [Test]
        public void CustomerCountriesSortedSelectFirstWitchIsFaster()
        {
            // Arrange

            // Act
            var clock1 = new Stopwatch();
            var clock2 = new Stopwatch();

            clock1.Start();
            for (int i = 0; i < 200; i++)
            {
                var countries = Ex5.CustomerCountriesSorted();
            }
            clock1.Stop();
            clock2.Start();
            for (int i = 0; i < 200; i++)
            {
                var countries2 = Ex5.CustomerCountriesSortedSelectFirst();
            }
            clock2.Stop();
            
            // Assert
            Assert.Greater(clock1.ElapsedMilliseconds, clock2.ElapsedMilliseconds);
        }

        #endregion
    }
}
