using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace System.Query
{
    public delegate T Func<T>();
    public delegate T Func<A0, T>(A0 arg0);
    public delegate T Func<A0, A1, T>(A0 arg0, A1 arg1);
    public delegate T Func<A0, A1, A2, T>(A0 arg0, A1 arg1, A2 arg2);
    public delegate T Func<A0, A1, A2, A3, T>(A0 arg0, A1 arg1, A2 arg2, A3 arg3);

    public static class Sequence
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            return WhereIterator<T>(source, predicate);
        }

        static IEnumerable<T> WhereIterator<T>(IEnumerable<T> source, Func<T, bool> predicate) {
            foreach (T element in source) {
                if (predicate(element)) yield return element;
            }
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, int, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            return WhereIterator<T>(source, predicate);
        }

        static IEnumerable<T> WhereIterator<T>(IEnumerable<T> source, Func<T, int, bool> predicate) {
            int index = 0;
            foreach (T element in source) {
                if (predicate(element, index)) yield return element;
                index++;
            }
        }

        public static IEnumerable<S> Select<T, S>(this IEnumerable<T> source, Func<T, S> selector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (selector == null) throw Error.ArgumentNull("selector");
            return SelectIterator<T, S>(source, selector);
        }

        static IEnumerable<S> SelectIterator<T, S>(IEnumerable<T> source, Func<T, S> selector) {
            foreach (T element in source) {
                yield return selector(element);
            }
        }

        public static IEnumerable<S> Select<T, S>(this IEnumerable<T> source, Func<T, int, S> selector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (selector == null) throw Error.ArgumentNull("selector");
            return SelectIterator<T, S>(source, selector);
        }

        static IEnumerable<S> SelectIterator<T, S>(IEnumerable<T> source, Func<T, int, S> selector) {
            int index = 0;
            foreach (T element in source) {
                yield return selector(element, index);
                index++;
            }
        }

        public static IEnumerable<S> SelectMany<T, S>(this IEnumerable<T> source, Func<T, IEnumerable<S>> selector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (selector == null) throw Error.ArgumentNull("selector");
            return SelectManyIterator<T, S>(source, selector);
        }

        static IEnumerable<S> SelectManyIterator<T, S>(IEnumerable<T> source, Func<T, IEnumerable<S>> selector) {
            foreach (T element in source) {
                foreach (S subElement in selector(element)) {
                    yield return subElement;
                }
            }
        }

        public static IEnumerable<S> SelectMany<T, S>(this IEnumerable<T> source, Func<T, int, IEnumerable<S>> selector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (selector == null) throw Error.ArgumentNull("selector");
            return SelectManyIterator<T, S>(source, selector);
        }

        static IEnumerable<S> SelectManyIterator<T, S>(IEnumerable<T> source, Func<T, int, IEnumerable<S>> selector) {
            int index = 0;
            foreach (T element in source) {
                foreach (S subElement in selector(element, index)) {
                    yield return subElement;
                }
                index++;
            }
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> source, int count) {
            if (source == null) throw Error.ArgumentNull("source");
            return TakeIterator<T>(source, count);
        }

        static IEnumerable<T> TakeIterator<T>(IEnumerable<T> source, int count) {
            if (count > 0) {
                foreach (T element in source) {
                    yield return element;
                    if (--count == 0) break;
                }
            }
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            return TakeWhileIterator<T>(source, predicate);
        }

        static IEnumerable<T> TakeWhileIterator<T>(IEnumerable<T> source, Func<T, bool> predicate) {
            foreach (T element in source) {
                if (!predicate(element)) break;
                yield return element;
            }
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, int, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            return TakeWhileIterator<T>(source, predicate);
        }

        static IEnumerable<T> TakeWhileIterator<T>(IEnumerable<T> source, Func<T, int, bool> predicate) {
            int index = 0;
            foreach (T element in source) {
                if (!predicate(element, index)) break;
                yield return element;
                index++;
            }
        }

        public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count) {
            if (source == null) throw Error.ArgumentNull("source");
            return SkipIterator<T>(source, count);
        }

        static IEnumerable<T> SkipIterator<T>(IEnumerable<T> source, int count) {
            using (IEnumerator<T> e = source.GetEnumerator()) {
                while (count > 0 && e.MoveNext()) count--;
                if (count <= 0) {
                    while (e.MoveNext()) yield return e.Current;
                }
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            return SkipWhileIterator<T>(source, predicate);
        }

        static IEnumerable<T> SkipWhileIterator<T>(IEnumerable<T> source, Func<T, bool> predicate) {
            bool yielding = false;
            foreach (T element in source) {
                if (!yielding && !predicate(element)) yielding = true;
                if (yielding) yield return element;
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Func<T, int, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            return SkipWhileIterator<T>(source, predicate);
        }

        static IEnumerable<T> SkipWhileIterator<T>(IEnumerable<T> source, Func<T, int, bool> predicate) {
            int index = 0;
            bool yielding = false;
            foreach (T element in source) {
                if (!yielding && !predicate(element, index)) yielding = true;
                if (yielding) yield return element;
                index++;
            }
        }

        public static IEnumerable<V> Join<T, U, K, V>(this IEnumerable<T> outer, IEnumerable<U> inner, Func<T, K> outerKeySelector, Func<U, K> innerKeySelector, Func<T, U, V> resultSelector) {
            if (outer == null) throw Error.ArgumentNull("outer");
            if (inner == null) throw Error.ArgumentNull("inner");
            if (outerKeySelector == null) throw Error.ArgumentNull("outerKeySelector");
            if (innerKeySelector == null) throw Error.ArgumentNull("innerKeySelector");
            if (resultSelector == null) throw Error.ArgumentNull("resultSelector");
            return JoinIterator<T, U, K, V>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);
        }

        static IEnumerable<V> JoinIterator<T, U, K, V>(IEnumerable<T> outer, IEnumerable<U> inner, Func<T, K> outerKeySelector, Func<U, K> innerKeySelector, Func<T, U, V> resultSelector) {
            Lookup<K, U> lookup = inner.ToLookup(innerKeySelector);
            foreach (T item in outer) {
                Lookup<K, U>.Grouping g = lookup.GetGrouping(outerKeySelector(item), false);
                if (g != null) {
                    for (int i = 0; i < g.count; i++) {
                        yield return resultSelector(item, g.elements[i]);
                    }
                }
            }
        }

        public static IEnumerable<V> GroupJoin<T, U, K, V>(this IEnumerable<T> outer, IEnumerable<U> inner, Func<T, K> outerKeySelector, Func<U, K> innerKeySelector, Func<T, IEnumerable<U>, V> resultSelector) {
            if (outer == null) throw Error.ArgumentNull("outer");
            if (inner == null) throw Error.ArgumentNull("inner");
            if (outerKeySelector == null) throw Error.ArgumentNull("outerKeySelector");
            if (innerKeySelector == null) throw Error.ArgumentNull("innerKeySelector");
            if (resultSelector == null) throw Error.ArgumentNull("resultSelector");
            return GroupJoinIterator<T, U, K, V>(outer, inner, outerKeySelector, innerKeySelector, resultSelector);
        }

        static IEnumerable<V> GroupJoinIterator<T, U, K, V>(IEnumerable<T> outer, IEnumerable<U> inner, Func<T, K> outerKeySelector, Func<U, K> innerKeySelector, Func<T, IEnumerable<U>, V> resultSelector) {
            Lookup<K, U> lookup = inner.ToLookup(innerKeySelector);
            foreach (T item in outer) {
                yield return resultSelector(item, lookup[outerKeySelector(item)]);
            }
        }

        public static OrderedSequence<T> OrderBy<T, K>(this IEnumerable<T> source, Func<T, K> keySelector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            return new OrderedSequence<T, K>(source, keySelector, null, false);
        }

        public static OrderedSequence<T> OrderBy<T, K>(this IEnumerable<T> source, Func<T, K> keySelector, IComparer<K> comparer) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            if (comparer == null) throw Error.ArgumentNull("comparer");
            return new OrderedSequence<T, K>(source, keySelector, comparer, false);
        }

        public static OrderedSequence<T> OrderByDescending<T, K>(this IEnumerable<T> source, Func<T, K> keySelector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            return new OrderedSequence<T, K>(source, keySelector, null, true);
        }

        public static OrderedSequence<T> OrderByDescending<T, K>(this IEnumerable<T> source, Func<T, K> keySelector, IComparer<K> comparer) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            if (comparer == null) throw Error.ArgumentNull("comparer");
            return new OrderedSequence<T, K>(source, keySelector, comparer, true);
        }

        public static OrderedSequence<T> ThenBy<T, K>(this OrderedSequence<T> source, Func<T, K> keySelector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            return new OrderedSequence<T, K>(source, keySelector, null, false);
        }

        public static OrderedSequence<T> ThenBy<T, K>(this OrderedSequence<T> source, Func<T, K> keySelector, IComparer<K> comparer) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            if (comparer == null) throw Error.ArgumentNull("comparer");
            return new OrderedSequence<T, K>(source, keySelector, comparer, false);
        }

        public static OrderedSequence<T> ThenByDescending<T, K>(this OrderedSequence<T> source, Func<T, K> keySelector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            return new OrderedSequence<T, K>(source, keySelector, null, true);
        }

        public static OrderedSequence<T> ThenByDescending<T, K>(this OrderedSequence<T> source, Func<T, K> keySelector, IComparer<K> comparer) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            if (comparer == null) throw Error.ArgumentNull("comparer");
            return new OrderedSequence<T, K>(source, keySelector, comparer, true);
        }

        public static IEnumerable<IGrouping<K, T>> GroupBy<T, K>(this IEnumerable<T> source, Func<T, K> keySelector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            return new GroupedSequence<T, K, T>(source, keySelector, IdentityFunction<T>.Instance, null);
        }

        public static IEnumerable<IGrouping<K, T>> GroupBy<T, K>(this IEnumerable<T> source, Func<T, K> keySelector, IEqualityComparer<K> comparer) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            if (comparer == null) throw Error.ArgumentNull("comparer");
            return new GroupedSequence<T, K, T>(source, keySelector, IdentityFunction<T>.Instance, comparer);
        }

        public static IEnumerable<IGrouping<K, E>> GroupBy<T, K, E>(this IEnumerable<T> source, Func<T, K> keySelector, Func<T, E> elementSelector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            if (elementSelector == null) throw Error.ArgumentNull("elementSelector");
            return new GroupedSequence<T, K, E>(source, keySelector, elementSelector, null);
        }

        public static IEnumerable<IGrouping<K, E>> GroupBy<T, K, E>(this IEnumerable<T> source, Func<T, K> keySelector, Func<T, E> elementSelector, IEqualityComparer<K> comparer) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            if (elementSelector == null) throw Error.ArgumentNull("elementSelector");
            if (comparer == null) throw Error.ArgumentNull("comparer");
            return new GroupedSequence<T, K, E>(source, keySelector, elementSelector, comparer);
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, IEnumerable<T> second) {
            if (first == null) throw Error.ArgumentNull("first");
            if (second == null) throw Error.ArgumentNull("second");
            return ConcatIterator<T>(first, second);
        }

        static IEnumerable<T> ConcatIterator<T>(IEnumerable<T> first, IEnumerable<T> second) {
            foreach (T element in first) yield return element;
            foreach (T element in second) yield return element;
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            return DistinctIterator<T>(source);
        }

        static IEnumerable<T> DistinctIterator<T>(IEnumerable<T> source) {
            Dictionary<T, object> dict = new Dictionary<T, object>();
            foreach (T element in source) {
                if (!dict.ContainsKey(element)) {
                    dict.Add(element, null);
                    yield return element;
                }
            }
        }

        public static IEnumerable<T> Union<T>(this IEnumerable<T> first, IEnumerable<T> second) {
            if (first == null) throw Error.ArgumentNull("first");
            if (second == null) throw Error.ArgumentNull("second");
            return UnionIterator<T>(first, second);
        }

        static IEnumerable<T> UnionIterator<T>(IEnumerable<T> first, IEnumerable<T> second) {
            Dictionary<T, object> dict = new Dictionary<T, object>();
            foreach (T element in first) {
                if (!dict.ContainsKey(element)) {
                    dict.Add(element, null);
                    yield return element;
                }
            }
            foreach (T element in second) {
                if (!dict.ContainsKey(element)) {
                    dict.Add(element, null);
                    yield return element;
                }
            }
        }

        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> first, IEnumerable<T> second) {
            if (first == null) throw Error.ArgumentNull("first");
            if (second == null) throw Error.ArgumentNull("second");
            return IntersectIterator<T>(first, second);
        }

        static IEnumerable<T> IntersectIterator<T>(IEnumerable<T> first, IEnumerable<T> second) {
            Dictionary<T, object> dict = new Dictionary<T, object>();
            foreach (T element in first) dict[element] = null;
            foreach (T element in second) {
                if (dict.ContainsKey(element)) dict[element] = dict;
            }
            foreach (KeyValuePair<T, object> pair in dict) {
                if (pair.Value != null) yield return pair.Key;
            }
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> first, IEnumerable<T> second) {
            if (first == null) throw Error.ArgumentNull("first");
            if (second == null) throw Error.ArgumentNull("second");
            return ExceptIterator<T>(first, second);
        }

        static IEnumerable<T> ExceptIterator<T>(IEnumerable<T> first, IEnumerable<T> second) {
            Dictionary<T, object> dict = new Dictionary<T, object>();
            foreach (T element in first) dict[element] = null;
            foreach (T element in second) dict.Remove(element);
            foreach (T element in dict.Keys) yield return element;
        }

        public static IEnumerable<T> Reverse<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            return ReverseIterator<T>(source);
        }

        static IEnumerable<T> ReverseIterator<T>(IEnumerable<T> source) {
            Buffer<T> buffer = new Buffer<T>(source);
            for (int i = buffer.count - 1; i >= 0; i--) yield return buffer.items[i];
        }

        public static bool EqualAll<T>(this IEnumerable<T> first, IEnumerable<T> second) {
            if (first == null) throw Error.ArgumentNull("first");
            if (second == null) throw Error.ArgumentNull("second");
            using (IEnumerator<T> e1 = first.GetEnumerator())
            using (IEnumerator<T> e2 = second.GetEnumerator()) {
                while (e1.MoveNext()) {
                    if (!(e2.MoveNext() && Equals(e1.Current, e2.Current))) return false;
                }
                if (e2.MoveNext()) return false;
            }
            return true;
        }

        public static IEnumerable<T> ToSequence<T>(this IEnumerable<T> source) {
            return source;
        }

        public static T[] ToArray<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            return new Buffer<T>(source).ToArray();
        }

        public static List<T> ToList<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            return new List<T>(source);
        }

        public static Dictionary<K, T> ToDictionary<T, K>(this IEnumerable<T> source, Func<T, K> keySelector) {
            return ToDictionary<T, K, T>(source, keySelector, IdentityFunction<T>.Instance, null);
        }

        public static Dictionary<K, T> ToDictionary<T, K>(this IEnumerable<T> source, Func<T, K> keySelector, IEqualityComparer<K> comparer) {
            return ToDictionary<T, K, T>(source, keySelector, IdentityFunction<T>.Instance, comparer);
        }

        public static Dictionary<K, E> ToDictionary<T, K, E>(this IEnumerable<T> source, Func<T, K> keySelector, Func<T, E> elementSelector) {
            return ToDictionary<T, K, E>(source, keySelector, elementSelector, null);
        }

        public static Dictionary<K, E> ToDictionary<T, K, E>(this IEnumerable<T> source, Func<T, K> keySelector, Func<T, E> elementSelector, IEqualityComparer<K> comparer) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            if (elementSelector == null) throw Error.ArgumentNull("elementSelector");
            Dictionary<K, E> d = new Dictionary<K, E>(comparer);
            foreach (T element in source) d.Add(keySelector(element), elementSelector(element));
            return d;
        }

        public static Lookup<K, T> ToLookup<T, K>(this IEnumerable<T> source, Func<T, K> keySelector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            return Lookup<K, T>.Create(source, keySelector, IdentityFunction<T>.Instance, null);
        }

        public static Lookup<K, T> ToLookup<T, K>(this IEnumerable<T> source, Func<T, K> keySelector, IEqualityComparer<K> comparer) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            if (comparer == null) throw Error.ArgumentNull("comparer");
            return Lookup<K, T>.Create(source, keySelector, IdentityFunction<T>.Instance, comparer);
        }

        public static Lookup<K, E> ToLookup<T, K, E>(this IEnumerable<T> source, Func<T, K> keySelector, Func<T, E> elementSelector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            if (elementSelector == null) throw Error.ArgumentNull("elementSelector");
            return Lookup<K, E>.Create(source, keySelector, elementSelector, null);
        }

        public static Lookup<K, E> ToLookup<T, K, E>(this IEnumerable<T> source, Func<T, K> keySelector, Func<T, E> elementSelector, IEqualityComparer<K> comparer) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            if (elementSelector == null) throw Error.ArgumentNull("elementSelector");
            if (comparer == null) throw Error.ArgumentNull("comparer");
            return Lookup<K, E>.Create(source, keySelector, elementSelector, comparer);
        }

        public static IEnumerable<T> DefaultIfEmpty<T>(this IEnumerable<T> source) {
            return DefaultIfEmpty(source, default(T));
        }

        public static IEnumerable<T> DefaultIfEmpty<T>(this IEnumerable<T> source, T defaultValue) {
            if (source == null) throw Error.ArgumentNull("source");
            return DefaultIfEmptyIterator<T>(source, defaultValue);
        }

        static IEnumerable<T> DefaultIfEmptyIterator<T>(IEnumerable<T> source, T defaultValue) {
            using (IEnumerator<T> e = source.GetEnumerator()) {
                if (e.MoveNext()) {
                    do {
                        yield return e.Current;
                    } while (e.MoveNext());
                }
                else {
                    yield return defaultValue;
                }
            }
        }

        public static IEnumerable<T> OfType<T>(this IEnumerable source) {
            if (source == null) throw Error.ArgumentNull("source");
            return OfTypeIterator<T>(source);
        }

        static IEnumerable<T> OfTypeIterator<T>(IEnumerable source) {
            foreach (object obj in source) {
                if (obj is T) yield return (T)obj;
            }
        }

        public static IEnumerable<T> Cast<T>(this IEnumerable source) {
            if (source == null) throw Error.ArgumentNull("source");
            return CastIterator<T>(source);
        }

        static IEnumerable<T> CastIterator<T>(IEnumerable source) {
            foreach (object obj in source) yield return (T)obj;
        }

        public static T First<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            IList<T> list = source as IList<T>;
            if (list != null) {
                if (list.Count > 0) return list[0];
            }
            else {
                using (IEnumerator<T> e = source.GetEnumerator()) {
                    if (e.MoveNext()) return e.Current;
                }
            }
            throw Error.NoElements();
        }

        public static T First<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            foreach (T element in source) {
                if (predicate(element)) return element;
            }
            throw Error.NoMatch();
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            IList<T> list = source as IList<T>;
            if (list != null) {
                if (list.Count > 0) return list[0];
            }
            else {
                using (IEnumerator<T> e = source.GetEnumerator()) {
                    if (e.MoveNext()) return e.Current;
                }
            }
            return default(T);
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            foreach (T element in source) {
                if (predicate(element)) return element;
            }
            return default(T);
        }

        public static T Last<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            IList<T> list = source as IList<T>;
            if (list != null) {
                int count = list.Count;
                if (count > 0) return list[count - 1];
            }
            else {
                using (IEnumerator<T> e = source.GetEnumerator()) {
                    if (e.MoveNext()) {
                        T result;
                        do {
                            result = e.Current;
                        } while (e.MoveNext());
                        return result;
                    }
                }
            }
            throw Error.NoElements();
        }

        public static T Last<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            T result = default(T);
            bool found = false;
            foreach (T element in source) {
                if (predicate(element)) {
                    result = element;
                    found = true;
                }
            }
            if (found) return result;
            throw Error.NoMatch();
        }

        public static T LastOrDefault<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            IList<T> list = source as IList<T>;
            if (list != null) {
                int count = list.Count;
                if (count > 0) return list[count - 1];
            }
            else {
                using (IEnumerator<T> e = source.GetEnumerator()) {
                    if (e.MoveNext()) {
                        T result;
                        do {
                            result = e.Current;
                        } while (e.MoveNext());
                        return result;
                    }
                }
            }
            return default(T);
        }

        public static T LastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            T result = default(T);
            foreach (T element in source) {
                if (predicate(element)) {
                    result = element;
                }
            }
            return result;
        }

        public static T Single<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            IList<T> list = source as IList<T>;
            if (list != null) {
                switch (list.Count) {
                    case 0: throw Error.NoElements();
                    case 1: return list[0];
                }
            }
            else {
                using (IEnumerator<T> e = source.GetEnumerator()) {
                    if (!e.MoveNext()) throw Error.NoElements();
                    T result = e.Current;
                    if (!e.MoveNext()) return result;
                }
            }
            throw Error.MoreThanOneElement();
        }

        public static T Single<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            T result = default(T);
            long count = 0;
            foreach (T element in source) {
                if (predicate(element)) {
                    result = element;
                    count++;
                }
            }
            switch (count) {
                case 0: throw Error.NoMatch();
                case 1: return result;
            }
            throw Error.MoreThanOneMatch();
        }

        public static T SingleOrDefault<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            IList<T> list = source as IList<T>;
            if (list != null) {
                switch (list.Count) {
                    case 0: return default(T);
                    case 1: return list[0];
                }
            }
            else {
                using (IEnumerator<T> e = source.GetEnumerator()) {
                    if (!e.MoveNext()) return default(T);
                    T result = e.Current;
                    if (!e.MoveNext()) return result;
                }
            }
            throw Error.MoreThanOneElement();
        }

        public static T SingleOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            T result = default(T);
            long count = 0;
            foreach (T element in source) {
                if (predicate(element)) {
                    result = element;
                    count++;
                }
            }
            switch (count) {
                case 0: return default(T);
                case 1: return result;
            }
            throw Error.MoreThanOneMatch();
        }

        public static T ElementAt<T>(this IEnumerable<T> source, int index) {
            IList<T> list = source as IList<T>;
            if (list != null) return list[index];
            if (index < 0) throw Error.ArgumentOutOfRange("index");
            using (IEnumerator<T> e = source.GetEnumerator()) {
                while (true) {
                    if (!e.MoveNext()) throw Error.ArgumentOutOfRange("index");
                    if (index == 0) return e.Current;
                    index--;
                }
            }
        }

        public static T ElementAtOrDefault<T>(this IEnumerable<T> source, int index) {
            if (index >= 0) {
                IList<T> list = source as IList<T>;
                if (list != null) {
                    if (index < list.Count) return list[index];
                }
                else {
                    using (IEnumerator<T> e = source.GetEnumerator()) {
                        while (true) {
                            if (!e.MoveNext()) break;
                            if (index == 0) return e.Current;
                            index--;
                        }
                    }
                }
            }
            return default(T);
        }

        public static IEnumerable<int> Range(int start, int count) {
            if (count < 0) throw Error.ArgumentOutOfRange("count");
            for (int i = 0; i < count; i++) yield return start + i;
        }

        public static IEnumerable<T> Repeat<T>(T element, int count) {
            if (count < 0) throw Error.ArgumentOutOfRange("count");
            for (int i = 0; i < count; i++) yield return element;
        }

        public static IEnumerable<T> Empty<T>() {
            return EmptySequence<T>.Instance;
        }

        public static bool Any<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            foreach (T element in source) {
                return true;
            }
            return false;
        }

        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            foreach (T element in source) {
                if (predicate(element)) return true;
            }
            return false;
        }

        public static bool All<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            foreach (T element in source) {
                if (!predicate(element)) return false;
            }
            return true;
        }

        public static int Count<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            ICollection<T> collection = source as ICollection<T>;
            if (collection != null) return collection.Count;
            int count = 0;
            using (IEnumerator<T> e = source.GetEnumerator()) {
                checked {
                    while (e.MoveNext()) count++;
                }
            }
            return count;
        }

        public static int Count<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            int count = 0;
            foreach (T element in source) {
                checked {
                    if (predicate(element)) count++;
                }
            }
            return count;
        }

        public static long LongCount<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            long count = 0;
            using (IEnumerator<T> e = source.GetEnumerator()) {
                while (e.MoveNext()) count++;
            }
            return count;
        }

        public static long LongCount<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null) throw Error.ArgumentNull("source");
            if (predicate == null) throw Error.ArgumentNull("predicate");
            long count = 0;
            foreach (T element in source) {
                checked {
                    if (predicate(element)) count++;
                }
            }
            return count;
        }

        public static bool Contains<T>(this IEnumerable<T> source, T value) {
            if (source == null) throw Error.ArgumentNull("source");
            ICollection<T> collection = source as ICollection<T>;
            if (collection != null) return collection.Contains(value);
            if (value == null) {
                foreach (T element in source)
                    if (element == null) return true;
            }
            else {
                EqualityComparer<T> c = EqualityComparer<T>.Default;
                foreach (T element in source)
                    if (c.Equals(element, value)) return true;
            }
            return false;
        }

        [Obsolete("Use Aggregate(...) instead")]
        public static T Fold<T>(this IEnumerable<T> source, Func<T, T, T> func) {
            return Sequence.Aggregate(source, func);
        }

        [Obsolete("Use Aggregate(...) instead")]
        public static U Fold<T, U>(this IEnumerable<T> source, U seed, Func<U, T, U> func) {
            return Sequence.Aggregate(source, seed, func);
        }

        public static T Aggregate<T>(this IEnumerable<T> source, Func<T, T, T> func) {
            if (source == null) throw Error.ArgumentNull("source");
            if (func == null) throw Error.ArgumentNull("func");
            using (IEnumerator<T> e = source.GetEnumerator()) {
                if (!e.MoveNext()) throw Error.NoElements();
                T result = e.Current;
                while (e.MoveNext()) result = func(result, e.Current);
                return result;
            }
        }

        public static U Aggregate<T, U>(this IEnumerable<T> source, U seed, Func<U, T, U> func) {
            if (source == null) throw Error.ArgumentNull("source");
            if (func == null) throw Error.ArgumentNull("func");
            U result = seed;
            foreach (T element in source) result = func(result, element);
            return result;
        }

        public static V Aggregate<T, U, V>(this IEnumerable<T> source, U seed, Func<U, T, U> func, Func<U, V> resultSelector) {
            if (source == null) throw Error.ArgumentNull("source");
            if (func == null) throw Error.ArgumentNull("func");
            if (resultSelector == null) throw Error.ArgumentNull("resultSelector");
            U result = seed;
            foreach (T element in source) result = func(result, element);
            return resultSelector(result);
        }

        public static int Sum(this IEnumerable<int> source) {
            if (source == null) throw Error.ArgumentNull("source");
            int sum = 0;
            checked {
                foreach (int v in source) sum += v;
            }
            return sum;
        }

        public static int? Sum(this IEnumerable<int?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            int? sum = 0;
            checked {
                foreach (int? v in source) {
                    if (v != null) sum += v;
                }
            }
            return sum;
        }

        public static long Sum(this IEnumerable<long> source) {
            if (source == null) throw Error.ArgumentNull("source");
            long sum = 0;
            checked {
                foreach (long v in source) sum += v;
            }
            return sum;
        }

        public static long? Sum(this IEnumerable<long?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            long? sum = 0;
            checked {
                foreach (long? v in source) {
                    if (v != null) sum += v;
                }
            }
            return sum;
        }

        public static double Sum(this IEnumerable<double> source) {
            if (source == null) throw Error.ArgumentNull("source");
            double sum = 0;
            foreach (double v in source) sum += v;
            return sum;
        }

        public static double? Sum(this IEnumerable<double?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            double? sum = 0;
            foreach (double? v in source) {
                if (v != null) sum += v;
            }
            return sum;
        }

        public static decimal Sum(this IEnumerable<decimal> source) {
            if (source == null) throw Error.ArgumentNull("source");
            decimal sum = 0;
            foreach (decimal v in source) sum += v;
            return sum;
        }

        public static decimal? Sum(this IEnumerable<decimal?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            decimal? sum = 0;
            foreach (decimal? v in source) {
                if (v != null) sum += v;
            }
            return sum;
        }

        public static int Sum<T>(this IEnumerable<T> source, Func<T, int> selector) {
            return Sequence.Sum(Sequence.Select(source, selector));
        }

        public static int? Sum<T>(this IEnumerable<T> source, Func<T, int?> selector) {
            return Sequence.Sum(Sequence.Select(source, selector));
        }

        public static double Sum<T>(this IEnumerable<T> source, Func<T, double> selector) {
            return Sequence.Sum(Sequence.Select(source, selector));
        }

        public static double? Sum<T>(this IEnumerable<T> source, Func<T, double?> selector) {
            return Sequence.Sum(Sequence.Select(source, selector));
        }

        public static long Sum<T>(this IEnumerable<T> source, Func<T, long> selector) {
            return Sequence.Sum(Sequence.Select(source, selector));
        }

        public static long? Sum<T>(this IEnumerable<T> source, Func<T, long?> selector) {
            return Sequence.Sum(Sequence.Select(source, selector));
        }

        public static decimal Sum<T>(this IEnumerable<T> source, Func<T, decimal> selector) {
            return Sequence.Sum(Sequence.Select(source, selector));
        }

        public static decimal? Sum<T>(this IEnumerable<T> source, Func<T, decimal?> selector) {
            return Sequence.Sum(Sequence.Select(source, selector));
        }

        public static int Min(this IEnumerable<int> source) {
            if (source == null) throw Error.ArgumentNull("source");
            int value = 0;
            bool hasValue = false;
            foreach (int x in source) {
                if (hasValue) {
                    if (x < value) value = x;
                }
                else {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw Error.NoElements();
        }

        public static int? Min(this IEnumerable<int?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            int? value = null;
            foreach (int? x in source) {
                if (value == null || x < value) value = x;
            }
            return value;
        }

        public static long Min(this IEnumerable<long> source) {
            if (source == null) throw Error.ArgumentNull("source");
            long value = 0;
            bool hasValue = false;
            foreach (long x in source) {
                if (hasValue) {
                    if (x < value) value = x;
                }
                else {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw Error.NoElements();
        }

        public static long? Min(this IEnumerable<long?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            long? value = null;
            foreach (long? x in source) {
                if (value == null || x < value) value = x;
            }
            return value;
        }

        public static double Min(this IEnumerable<double> source) {
            if (source == null) throw Error.ArgumentNull("source");
            double value = 0;
            bool hasValue = false;
            foreach (double x in source) {
                if (hasValue) {
                    if (x < value) value = x;
                }
                else {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw Error.NoElements();
        }

        public static double? Min(this IEnumerable<double?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            double? value = null;
            foreach (double? x in source) {
                if (value == null || x < value) value = x;
            }
            return value;
        }

        public static decimal Min(this IEnumerable<decimal> source) {
            if (source == null) throw Error.ArgumentNull("source");
            decimal value = 0;
            bool hasValue = false;
            foreach (decimal x in source) {
                if (hasValue) {
                    if (x < value) value = x;
                }
                else {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw Error.NoElements();
        }

        public static decimal? Min(this IEnumerable<decimal?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            decimal? value = null;
            foreach (decimal? x in source) {
                if (value == null || x < value) value = x;
            }
            return value;
        }

        public static T Min<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            Comparer<T> comparer = Comparer<T>.Default;
            T value = default(T);
            bool hasValue = false;
            foreach (T x in source) {
                if (hasValue) {
                    if (comparer.Compare(x, value) < 0)
                        value = x;
                }
                else {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw Error.NoElements();
        }

        public static int Min<T>(this IEnumerable<T> source, Func<T, int> selector) {
            return Sequence.Min(Sequence.Select(source, selector));
        }

        public static int? Min<T>(this IEnumerable<T> source, Func<T, int?> selector) {
            return Sequence.Min(Sequence.Select(source, selector));
        }

        public static long Min<T>(this IEnumerable<T> source, Func<T, long> selector) {
            return Sequence.Min(Sequence.Select(source, selector));
        }

        public static long? Min<T>(this IEnumerable<T> source, Func<T, long?> selector) {
            return Sequence.Min(Sequence.Select(source, selector));
        }

        public static double Min<T>(this IEnumerable<T> source, Func<T, double> selector) {
            return Sequence.Min(Sequence.Select(source, selector));
        }

        public static double? Min<T>(this IEnumerable<T> source, Func<T, double?> selector) {
            return Sequence.Min(Sequence.Select(source, selector));
        }

        public static decimal Min<T>(this IEnumerable<T> source, Func<T, decimal> selector) {
            return Sequence.Min(Sequence.Select(source, selector));
        }

        public static decimal? Min<T>(this IEnumerable<T> source, Func<T, decimal?> selector) {
            return Sequence.Min(Sequence.Select(source, selector));
        }

        public static S Min<T, S>(this IEnumerable<T> source, Func<T, S> selector) {
            return Sequence.Min(Sequence.Select(source, selector));
        }

        public static int Max(this IEnumerable<int> source) {
            if (source == null) throw Error.ArgumentNull("source");
            int value = 0;
            bool hasValue = false;
            foreach (int x in source) {
                if (hasValue) {
                    if (x > value) value = x;
                }
                else {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw Error.NoElements();
        }

        public static int? Max(this IEnumerable<int?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            int? value = null;
            foreach (int? x in source) {
                if (value == null || x > value) value = x;
            }
            return value;
        }

        public static long Max(this IEnumerable<long> source) {
            if (source == null) throw Error.ArgumentNull("source");
            long value = 0;
            bool hasValue = false;
            foreach (long x in source) {
                if (hasValue) {
                    if (x > value) value = x;
                }
                else {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw Error.NoElements();
        }

        public static long? Max(this IEnumerable<long?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            long? value = null;
            foreach (long? x in source) {
                if (value == null || x > value) value = x;
            }
            return value;
        }

        public static double Max(this IEnumerable<double> source) {
            if (source == null) throw Error.ArgumentNull("source");
            double value = 0;
            bool hasValue = false;
            foreach (double x in source) {
                if (hasValue) {
                    if (x > value) value = x;
                }
                else {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw Error.NoElements();
        }

        public static double? Max(this IEnumerable<double?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            double? value = null;
            foreach (double? x in source) {
                if (value == null || x > value) value = x;
            }
            return value;
        }

        public static decimal Max(this IEnumerable<decimal> source) {
            if (source == null) throw Error.ArgumentNull("source");
            decimal value = 0;
            bool hasValue = false;
            foreach (decimal x in source) {
                if (hasValue) {
                    if (x > value) value = x;
                }
                else {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw Error.NoElements();
        }

        public static decimal? Max(this IEnumerable<decimal?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            decimal? value = null;
            foreach (decimal? x in source) {
                if (value == null || x > value) value = x;
            }
            return value;
        }

        public static T Max<T>(this IEnumerable<T> source) {
            if (source == null) throw Error.ArgumentNull("source");
            Comparer<T> comparer = Comparer<T>.Default;
            T value = default(T);
            bool hasValue = false;
            foreach (T x in source) {
                if (hasValue) {
                    if (comparer.Compare(x, value) > 0) 
                        value = x;
                }
                else {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw Error.NoElements();
        }

        public static int Max<T>(this IEnumerable<T> source, Func<T, int> selector) {
            return Sequence.Max(Sequence.Select(source, selector));
        }

        public static int? Max<T>(this IEnumerable<T> source, Func<T, int?> selector) {
            return Sequence.Max(Sequence.Select(source, selector));
        }

        public static long Max<T>(this IEnumerable<T> source, Func<T, long> selector) {
            return Sequence.Max(Sequence.Select(source, selector));
        }

        public static long? Max<T>(this IEnumerable<T> source, Func<T, long?> selector) {
            return Sequence.Max(Sequence.Select(source, selector));
        }

        public static double Max<T>(this IEnumerable<T> source, Func<T, double> selector) {
            return Sequence.Max(Sequence.Select(source, selector));
        }

        public static double? Max<T>(this IEnumerable<T> source, Func<T, double?> selector) {
            return Sequence.Max(Sequence.Select(source, selector));
        }

        public static decimal Max<T>(this IEnumerable<T> source, Func<T, decimal> selector) {
            return Sequence.Max(Sequence.Select(source, selector));
        }

        public static decimal? Max<T>(this IEnumerable<T> source, Func<T, decimal?> selector) {
            return Sequence.Max(Sequence.Select(source, selector));
        }

        public static S Max<T, S>(this IEnumerable<T> source, Func<T, S> selector) {
            return Sequence.Max(Sequence.Select(source, selector));
        }

        public static double Average(this IEnumerable<int> source) {
            if (source == null) throw Error.ArgumentNull("source");
            long sum = 0;
            long count = 0;
            checked {
                foreach (int v in source) {
                    sum += v;
                    count++;
                }
            }
            if (count > 0) return (double)sum / count;
            throw Error.NoElements();
        }

        public static double? Average(this IEnumerable<int?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            long sum = 0;
            long count = 0;
            checked {
                foreach (int? v in source) {
                    if (v != null) {
                        sum += v.GetValueOrDefault();
                        count++;
                    }
                }
            }
            if (count > 0) return (double)sum / count;
            return null;
        }

        public static double Average(this IEnumerable<long> source) {
            if (source == null) throw Error.ArgumentNull("source");
            long sum = 0;
            long count = 0;
            checked {
                foreach (long v in source) {
                    sum += v;
                    count++;
                }
            }
            if (count > 0) return (double)sum / count;
            throw Error.NoElements();
        }

        public static double? Average(this IEnumerable<long?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            long sum = 0;
            long count = 0;
            checked {
                foreach (long? v in source) {
                    if (v != null) {
                        sum += v.GetValueOrDefault();
                        count++;
                    }
                }
            }
            if (count > 0) return (double)sum / count;
            return null;
        }

        public static double Average(this IEnumerable<double> source) {
            if (source == null) throw Error.ArgumentNull("source");
            double sum = 0;
            long count = 0;
            checked {
                foreach (double v in source) {
                    sum += v;
                    count++;
                }
            }
            if (count > 0) return sum / count;
            throw Error.NoElements();
        }

        public static double? Average(this IEnumerable<double?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            double sum = 0;
            long count = 0;
            checked {
                foreach (double? v in source) {
                    if (v != null) {
                        sum += v.GetValueOrDefault();
                        count++;
                    }
                }
            }
            if (count > 0) return sum / count;
            return null;
        }

        public static decimal Average(this IEnumerable<decimal> source) {
            if (source == null) throw Error.ArgumentNull("source");
            decimal sum = 0;
            long count = 0;
            checked {
                foreach (decimal v in source) {
                    sum += v;
                    count++;
                }
            }
            if (count > 0) return sum / count;
            throw Error.NoElements();
        }

        public static decimal? Average(this IEnumerable<decimal?> source) {
            if (source == null) throw Error.ArgumentNull("source");
            decimal sum = 0;
            long count = 0;
            checked {
                foreach (decimal? v in source) {
                    if (v != null) {
                        sum += v.GetValueOrDefault();
                        count++;
                    }
                }
            }
            if (count > 0) return sum / count;
            return null;
        }

        public static double Average<T>(this IEnumerable<T> source, Func<T, int> selector) {
            return Sequence.Average(Sequence.Select(source, selector));
        }

        public static double? Average<T>(this IEnumerable<T> source, Func<T, int?> selector) {
            return Sequence.Average(Sequence.Select(source, selector));
        }

        public static double Average<T>(this IEnumerable<T> source, Func<T, long> selector) {
            return Sequence.Average(Sequence.Select(source, selector));
        }

        public static double? Average<T>(this IEnumerable<T> source, Func<T, long?> selector) {
            return Sequence.Average(Sequence.Select(source, selector));
        }

        public static double Average<T>(this IEnumerable<T> source, Func<T, double> selector) {
            return Sequence.Average(Sequence.Select(source, selector));
        }

        public static double? Average<T>(this IEnumerable<T> source, Func<T, double?> selector) {
            return Sequence.Average(Sequence.Select(source, selector));
        }

        public static decimal Average<T>(this IEnumerable<T> source, Func<T, decimal> selector) {
            return Sequence.Average(Sequence.Select(source, selector));
        }

        public static decimal? Average<T>(this IEnumerable<T> source, Func<T, decimal?> selector) {
            return Sequence.Average(Sequence.Select(source, selector));
        }
    }

    internal class EmptySequence<T>
    {
        static T[] instance;

        public static IEnumerable<T> Instance {
            get {
                if (instance == null) instance = new T[0];
                return instance;
            }
        }
    }

    internal class IdentityFunction<T>
    {
        public static Func<T, T> Instance {
            get { return x => x; }
        }
    }

    public interface IGrouping<K, T>: IEnumerable<T>
    {
        K Key { get; }
    }

    public class Lookup<K, T> : IEnumerable<IGrouping<K, T>>
    {
        IEqualityComparer<K> comparer;
        Grouping[] groupings;
        Grouping lastGrouping;
        int count;

        internal static Lookup<K, T> Create<S>(IEnumerable<S> source, Func<S, K> keySelector, Func<S, T> elementSelector, IEqualityComparer<K> comparer) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            if (elementSelector == null) throw Error.ArgumentNull("elementSelector");
            Lookup<K, T> lookup = new Lookup<K, T>(comparer);
            foreach (S item in source) {
                lookup.GetGrouping(keySelector(item), true).Add(elementSelector(item));
            }
            return lookup;
        }

        Lookup(IEqualityComparer<K> comparer) {
            if (comparer == null) comparer = EqualityComparer<K>.Default;
            this.comparer = comparer;
            groupings = new Grouping[7];
        }

        public int Count {
            get { return count; }
        }

        public IEnumerable<T> this[K key] {
            get {
                Grouping grouping = GetGrouping(key, false);
                if (grouping != null) return grouping;
                return EmptySequence<T>.Instance;
            }
        }

        public bool Contains(K key) {
            return GetGrouping(key, false) != null;
        }

        public IEnumerator<IGrouping<K, T>> GetEnumerator() {
            Grouping g = lastGrouping;
            if (g != null) {
                do {
                    g = g.next;
                    yield return g;
                } while (g != lastGrouping);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        internal Grouping GetGrouping(K key, bool create) {
            int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
            for (Grouping g = groupings[hashCode % groupings.Length]; g != null; g = g.hashNext)
                if (g.hashCode == hashCode && comparer.Equals(g.key, key)) return g;
            if (create) {
                if (count == groupings.Length) Resize();
                int index = hashCode % groupings.Length;
                Grouping g = new Grouping();
                g.key = key;
                g.hashCode = hashCode;
                g.elements = new T[1];
                g.hashNext = groupings[index];
                groupings[index] = g;
                if (lastGrouping == null) {
                    g.next = g;
                }
                else {
                    g.next = lastGrouping.next;
                    lastGrouping.next = g;
                }
                lastGrouping = g;
                count++;
                return g;
            }
            return null;
        }

        void Resize() {
            int newSize = count * 2 + 1;
            Grouping[] newGroupings = new Grouping[newSize];
            Grouping g = lastGrouping;
            do {
                g = g.next;
                int index = g.hashCode % newSize;
                g.hashNext = newGroupings[index];
                newGroupings[index] = g;
            } while (g != lastGrouping);
            groupings = newGroupings;
        }

        internal class Grouping: IGrouping<K, T>, IList<T>
        {
            internal K key;
            internal int hashCode;
            internal T[] elements;
            internal int count;
            internal Grouping hashNext;
            internal Grouping next;

            internal void Add(T element) {
                if (elements.Length == count) Array.Resize(ref elements, count * 2);
                elements[count++] = element;
            }

            public IEnumerator<T> GetEnumerator() {
                for (int i = 0; i < count; i++) yield return elements[i];
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }

            K IGrouping<K, T>.Key {
                get { return key; }
            }

            int ICollection<T>.Count {
                get { return count; }
            }

            bool ICollection<T>.IsReadOnly {
                get { return true; }
            }

            void ICollection<T>.Add(T item) {
                throw Error.NotSupported();
            }

            void ICollection<T>.Clear() {
                throw Error.NotSupported();
            }

            bool ICollection<T>.Contains(T item) {
                return Array.IndexOf(elements, item, 0, count) >= 0;
            }

            void ICollection<T>.CopyTo(T[] array, int arrayIndex) {
                Array.Copy(elements, 0, array, arrayIndex, count);
            }

            bool ICollection<T>.Remove(T item) {
                throw Error.NotSupported();
            }

            int IList<T>.IndexOf(T item) {
                return Array.IndexOf(elements, item, 0, count);
            }

            void IList<T>.Insert(int index, T item) {
                throw Error.NotSupported();
            }

            void IList<T>.RemoveAt(int index) {
                throw Error.NotSupported();
            }

            T IList<T>.this[int index] {
                get {
                    if (index < 0 || index >= count) throw Error.ArgumentOutOfRange("index");
                    return elements[index];
                }
                set {
                    throw Error.NotSupported();
                }
            }
        }
    }

    internal class GroupedSequence<T, K, E> : IEnumerable<IGrouping<K, E>>
    {
        IEnumerable<T> source;
        Func<T, K> keySelector;
        Func<T, E> elementSelector;
        IEqualityComparer<K> comparer;

        public GroupedSequence(IEnumerable<T> source, Func<T, K> keySelector, Func<T, E> elementSelector, IEqualityComparer<K> comparer) {
            this.source = source;
            this.keySelector = keySelector;
            this.elementSelector = elementSelector;
            this.comparer = comparer;
        }

        public IEnumerator<IGrouping<K, E>> GetEnumerator() {
            return Lookup<K, E>.Create<T>(source, keySelector, elementSelector, comparer).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }

    public abstract class OrderedSequence<T> : IEnumerable<T>
    {
        internal IEnumerable<T> source;

        public IEnumerator<T> GetEnumerator() {
            Buffer<T> buffer = new Buffer<T>(source);
            if (buffer.count > 0) {
                SequenceSorter<T> sorter = GetSequenceSorter(null);
                int[] map = sorter.Sort(buffer.items, buffer.count);
                sorter = null;
                for (int i = 0; i < buffer.count; i++) yield return buffer.items[map[i]];
            }
        }

        internal virtual SequenceSorter<T> GetSequenceSorter(SequenceSorter<T> next) {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }

    internal class OrderedSequence<T, K> : OrderedSequence<T>
    {
        internal OrderedSequence<T> parent;
        internal Func<T, K> keySelector;
        internal IComparer<K> comparer;
        internal bool descending;

        internal OrderedSequence(IEnumerable<T> source, Func<T, K> keySelector, IComparer<K> comparer, bool descending) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            this.source = source;
            this.parent = null;
            this.keySelector = keySelector;
            this.comparer = comparer != null ? comparer : Comparer<K>.Default;
            this.descending = descending;
        }

        internal OrderedSequence(OrderedSequence<T> source, Func<T, K> keySelector, IComparer<K> comparer, bool descending) {
            if (source == null) throw Error.ArgumentNull("source");
            if (keySelector == null) throw Error.ArgumentNull("keySelector");
            this.source = source.source;
            this.parent = source;
            this.keySelector = keySelector;
            this.comparer = comparer != null ? comparer : Comparer<K>.Default;
            this.descending = descending;
        }

        internal override SequenceSorter<T> GetSequenceSorter(SequenceSorter<T> next) {
            SequenceSorter<T> sorter = new SequenceSorter<T, K>(keySelector, comparer, descending, next);
            if (parent != null) sorter = parent.GetSequenceSorter(sorter);
            return sorter;
        }
    }

    internal abstract class SequenceSorter<T>
    {
        internal abstract void ComputeKeys(T[] elements, int count);

        internal abstract int CompareKeys(int index1, int index2);

        internal int[] Sort(T[] elements, int count) {
            ComputeKeys(elements, count);
            int[] map = new int[count];
            for (int i = 0; i < count; i++) map[i] = i;
            QuickSort(map, 0, count - 1);
            return map;
        }

        void QuickSort(int[] map, int left, int right) {
            do {
                int i = left;
                int j = right;
                int x = map[i + ((j - i) >> 1)];
                do {
                    while (CompareKeys(x, map[i]) > 0) i++;
                    while (CompareKeys(x, map[j]) < 0) j--;
                    if (i > j) break;
                    if (i < j) {
                        int temp = map[i];
                        map[i] = map[j];
                        map[j] = temp;
                    }
                    i++;
                    j--;
                } while (i <= j);
                if (j - left <= right - i) {
                    if (left < j) QuickSort(map, left, j);
                    left = i;
                }
                else {
                    if (i < right) QuickSort(map, i, right);
                    right = j;
                }
            } while (left < right);
        }
    }

    internal class SequenceSorter<T, K> : SequenceSorter<T>
    {
        internal Func<T, K> keySelector;
        internal IComparer<K> comparer;
        internal bool descending;
        internal SequenceSorter<T> next;
        internal K[] keys;

        internal SequenceSorter(Func<T, K> keySelector, IComparer<K> comparer, bool descending, SequenceSorter<T> next) {
            this.keySelector = keySelector;
            this.comparer = comparer;
            this.descending = descending;
            this.next = next;
        }

        internal override void ComputeKeys(T[] elements, int count) {
            keys = new K[count];
            for (int i = 0; i < count; i++) keys[i] = keySelector(elements[i]);
            if (next != null) next.ComputeKeys(elements, count);
        }

        internal override int CompareKeys(int index1, int index2) {
            int c = comparer.Compare(keys[index1], keys[index2]);
            if (c == 0 && next != null) return next.CompareKeys(index1, index2);
            return descending ? -c : c;
        }
    }

    struct Buffer<T>
    {
        internal T[] items;
        internal int count;

        internal Buffer(IEnumerable<T> source) {
            T[] items = null;
            int count = 0;
            ICollection<T> collection = source as ICollection<T>;
            if (collection != null) {
                count = collection.Count;
                if (count > 0) {
                    items = new T[count];
                    collection.CopyTo(items, 0);
                }
            }
            else {
                foreach (T item in source) {
                    if (items == null) {
                        items = new T[4];
                    }
                    else if (items.Length == count) {
                        T[] newItems = new T[count * 2];
                        Array.Copy(items, 0, newItems, 0, count);
                        items = newItems;
                    }
                    items[count++] = item;
                }
            }
            this.items = items;
            this.count = count;
        }

        internal T[] ToArray() {
            if (count == 0) return new T[0];
            if (items.Length == count) return items;
            T[] result = new T[count];
            Array.Copy(items, 0, result, 0, count);
            return result;
        }
    }

    class Error
    {
        internal static Exception ArgumentNull(string paramName) {
            return new ArgumentNullException(paramName);
        }

        internal static Exception ArgumentOutOfRange(string paramName) {
            return new ArgumentOutOfRangeException(paramName);
        }

        internal static Exception NoElements() {
            return new InvalidOperationException("Sequence contains no elements");
        }

        internal static Exception NoMatch() {
            return new InvalidOperationException("Sequence contains no matching element");
        }

        internal static Exception MoreThanOneElement() {
            return new InvalidOperationException("Sequence contains more than one element");
        }

        internal static Exception MoreThanOneMatch() {
            return new InvalidOperationException("Sequence contains more than one matching element");
        }

        internal static Exception NotSupported() {
            return new NotSupportedException();
        }
    }
}
