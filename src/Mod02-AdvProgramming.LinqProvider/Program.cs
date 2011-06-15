using System;
using System.Collections.Generic;

namespace Mod02_AdvProgramming.LinqProvider
{
    using System.Linq;

    using Mod02_AdvProgramming.LinqProvider.ImagesMetadata;
    using Mod02_AdvProgramming.LinqProvider.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            ImagesCollection imagesCollection = new ImagesCollection();
            var query1 = imagesCollection.AsQueryable().Where(ii => ii.Location == "Lisboa" && ii.DaysTaken.TotalDays >= 10);
            Console.WriteLine("** query1 **");
            Console.WriteLine(query1);
            var query2 = imagesCollection.AsQueryable().Where(ii => ii.Camera.Model == "Cannon" && ii.DaysTaken.TotalDays >= 2).Take(2);
            Console.WriteLine("** query2 **");
            Console.WriteLine(query2);
        }

        private static void Dump<T>(IEnumerable<T> elems)
        {
            foreach (var f in elems)
            {
                Console.WriteLine(f);
                Console.WriteLine("--------------------");
            }
        }
    }
}
