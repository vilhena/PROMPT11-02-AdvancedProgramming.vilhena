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
        protected override void InternalConfigure()
        {
            //Bind<ISomeInterface2, SomeInterface2Impl>()
            //    .WithActivation
            //    .PerRequest
            //    .InitializeObjectWith(o =>
            //                              {
            //                                  o.SomeInitializatonMethod();
            //                                  o.SomeStr = "Initialized";
            //                              })
            //    .Bind<ISomeInterface3, SomeInterface3Impl>()
            //    .WithNoArgumentsConstructor()
            //    .WithActivation
            //    .Singleton
            //    .WithConstructor(typeof (int), typeof (ISomeInterface2), typeof (ISomeInterface1), typeof (string))
            //    .WithValues(() => new {p1 = 12, p3 = "SLB"})
            //    .Bind<ISomeInterface1, SomeInterface1Impl>()
            //    .WithNoArgumentsConstructor()
            //    .Bind<ISomeInterface4, SomeInterface4Impl>()
            //    .WithNoArgumentsConstructor()
            //    .Bind<ISomeInterface4, SomeInterface4Impl>()
            //    .WithActivation
            //    .Singleton
            //    .Bind<ISomeInterface4, SomeInterface4Impl>()
            //    .Bind<ISomeInterface5, SomeInterface5Impl>()
            //    .Bind<SomeClass1, SomeClass1>()
            //    .Bind<SomeClass2, SomeClass2>()
            //    .Bind<SomeClass3, SomeClass3>()
            //    .Bind<SomeClass4, SomeClass4>()
            //    .Bind<SomeClass7, SomeClass7>()
            //    .WithActivation
            //    .Singleton
            //    .Bind<SomeClass8, SomeClass8>();

            var x1 = Bind<ISomeInterface2, SomeInterface2Impl>();
            var x2 = x1
                .WithActivation;
            var x3 = x2
                .PerRequest;
            var x4 = x3
                .InitializeObjectWith(o =>
                                          {
                                              o.SomeInitializatonMethod();
                                              o.SomeStr = "Initialized";
                                          });
            var x5 = x4
                .Bind<ISomeInterface3, SomeInterface3Impl>();
            var x6 = x5
                .WithNoArgumentsConstructor();
            var x7 = x6
                .WithActivation;
            var x8 = x7
                .Singleton;
            var x9 = x8
                .WithConstructor(typeof(int), typeof(ISomeInterface2), typeof(ISomeInterface1), typeof(string));
            var x10 = x9
                .WithValues(() => new { p1 = 12, p3 = "SLB" });
            var x11 = x10
                .Bind<ISomeInterface1, SomeInterface1Impl>();
            var x12 = x11
                .WithNoArgumentsConstructor();
            var x13 = x12
                .Bind<ISomeInterface4, SomeInterface4Impl>();
            var x14 = x13
                .WithNoArgumentsConstructor();
            var x15 = x14
                .Bind<ISomeInterface4, SomeInterface4Impl>();
            var x16 = x15
                .WithActivation;
            var x17 = x16
                .Singleton;
            var x18 = x17
                .Bind<ISomeInterface4, SomeInterface4Impl>();
            var x19 = x18
                .Bind<ISomeInterface5, SomeInterface5Impl>();
            var x20 = x19
                .Bind<SomeClass1, SomeClass1>();
            var x21 = x20
                .Bind<SomeClass2, SomeClass2>();
            var x22 = x21
                .Bind<SomeClass3, SomeClass3>();
            var x23 = x22
                .Bind<SomeClass4, SomeClass4>();
            var x24 = x23
                .Bind<SomeClass7, SomeClass7>();
            var x25 = x24
                .WithActivation;
            var x26 = x25
                .Singleton;
            var x27 = x26
                .Bind<SomeClass8, SomeClass8>();

            CustomResolver += MyCustomResolver.ResolveDummy;
            CustomResolver += MyCustomResolver.Resolve;
        }
    }
}
