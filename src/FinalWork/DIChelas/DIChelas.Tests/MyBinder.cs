// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyBinder.cs" company="ISEL/DEETC">
//   Ambientes Virtuais de Execução - Trabalho Final Inverno 2010/2011
// </copyright>
// <summary>
//   Class that implements the custom <see cref="Binder" /> for the current application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DIChelas.Tests {
    using SampleTypes;

    /// <summary>
    /// Class that implements the custom <see cref="Binder"/> for the current application.
    /// </summary>
    /// <remarks>
    /// The custom binder class is where you configure the DI container for the application specific types. 
    /// </remarks>
    public class MyBinder : Binder {
        /// <summary>
        /// Override this method to configure the application types binding. 
        /// </summary>
        protected override void InternalConfigure() {
				Bind<ISomeInterface2, SomeInterface2Impl>().WithActivation.PerRequest.InitializeObjectWith(o => { o.SomeInitializatonMethod(); o.SomeStr = "Initialized"; }).
                Bind<ISomeInterface3, SomeInterface3Impl>().
                WithNoArgumentsConstructor().
                WithActivation.Singleton.
                WithConstructor(typeof(int), typeof(ISomeInterface2), typeof(ISomeInterface1), typeof(string)).
                WithValues(() => new { p1 = 12, p3 = "SLB" }).
                Bind<ISomeInterface1, SomeInterface1Impl>().WithNoArgumentsConstructor().
                Bind<ISomeInterface4, SomeInterface4Impl>().WithNoArgumentsConstructor().
                Bind<ISomeInterface4, SomeInterface4Impl>().WithActivation.Singleton.
                Bind<ISomeInterface4, SomeInterface4Impl>().
                Bind<ISomeInterface5, SomeInterface5Impl>().
                Bind<SomeClass1, SomeClass1>().
                Bind<SomeClass2, SomeClass2>().
                Bind<SomeClass3, SomeClass3>().
                Bind<SomeClass4, SomeClass4>().
                Bind<SomeClass7, SomeClass7>().WithActivation.Singleton.
                Bind<SomeClass8, SomeClass8>();

            CustomResolver += MyCustomResolver.ResolveDummy;
            CustomResolver += MyCustomResolver.Resolve;
        }
    }
}
