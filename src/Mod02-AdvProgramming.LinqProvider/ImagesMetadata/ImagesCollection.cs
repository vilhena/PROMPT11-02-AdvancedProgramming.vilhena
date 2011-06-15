namespace Mod02_AdvProgramming.LinqProvider.ImagesMetadata
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ImagesCollection
    {
        internal ImageService ImagesService { get; set; } 

        public static IEnumerable<FileInfo> GetDirectoryEnumerator(DirectoryInfo rootDir)
        {
            return rootDir.EnumerateFiles().Concat(rootDir.EnumerateDirectories().SelectMany(dir => GetDirectoryEnumerator(dir)));
        }

        public static IEnumerable<string> GetDirectoryImages(DirectoryInfo di)
        {
            return GetDirectoryEnumerator(di).Where(fi => fi.Extension == ".jpg" || fi.Extension == ".gif").Select(fi => fi.FullName);
        }

        
    }
}