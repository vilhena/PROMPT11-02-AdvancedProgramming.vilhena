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

        public interface ISortedEnumerable<T> : IEnumerable<T>
        {

        }

        public class SortedEnumerable<T> : ISortedEnumerable<T>
        {
            public IEnumerable<T> Sequence { get; set; }
            public Comparison<T> Criteria { get; set; }

            public SortedEnumerable(IEnumerable<T> seq, Comparison<T> comp)
            {
                this.Sequence = seq;
                this.Criteria = comp;
            }


            public IEnumerator<T> GetEnumerator()
            {
                var a = new List<T>(Sequence);
                a.Sort(Criteria);
                return a.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

        }


        public static IEnumerable<T> RemoveRepeated<T>(this IEnumerable<T> seq)
        {
            var set = new HashSet<T>();

            foreach (var item in seq)
            {
                if (set.Contains(item))
                {
                    continue;
                }
                else
                {
                    set.Add(item);
                    yield return item;
                }
            }
        }


        public static ISortedEnumerable<T> OrderBy<T, U>(this IEnumerable<T> seq, Func<T, U> criterium)
                where U : IComparable<U>
        {
            return new SortedEnumerable<T>(seq, new Comparison<T>((t1, t2) => criterium(t1).CompareTo(criterium(t2))));
        }

        public static ISortedEnumerable<T> ThenBy<T, U>(this ISortedEnumerable<T> seq, Func<T, U> criterium)
                where U : IComparable<U>
        {
            var s = (SortedEnumerable<T>)seq;
            return new SortedEnumerable<T>(seq,
                                           (t1, t2) =>
                                           {
                                               var res = s.Criteria(t1, t2);
                                               if (res != 0)
                                                   return res;
                                               else
                                                   return criterium(t1).CompareTo(criterium(t2));
                                           }

                );
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
                    this IEnumerable<TOuter> outer,
                    IEnumerable<TInner> inner,
                    Func<TOuter, TKey> outerKeySelector,
                    Func<TInner, TKey> innerKeySelector,
                    Func<TOuter, TInner, TResult> resultSelector)
        {
            foreach (var outerObj in outer)
            {
                foreach (var innerObj in inner)
                {
                    if (outerKeySelector(outerObj).Equals(innerKeySelector(innerObj)))
                    {
                        yield return resultSelector(outerObj, innerObj);
                    }
                }
            }
        }



    }
}