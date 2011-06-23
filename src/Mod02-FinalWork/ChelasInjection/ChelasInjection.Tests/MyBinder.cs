// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyBinder.cs" company="Centro de Cálculo do ISEL">
//   PROMPT 2011/2012 - Módulo 2 - Advanced Programming
// </copyright>
// <summary>
//   Class that implements the custom <see cref="Binder" /> for the current application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using ChelasInjection.SampleTypes.Attributes;

namespace ChelasInjection.Tests 
{
    using SampleTypes;

    /// <summary>
    /// Class that implements the custom <see cref="Binder"/> for the current application.
    /// </summary>
    /// <remarks>
    /// The custom binder class is where you configure the DI container for the application specific types. 
    /// </remarks>
    public class MyBinder : Binder 
    {
        /// <summary>
        /// Override this method to configure the application types binding. 
        /// </summary>
        protected override void InternalConfigure() {
            Bind<ISomeInterface2, SomeInterface2Impl>().WithActivation.PerRequest().InitializeObjectWith(o => { o.SomeInitializatonMethod(); o.SomeStr = "Initialized"; });
            Bind<ISomeInterface3, SomeInterface3Impl>().WithNoArgumentsConstructor().WithActivation.Singleton().
            WithConstructor(typeof(int), typeof(ISomeInterface2), typeof(ISomeInterface1), typeof(string)).
            WithValues(() => new { p1 = 12, p3 = "SLB" });
            Bind<ISomeInterface1, SomeInterface1Impl>().WithNoArgumentsConstructor();
            Bind<ISomeInterface4, SomeInterface4Impl>().WithNoArgumentsConstructor();
            Bind<ISomeInterface4, SomeInterface4Impl>().WithActivation.Singleton();
            Bind<ISomeInterface4, SomeInterface4Impl>();
            Bind<ISomeInterface5, SomeInterface5Impl>();
            Bind<SomeClass1, SomeClass1>();
            Bind<SomeClass2>();
            Bind<SomeClass3, SomeClass3>();
            Bind<SomeClass4, SomeClass4>();
            Bind<SomeClass9, SomeClass9>();
            Bind<SomeClass7>().WithActivation.Singleton();
            Bind<SomeClass8>().InitializeObjectWith(o => { o.Sc61 = o.Sc62 = new SomeClass6(); });
            Bind<ISomeInterface7, SomeInterface7Default>();
            Bind<ISomeInterface7, SomeInterface7And8Red>().WhenArgumentHas<RedAttribute>();
            Bind<ISomeInterface7, SomeInterface7And8Yellow>().WhenArgumentHas<YellowAttribute>();

            Bind<ISomeInterface8, SomeInterface7And8Red>().WhenArgumentHas<RedAttribute>();

            Bind<SomeClass16>().WithActivation.Singleton();
            //Bind<ISomeInterface7, SomeInterface7Red>().WithName("Red");
            //Bind<SomeClass13>().ForDependency<ISomeInterface7>().UseBindNamed("Red");

            CustomResolver += MyCustomResolver.Resolve;
            CustomResolver += MyCustomResolver.ResolveDummy;
            CustomResolver += MyCustomResolver.AnotherResolver;
        }
    }
}
