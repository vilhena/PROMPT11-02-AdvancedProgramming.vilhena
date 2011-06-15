using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Ader.Text;

namespace Mod02_AdvProgramming.PhotoAlbums
{
    public class ImagesSequence : IEnumerable<FileInfo>
    {
        public string Path { get; set; }
        private readonly List<string> _files = new List<string>() {".jpg", ".gif", ".png"};

        public ImagesSequence(string path)
        {
            Path = path;
        }

        public IEnumerator<FileInfo> GetEnumerator()
        {
            var di = new DirectoryInfo(this.Path);

            return DirectoryEnumerator.GetDirectoryEnumerator(di)
                .WhereExistsOn(_files, (s, u) => s.Extension == u).GetEnumerator();
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class ImagesSequenceExtension
    {
        public static IEnumerable<FileInfo> Where(this IEnumerable<FileInfo> seq, string pred)
        {
            var tokenizer = new StringTokenizer(pred);

            

            var member = tokenizer.Next();
            var op = tokenizer.Next();
            var value = tokenizer.Next();

            //if(member.Kind == TokenKind.Word)
                var param = Expression.Parameter(typeof (FileInfo));


            var prop = Expression.MakeMemberAccess(param, typeof (FileInfo).GetProperty(member.Value));
            
            //if(value.Kind == TokenKind.Number)
                var constant = Expression.Constant(Convert.ToInt64(value.Value));

            var bin = Expression.MakeBinary(ExpressionType.GreaterThan, prop, constant);

            var lb = Expression.Lambda(bin, true, param);

            var runner = lb.Compile();

            

            //foreach (var fileInfo in seq)
            //{
            //    if ((bool)runner.DynamicInvoke(new object[] { fileInfo }))
            //        yield return fileInfo;
            //}
            

            return seq.Where((Func<FileInfo, bool>) runner);
        }
    }
}
