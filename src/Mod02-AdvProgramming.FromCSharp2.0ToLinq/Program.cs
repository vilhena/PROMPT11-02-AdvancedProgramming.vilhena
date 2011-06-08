// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Centro de Cálculo do ISEL">
//   PROMPT 2011/2012
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;

namespace Mod02_AdvProgramming_FromCSharp2_0ToLinq 
{
    using System.Collections.Generic;
    using Mod02_AdvProgramming.Utils;
    using Mod02_AdvProgramming.Data;
    using System.Linq;

    /// <summary>
    /// The main entry point class.
    /// </summary>
    public class Program 
    {
        public static IEnumerable<string> GetFileLines(string filename)
        {
            var f = new StreamReader(filename);
            while (!f.EndOfStream)
            {
                yield return f.ReadLine();
            }
        }
        public static IEnumerable<int> GetLines()
        {
            var i = 0;
            while (true)
            {
                yield return i++;
            }
        }

        /// <summary>
        /// The program entry point.
        /// </summary>
        /// <param name="args">The program arguments.</param>
        public static void Main(string[] args)
        {
            foreach (var i in GetLines().
                
                Zip(GetFileLines(
                @"C:\Users\gnvilhena\PROMPT\uc01\repos\PROMPT11-02-AdvancedProgramming.vilhena\src\Mod02-AdvProgramming.FromCSharp2.0ToLinq\Program.cs")
                , (s, i) => s + i))
            {
                Console.WriteLine(i);
                Console.ReadLine();
            }

            
            #region 1 - All Cities that starts with letter M and the number of Customers in each one

            // Old fashioned way (C# 2.0)
            //List<Result> results = new List<Result>();
            //foreach (Customer c in SampleData.LoadCustomersFromMemory())
            //{
            //    if (c.City.StartsWith("L"))
            //    {
            //        Result res = results.Find(
            //            delegate(Result r) { return c.City == r.City; });
            //        if (res == null)
            //        {
            //            // Create a new Result
            //            res = new Result();
            //            res.City = c.City;
            //            res.Count = 1;
            //            results.Add(res);
            //        }
            //        else
            //        {
            //            ++res.Count;
            //        }
            //    }
            //}

            //ObjectDumper.Write(results);

            #endregion

            #region 2 - All Cities that starts with letter M and the number of Customers in each one

            // More modern Way (C#3.0)

            // 1 Automatic Proerties in Customers
            // 2 Object Initializers
            // 3 Collection Initializers
            // 4 Lambda Expressions
            // 5 Type Inference (results)

            //var results = new List<Result>();
            //foreach (Customer c in Customer.LoadCustomersFromMemoryNew())
            //{
            //    if (c.City.StartsWith("M")) {
            //        Result res = results.Find(
            //             r => c.City == r.City );
            //        //Result res = results.Find(r => c.City == r.City);
            //        if (res == null)
            //        {
            //            // Create a new Result
            //            res = new Result();
            //            res.City = c.City;
            //            res.Count = 1;
            //            results.Add(res);
            //        }
            //        else
            //        {
            //            ++res.Count;
            //        }

            //    }
            //}
            //ObjectDumper.Write(results);

            #endregion

            #region 3 - All Cities that starts with letter M and the number of Customers in each one

            // Now with Linq
            //var query = from c in Customer.LoadCustomersFromMemoryNew()
            //                            where c.City.StartsWith("M")
            //                            group c by c.City into g
            //                            select new { City = g.Key, Count = g.Count() };

            ////ObjectDumper.Write(query);
            //string startSeq = "M"; 

            //var query = Customer.LoadCustomersFromMemoryNew().Where(c => c.City.StartsWith("M")).
            //            GroupBy(c => c.City).
            //            Select(g => new { City = g.Key, Count = g.Count() });



            //ObjectDumper.Write(query);
            //Console.WriteLine("########################");
            //startSeq = "L"; 

            //ObjectDumper.Write(query);
            //Console.WriteLine("########################");

            //var query1 = query.Where(c => c.Count > 2);
            //ObjectDumper.Write(query1);
            //Console.WriteLine("########################");
            //ObjectDumper.Write(query);

            #endregion

            #region 4 - Extend the IEnumerable<Result> with an operator ToUpperCity

            // Same stuff with Linq
            //var query = (from c in Customer.LoadCustomersFromMemoryNew()
            //             where c.City.StartsWith("M")
            //             group c by c.City into g
            //             select new Result { City = g.Key, Count = g.Count() }).ToUpperCity();

            //ObjectDumper.Write(query);
            //var query = Customer.LoadCustomersFromMemoryNew().
            //            Where(c => c.City.StartsWith("M")).
            //            GroupBy(c => c.City).
            //            Select(g => new Result { City = g.Key, Count = g.Count() }).ToUpperCity();
            //ObjectDumper.Write(query);

            #endregion

            #region 5 - Now more complicated queries using Orders


            //var query = from c in SampleData.LoadCustomersFromXML()
            //             where c.City.StartsWith("M")
            //             group c by c.City into g
            //             select new { City = g.Key, Count = g.Count() };

            //ObjectDumper.Write(query);


            #endregion

        }

    }
}
