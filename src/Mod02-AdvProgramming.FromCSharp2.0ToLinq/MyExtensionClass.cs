// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyExtensionClass.cs" company="Centro de Cálculo do ISEL">
//   PROMPT 2011/2012
// </copyright>
// <summary>
//   Extention class with sample extension method operators.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace Mod02_AdvProgramming_FromCSharp2_0ToLinq
{
    using System.Collections.Generic;

    /// <summary>
    /// Extention class with sample extension method operators.
    /// </summary>
    public static class MyExtensionClass 
    {
        /// <summary>
        /// Converts all <see cref="Result.City"/> to uppercase.
        /// </summary>
        /// <param name="coll">The extended <see cref="IEnumerable{Result}"/></param>
        /// <returns>A sequence with all <see cref="Result.City"/> in uppercase.</returns>
        public static IEnumerable<Result> ToUpperCity(this IEnumerable<Result> coll)
        {
            foreach (Result item in coll) 
            {
                item.City = item.City.ToUpper();
                yield return item;
            }
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> list, Predicate<T> pred)
        {
            foreach (var item in list)
            {
                if (pred(item))
                    yield return item;
            }

        }

        public static IEnumerable<I> Select<T,I>(this IEnumerable<T> list, Func<T,I> selec)
        {
            foreach (var item in list)
            {
                yield return selec(item);
            }
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> list, IEnumerable<T> list2)
        {
            foreach (var item in list)
            {
                yield return item;
            }
            foreach (var item in list2)
            {
                yield return item;
            }
        }

        public static T Last<T>(this IEnumerable<T> list)
        {
            var ret = default(T);
            foreach (var item in list)
            {
                ret = item;
            }
            return ret;
        }

        public static IEnumerable<Ret> Zip<T,U,Ret>(IEnumerable<T> first,IEnumerable<U> second, Func<T,U,Ret> selec)
        {
            var i1 = first.GetEnumerator();
            var i2 = second.GetEnumerator();
            
            while (true)
            {
                if (i1.MoveNext() && i2.MoveNext())
                {
                    yield return selec(i1.Current, i2.Current);
                }
                else
                {
                    yield break;
                }
            }
        }

    }
}