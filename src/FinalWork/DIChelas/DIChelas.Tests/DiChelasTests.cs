// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiChelasTests.cs" company="ISEL/DEETC">
//   Ambientes Virtuais de Execução - Trabalho Final Inverno 2010/2011
// </copyright>
// <summary>
//   Includes the NUnit tests to the DIChelas infrastructure.
//   This class tests this infrastructure through the creation of an <see cref="Injector" />
//   with a <see cref="MyBinder" /> instance where the Binds are configured.
//   This <see cref="Injector" /> instance is kept in the <see cref="_injector" /> field used in all
//   test methods.
//   Each test method checks some particular behavior of the  infrastructure, making requests for types
//   to the <see cref="_injector" /> instance.
//   The type requested in these tests are some dymmy test specific types contained by the <see cref="DIChelas.SampleTypes" />
//   assembly.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DIChelas.Tests {
    using Exceptions;
    using NUnit.Framework;
    using SampleTypes;

    /// <summary>
    /// Includes NUnit tests to the DIChelas infrastructure. This class tests
    /// this infrastructure through the creation of an <see cref="Injector"/> 
    /// with a <see cref="MyBinder"/> instance, through which Binds are
    /// configured.  This <see cref="Injector"/> instance is kept in the 
    /// <see cref="_injector"/> field ans it's used in all  test methods. Each
    /// test method checks some particular behavior of the  infrastructure,
    /// requesting types to the <see cref="_injector"/> instance. The
    /// type requested in these tests are some dymmy test specific types,
    /// defined in <see cref="DIChelas.SampleTypes"/> assembly.
    /// </summary>
    [TestFixture]
    public class DiChelasTests {
        /// <summary>
        /// The <see cref="Injector"/> instance used in all tests.
        /// </summary>
        private Injector _injector;

        /// <summary>
        /// Setups the fixture. This method runs before any test runs.
        /// </summary>
        [TestFixtureSetUp]
        public void SetupFixture() {
            _injector = new Injector(new MyBinder());
        }

        #region Instance creation

        [Test]
        public void ShouldCreateASomeInterface1ImplInstanceForISomeInterface1Request() {
            // Arrange


            // Act
            ISomeInterface1 i1impl = _injector.GetInstance<ISomeInterface1>();

            // Assert

            Assert.AreEqual(i1impl.GetType(), typeof(SomeInterface1Impl));
        }

        [Test]
        public void ShouldCreateASomeInterface2ImplInstanceForISomeInterface2RequestAndAlsoCreateItsDependencies() {

            ISomeInterface2 i2impl = _injector.GetInstance<ISomeInterface2>();

            Assert.AreEqual(i2impl.GetType(), typeof(SomeInterface2Impl));
            Assert.IsNotNull(i2impl.I1);
        }


        [Test]
        public void ShouldCreateASomeInterface3ImplInstanceForISomeInterface2RequestAndAlsoCreateItsDependencies() {

            ISomeInterface3 i3impl = _injector.GetInstance<ISomeInterface3>();

            Assert.AreEqual(i3impl.GetType(), typeof(SomeInterface3Impl));
            Assert.IsNotNull(i3impl.I1);
            Assert.IsNotNull(i3impl.I2);
            Assert.IsNotNull(i3impl.I2.I1);
        }

        [Test]
        public void ShouldCreateASomeClass4InstanceForSomeClass4Request() {
            // Arrange

            // Act
            SomeClass4 sc4 = _injector.GetInstance<SomeClass4>();

            // Assert
            Assert.AreEqual(sc4.GetType(), typeof(SomeClass4));
        }

        [Test, ExpectedException(typeof(CircularDependencyException))]
        public void ShouldThrowCircularDependencyExceptionOnInstantiationForSomeClass1() {
            // Arrange

            // Act
            SomeClass1 sc1 = _injector.GetInstance<SomeClass1>();

            // Assert
            Assert.Fail("The Injector.GetInstance should have thrown a CircularDependencyException");
        }

        [Test, ExpectedException(typeof(UnboundTypeException))]
        public void ShouldThrowUnboundTypeExceptionForAnUnboundType() {
            // Arrange

            // Act
            _injector.GetInstance<SomeClass5>();

            // Assert
            Assert.Fail("The Injector.GetInstance should have thrown a UnboundTypeException");
        }

        #endregion Instance creation

        #region Activation tests
        [Test]
        public void ShouldHavePerRequestAsDefaultActivation() {
            // Arrange

            // Act
            ISomeInterface1 i1impl = _injector.GetInstance<ISomeInterface1>();
            ISomeInterface1 i1impl1 = _injector.GetInstance<ISomeInterface1>();


            // Assert
            Assert.AreNotSame(i1impl, i1impl1);
        }


        [Test]
        public void ShouldHaveDefautActivationOnDependencies() {
            // Arrange

            // Act
            ISomeInterface2 i2impl = _injector.GetInstance<ISomeInterface2>();
            ISomeInterface2 i2impl1 = _injector.GetInstance<ISomeInterface2>();


            // Assert
            Assert.AreNotSame(i2impl.I1, i2impl1.I1);
        }

        [Test]
        public void ShouldHavePerRequestActivationForISomeInterface2Request() {
            // Arrange

            // Act
            ISomeInterface2 i2impl = _injector.GetInstance<ISomeInterface2>();
            ISomeInterface2 i2impl1 = _injector.GetInstance<ISomeInterface2>();


            // Assert
            Assert.AreNotSame(i2impl, i2impl1);

        }


        [Test]
        public void ShouldHaveSingletonActivationForISomeInterface3Request() {
            // Arrange

            // Act
            ISomeInterface3 i3impl = _injector.GetInstance<ISomeInterface3>();
            ISomeInterface3 i3impl1 = _injector.GetInstance<ISomeInterface3>();


            // Assert
            Assert.AreSame(i3impl, i3impl1);
        }

        [Test]
        public void ShouldHavePerCallActivationForDependenciesISomeInterface3Instances() {
            // Arrange

            // Act
            ISomeInterface3 i3impl = _injector.GetInstance<ISomeInterface3>();


            // Assert
            Assert.AreSame(i3impl.I1, i3impl.I2.I1);

        }

        #endregion Activation tests

        #region Instance Initialization & construction
        [Test]
        public void ShouldExecuteInitializationExpressionForISomeInterface2Impl() {
            // Arrange

            // Act
            ISomeInterface2 i2impl = _injector.GetInstance<ISomeInterface2>();


            // Assert
            Assert.AreEqual(1, i2impl.SomeInt);
            Assert.AreEqual("Initialized", i2impl.SomeStr);

        }


        [Test]
        public void ShouldChooseTheConstructorWithMoreBindedArgumenstByDefault() {
            // Arrange

            // Act
            ISomeInterface4 i4impl = _injector.GetInstance<ISomeInterface4>();


            // Assert
            Assert.IsNotNull(i4impl.I1);
            Assert.IsNotNull(i4impl.I2);

        }

        [Test]
        public void ShouldChooseTheConstructorAnotatedWithDefaulAttributeForISomeInterface5() {
            // Arrange

            // Act
            ISomeInterface5 i5impl = _injector.GetInstance<ISomeInterface5>();


            // Assert
            Assert.IsNotNull(i5impl.I1);
            Assert.IsNull(i5impl.I2);

        }

        [Test]
        public void ShouldChooseTheCorrectConstructorWhenWithConstructorOperatorIsUsedForISomeInterface2() {
            // Arrange

            // Act
            ISomeInterface3 i3impl = _injector.GetInstance<ISomeInterface3>();


            // Assert
            Assert.IsNotNull(i3impl.I1);
            Assert.IsNotNull(i3impl.I2);
            Assert.AreEqual(12, i3impl.P1);
            Assert.AreEqual("SLB", i3impl.P3);

        }

        [Test]
        public void ShouldChooseTheNoArgumentsConstructorWhenNoArgumentsConstructorOperatorIsUsedForISomeInterface1() {
            // Arrange

            // Act
            ISomeInterface1 i1impl = _injector.GetInstance<ISomeInterface1>();


            // Assert
            // If no exception is thrown, the implementation has the correct behaviour 
            // (See public SomeInterface1Impl.SomeInterface1Impl(ISomeInterface5 i5) implementation) 
        }

        #endregion Instance Initialization & construction

        #region Multiple specifications

        [Test]
        public void ShouldUseTheLastBindForISomeInterface4() {
            // Arrange

            // Act
            ISomeInterface4 i4impl = _injector.GetInstance<ISomeInterface4>();


            // Assert
            Assert.IsNotNull(i4impl.I1);
            Assert.IsNotNull(i4impl.I2);

        }


        [Test]
        public void ShouldUseTheLastConstructorDefinitionInOneBindForISomeInterface3() {
            // Arrange

            // Act
            ISomeInterface3 i3impl = _injector.GetInstance<ISomeInterface3>();

            // Assert
            Assert.IsNotNull(i3impl.I1);
            Assert.IsNotNull(i3impl.I2);
            Assert.AreEqual(12, i3impl.P1);
            Assert.AreEqual("SLB", i3impl.P3);
        }

        #endregion Multiple specifications


        #region Custom Resolver tests
        [Test]
        public void ShouldReturnSomaClass6NotBoundAndCreatedByTheCustomResolver() {
            // Arrange

            // Act
            SomeClass6 sc6 = _injector.GetInstance<SomeClass6>();

            // Assert
            Assert.IsNotNull(sc6);
        }


        [Test]
        public void ShouldGivePriorirtyToCustomresolverAlthoughSomeClass7IsBound() {
            // Arrange

            // Act
            SomeClass7 sc7 = _injector.GetInstance<SomeClass7>();

            // Assert
            Assert.IsNotNull(sc7);
            Assert.IsNull(sc7.Sc6);
        }


        [Test]
        public void ShouldHavePerRequestActivationForNotBoundClass6ButWithCustomResolverProvidedInstance() {
            // Arrange

            // Act
            SomeClass8 sc8 = _injector.GetInstance<SomeClass8>();

            // Assert
            Assert.IsNotNull(sc8);
            Assert.IsNotNull(sc8.Sc61);
            Assert.AreSame(sc8.Sc61, sc8.Sc62);
        }

        [Test]
        public void ShouldHaveBindDefinedActivationForSomeClass7CustomResolverProvidedInstances() {
            // Arrange

            // Act
            SomeClass7 sc7 = _injector.GetInstance<SomeClass7>();
            SomeClass7 sc71 = _injector.GetInstance<SomeClass7>();

            // Assert
            Assert.IsNotNull(sc7);
            Assert.AreSame(sc7, sc71);
        }
        #endregion Custom Resolver tests
    }
}