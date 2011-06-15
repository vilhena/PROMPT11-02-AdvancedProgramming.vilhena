using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Mod02_AdvProgramming.ImageGallery
{
    class DirectoryEnumerator
    {
        public static IEnumerable<FileInfo> GetDirectoryEnumeratorEager(DirectoryInfo directoryInfo)
        {
            var list = new List<FileInfo>();
            foreach (var fileInfo in directoryInfo.GetFiles("*.jpg"))
            {

            }
            return list;
        }

        public static IEnumerable<FileInfo> GetDirectoryEnumeratorLazy(DirectoryInfo directoryInfo)
        {
            return null;
        }
    }
}
