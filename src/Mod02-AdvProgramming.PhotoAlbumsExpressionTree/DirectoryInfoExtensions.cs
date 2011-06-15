using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Mod02_AdvProgramming.PhotoAlbums
{
    public static class DirectoryInfoExtensions
    {

        public static bool Abafator<T>(this T di, Action<T> test)
        {
            var can = false;
            try
            {
                test(di);
                can = true;
            }
            catch (Exception)
            {

            }

            return can;
        }


        public static IEnumerable<DirectoryInfo> CanAccess(this IEnumerable<DirectoryInfo> di)
        {
            foreach (var directoryInfo in di)
            {
                if (directoryInfo.Abafator(s=>
                                                {
                                                    var time = s.EnumerateFiles();
                                                    time.GetEnumerator().MoveNext();
                                                }))
                    yield return directoryInfo;
            }
        }

        public static IEnumerable<FileInfo> CanAccess(this IEnumerable<FileInfo> fi)
        {
            foreach (var fileInfo in fi)
            {
                if (fileInfo.Abafator(s =>
                {
                    var time = s.CreationTime;
                }))
                    yield return fileInfo;
            }
        }

        

        public static string ListToString<T>(this IEnumerable<T> seq, Func<T, string> func)
        {
            var sb = new StringBuilder();
            foreach (var item in seq)
            {
                sb.Append(func(item));
            }
            return sb.ToString();
        }

        public static IEnumerable<T> WhereExistsOn<T,U>(this IEnumerable<T> origin, IEnumerable<U> dest, Func<T,U,bool> pred)
        {
            foreach (var item in origin)
            {
                foreach (var u in dest)
                {
                    if (pred(item, u))
                        yield return item;
                }
            }
        }

        public static IEnumerable<T> WhereExistsOnExpression<T, U>(this IEnumerable<T> origin, IEnumerable<U> dest, Expression<Func<T, U, bool>> predExpression)
        {
            var pred = GetOrExpression(predExpression, dest);

            foreach (var item in origin)
            {
                foreach (var u in dest)
                {
                    if (pred(item, u))
                        yield return item;
                }
            }
        }

        private static Func<T, U, bool> GetOrExpression<T, U>(Expression<Func<T, U, bool>> predExpression, IEnumerable<U> objects)
        {
            //var result = new Expression<Func<T, U, bool>>();

            //foreach (var o in objects)
            //{
            //    var visitor = ExpressionVisitor.Visit();

            //}

            return predExpression.Compile();
        }

    }
}
