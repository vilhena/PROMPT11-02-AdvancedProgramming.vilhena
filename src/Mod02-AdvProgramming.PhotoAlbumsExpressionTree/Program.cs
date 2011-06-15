﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;
using Ader.Text;

namespace Mod02_AdvProgramming.PhotoAlbums
{
    class Program
    {
        static void Main(string[] args)
        {

            // Listing c:\windows desdendant files in as eager way
            //foreach (FileInfo fileInfo in DirectoryEnumerator.GetDirectoryEnumeratorEager(new DirectoryInfo("c:\\windows")))
            //{
            //    Console.WriteLine(fileInfo.FullName);
            //}

            // Listing c:\windows desdendant files in as lazy way
            //foreach (FileInfo fileInfo in DirectoryEnumerator.GetDirectoryEnumeratorLazy(new DirectoryInfo("c:\\windows")))
            //{
            //    Console.WriteLine(fileInfo.FullName);
            //}

            // Listing c:\windows desdendant files with an extension method for DirectoryInfo
            //foreach (FileInfo fileInfo in new DirectoryInfo("c:\\windows").GetDirectoryEnumerator())
            //{
            //    Console.WriteLine(fileInfo.FullName);
            //}

            //foreach (var directoryImage in new DirectoryInfo(@"c:\windows").GetDirectoryImages())
            //{
            //    Console.WriteLine(directoryImage);
            //}
            //var i = 0;
            //foreach (var imageHtml in new DirectoryInfo(@"c:\windows").GetDirectoryImages().Select(
            //    img => new XElement("a"
            //        , new XAttribute("href", img)
            //        , new XAttribute("rel", "lightbox-photos")
            //        , new XAttribute("title", "Figure02" + i++))))
            //{
            //    Console.WriteLine(imageHtml);
            //}

            //File.WriteAllText("output.html",

            //                  String.Format(ResourceTemplate.example, "Galeria Vilhena",
            //                                new DirectoryInfo(@"c:\windows")
            //                                    .GetDirectoryImagesFilenames(new List<string>(){".jpg",".gif",".png"})
            //                                    .Select(
            //                                        img => new XElement("a"
            //                                                            , new XAttribute("href", img)
            //                                                            , new XAttribute("rel", "lightbox-photos")
            //                                                            , new XAttribute("title"
            //                                                                             , "Figure" + ++i)
            //                                                            , new XElement("img",
            //                                                                           new XAttribute("src", img))))
            //                                    .ListToString(xml => xml.ToString() + Environment.NewLine)));



            //var tokenizer = new StringTokenizer("Length>1000>1000");

            

            //var member = tokenizer.Next();
            //var op = tokenizer.Next();
            //var value = tokenizer.Next();

            ////if(member.Kind == TokenKind.Word)
            //var param = Expression.Parameter(typeof (FileInfo));
            //var prop = Expression.MakeMemberAccess(param, typeof (FileInfo).GetProperty(member.Value));
            
            ////if(value.Kind == TokenKind.Number)
            //    var constant = Expression.Constant(Convert.ToInt64(value.Value));

            //var bin = Expression.MakeBinary(ExpressionType.GreaterThan, prop, constant);

            //var lb = Expression.Lambda(bin, true, param);

            //lb.Compile().DynamicInvoke()

            //Console.WriteLine(lb.ToString());

            ImagesSequence im = new ImagesSequence(@"c:\windows");

            foreach (var image in im.Where("Length>1000"))
            {
                Console.WriteLine(image);
            }

            Console.ReadLine();

            //var member = Expression.MakeBinary( ExpressionType.GreaterThan,
            //    Expression.MakeMemberAccess(Expression.Parameter(typeof(FileInfo)),
            //    typeof(FileInfo).GetProperty(member.Value)))

            //while (true)
            //{
            //    var token = tokenizer.Next();

            //    if(token.Kind == TokenKind.EOF)
            //        break;


            //}

        }
    }
}
