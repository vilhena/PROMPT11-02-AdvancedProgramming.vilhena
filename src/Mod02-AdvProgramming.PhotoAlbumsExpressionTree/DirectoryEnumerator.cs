// -----------------------------------------------------------------------
// <copyright file="DirectoryEnumerator.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using System.Linq;
using System.Text;

namespace Mod02_AdvProgramming.PhotoAlbums
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class DirectoryEnumerator
    {

        public static IEnumerable<FileInfo> GetDirectoryEnumeratorEager(DirectoryInfo di)
        {
            var retList = new List<FileInfo>();
            
            
            retList.AddRange(di.GetFiles());
            

            foreach (var directoryInfo in di.GetDirectories())
            {
                var canAccess = false; 
                try
                {
                    var x = directoryInfo.GetFiles();
                    canAccess = true;
                }
                catch
                {

                }

                if (canAccess)
                    retList.AddRange(GetDirectoryEnumeratorEager(directoryInfo));
            }
            return retList;
        }
        

        public static IEnumerable<FileInfo> GetDirectoryEnumeratorLazy(DirectoryInfo di)
        {

            return di.EnumerateFiles()
                //.CanAccess()
                .Concat(di.EnumerateDirectories()
                            .CanAccess()
                            .SelectMany(GetDirectoryEnumeratorLazy)
                );

            //// For current directory
            //foreach (var fileInfo in di.GetFiles())
            //{
            //    yield return  fileInfo;
            //}

            //foreach (var directoryInfo in di.GetDirectories())
            //{
            //    #region Martelo
            //    var canAccess = false;
            //    try
            //    {
            //        var x = directoryInfo.GetFiles();
            //        canAccess = true;
            //    }
            //    catch
            //    {

            //    } 
            //    #endregion

            //    if (canAccess)
            //    {
            //        foreach (var subFileInfo in GetDirectoryEnumeratorLazy(directoryInfo))
            //        {
            //            yield return subFileInfo;
            //        }
            //    }
            //}
        }

        public static IEnumerable<FileInfo> GetDirectoryEnumerator(DirectoryInfo di)
        {
            return GetDirectoryEnumeratorLazy(di);
        }

        public static IEnumerable<string> GetDirectoryImagesFilenames(this DirectoryInfo di, IEnumerable<string> files)
        {
            return GetDirectoryEnumerator(di)
                .WhereExistsOn(files, (s, u) => s.Extension == u)
                .Select(r => r.FullName);
        }



    }
}
