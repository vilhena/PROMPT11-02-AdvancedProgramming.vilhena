// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyCustomResolver.cs" company="Centro de Cálculo do ISEL">
//   PROMPT 2011/2012 - Módulo 2 - Advanced Programming
// </copyright>
// <summary>
//   This class includes custom resolver sample methods for the <see cref="Binder"/>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ChelasInjection.Tests {
    using System;
    using SampleTypes;

    /// <summary>
    /// This class includes custom resolver sample methods for the <see cref="Binder"/>.
    /// </summary>
    /// <remarks>
    /// Custom resolver are method registered in <see cref="Binder.CustomResolver"/> event.
    /// In the instance creation process, custom resolvers have the higher priority to contribute
    /// with an instance for a given type.
    /// </remarks>
    public class MyCustomResolver {
        /// <summary>
        /// A Dummy custom resolver for <see cref="Binder.CustomResolver"/> event.
        /// This resolver never contributes with an instance in the instance creating process.
        /// </summary>
        /// <param name="sender">
        /// The <see cref="Binder"/> that generated the event. The resolver method might need some info 
        /// from the <see cref="Binder"/> to help the instance creation. 
        /// </param>
        /// <param name="t">The <see cref="Type"/> of the instance to be created.</param>
        /// <returns>
        /// An reference to an object on type <paramref name="t"/>, if the method wants to contribute with an instance;
        /// <code>null</code> otherwise.
        /// </returns>
        public static object ResolveDummy(Binder sender, Type t) {
            return null;
        }

        /// <summary>
        /// A custom resolver for <see cref="Binder.CustomResolver"/> event.
        /// This resolver contributes unconditionally with a new instance if the required type <paramref name="t"/>        
        /// is <see cref="SomeClass6"/> or <see cref="SomeClass7"/>. 
        /// </summary>
        /// <param name="sender">
        /// The <see cref="Binder"/> that generated the event. The resolver method might need some info 
        /// from the binder to help the instance creation. 
        /// </param>
        /// <param name="t">The <see cref="Type"/> of the instance to be created.</param>
        /// <returns>
        /// An reference to an object on type <paramref name="t"/>, if the method wants to contribute with an instance;
        /// <code>null</code> otherwise.
        /// </returns>
        public static object Resolve(Binder sender, Type t) {
            if (t == typeof(SomeClass6)) {
                return new SomeClass6();
            }

            if (t == typeof(SomeClass7)) {
                return new SomeClass7();
            }

            return null;
        }




        public static object AnotherResolver(Binder sender, Type t)
        {
            if (t == typeof(SomeClass8))
            {
                return new SomeClass8();
            }

            return null;
        }
    }
}