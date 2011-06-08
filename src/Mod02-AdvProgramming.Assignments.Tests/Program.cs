using System;
using System.Linq;
using Mod02_AdvProgramming.Utils;

namespace Mod02_AdvProgramming.Assignments.Tests {
    class Program {
        static void Main(string[] args)
        {
            //var countries = Ex5.CustomerCountriesSorted();
            //ObjectDumper.Write(countries);
            //Console.WriteLine("Total countries: {0}", countries.Count());

            //var citiesByCountry = Ex5.CustomerCountriesWithCitiesSortedByCountry();
            //ObjectDumper.Write(citiesByCountry, 2);
            //Console.WriteLine("Total countries: {0}", countries.Count());

            //var customerOrders = Ex5.CustomerWithNumOrdersSortedByNumOrdersDescending();
            //ObjectDumper.Write(customerOrders, 2);
            //Console.WriteLine("Total customers: {0}", customerOrders.Count());

            //var totalsByCountry = Ex5.TotalsByCountrySortedByCountry();
            //ObjectDumper.Write(totalsByCountry);

            var totalsByCountry = Ex5.TotalsByCountryByPeriodSortedByCountry(Ex5.PeriodRange.Year);
            ObjectDumper.Write(totalsByCountry);
            Console.ReadLine();

            var totalsByCountry2 = Ex5.TotalsByCountryByPeriodSortedByCountry(Ex5.PeriodRange.Semester);
            ObjectDumper.Write(totalsByCountry2);
            Console.ReadLine();

            var totalsByCountry3 = Ex5.TotalsByCountryByPeriodSortedByCountry(Ex5.PeriodRange.Trimester);
            ObjectDumper.Write(totalsByCountry3);
            Console.ReadLine();

            var totalsByCountry4 = Ex5.TotalsByCountryByPeriodSortedByCountry(Ex5.PeriodRange.Month);
            ObjectDumper.Write(totalsByCountry4);
            Console.ReadLine();

            //var cities = SampleData.LoadCustomersFromXML().Select(c => new { c.City, c.Country }).OrderBy(cc => cc.City);
            //ObjectDumper.Write(cities);
            Console.ReadLine();
        }
    }
}
