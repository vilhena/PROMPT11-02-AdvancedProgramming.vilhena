using System;
using System.Linq;
using Mod02_AdvProgramming.Data;

namespace Mod02_AdvProgramming.Assignments
{
    using System.Collections.Generic;

    public class Ex5
    {
        public class CountryWithCities
        {
            public string Country { get; set; }
            public IEnumerable<string> Cities { get; set; }
        }

        public class CustomerOrders
        {
            public string Customer { get; set; }
            public int NumOrders { get; set; }
            public decimal TotalSales { get; set; }
        }

        public class TotalsByCountry
        {
            public string Country { get; set; }
            public int NumCustomers { get; set; }
            public decimal TotalSales { get; set; }
        }

        public enum PeriodRange
        {
            Year = 12,
            Semester = 6,
            Trimester = 3,
            Month = 1
        }

        public class TotalsByCountryByPeriod : TotalsByCountry
        {
            public PeriodRange PeriodRange { get; set; }
            public int Year { get; set; }
            public int YearPart { get; set; }
        }

        public static IEnumerable<string> CustomerCountriesSorted()
        {
            return SampleData.LoadCustomersFromXML()
                .OrderBy(c => c.Country)
                .Select(c => c.Country)
                .Distinct();
        }

        public static IEnumerable<string> CustomerCountriesSortedSelectFirst()
        {
            return SampleData.LoadCustomersFromXML()
                .Select(c => c.Country)
                .Distinct()
                .OrderBy(c => c);
        }

        public static IEnumerable<CountryWithCities> CustomerCountriesWithCitiesSortedByCountry()
        {
            return SampleData.LoadCustomersFromXML()
                .Select(c => new {c.Country, c.City})
                .Distinct()
                .GroupBy(s => s.Country)
                .Select(g => new CountryWithCities()
                                 {
                                     Country = g.Key,
                                     Cities = g.Select(i => i.City).OrderBy(x => x)
                                 }
                )
                .OrderBy(r => r.Country);
        }


        public static IEnumerable<CustomerOrders> CustomerWithNumOrdersSortedByNumOrdersDescending()
        {
            return SampleData.LoadCustomersFromXML()
                .Select(xpto => new CustomerOrders()
                                    {
                                        Customer = xpto.Name,
                                        NumOrders = xpto.Orders.Count(),
                                        TotalSales = xpto.Orders.Sum(sale=>sale.Total)

                                    }).OrderByDescending(x=>x.NumOrders);

        }

        public static IEnumerable<TotalsByCountry> TotalsByCountrySortedByCountry()
        {
            return SampleData.LoadCustomersFromXML()
                .GroupBy(x => x.Country)
                .Select(g => new TotalsByCountry()
                                 {
                                     Country = g.Key,
                                     NumCustomers = g.Select(x => x.CustomerID).Distinct().Count(),
                                     //TotalSales = g.Sum(z => z.Orders
                                     //                            .Sum(o => o.Total))
                                     TotalSales = g.SelectMany(z => z.Orders).Sum(o => o.Total)
                                 }
                )
                .OrderBy(c => c.Country);
        }

        public static int GetYearPart(DateTime date, PeriodRange range)
        {
            var i = 0;

            switch (range)
            {
                case PeriodRange.Year:
                    i = 0;
                    break;
                case PeriodRange.Semester:
                    i = date.Month/6;
                    break;
                case PeriodRange.Trimester:
                    i = date.Month/3;
                    break;
                case PeriodRange.Month:
                    i = date.Month;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("range");
            }

            return i;
        }

        public static IEnumerable<TotalsByCountryByPeriod> TotalsByCountryByPeriodSortedByCountry(PeriodRange periodRange)
        {
            var range = (int) periodRange;
            return SampleData.LoadCustomersFromXML()
                .SelectMany(s => s.Orders, (f, o) => new
                                                         {
                                                             f.Country,
                                                             f.CustomerID,
                                                             o.Total,
                                                             Range = o.OrderDate.Year.ToString()
                                                                     + f.Country
                                                                     + GetYearPart(o.OrderDate,periodRange),
                                                             periodRange,
                                                             o.OrderDate.Year,
                                                             YearPart = GetYearPart(o.OrderDate, periodRange)
                                                         })
                .GroupBy(z => z.Range)
                .Select(g => new TotalsByCountryByPeriod()
                                 {
                                     Country = g.Select(t => t.Country).First(),
                                     NumCustomers = g.Select(c => c.CustomerID).Distinct().Count(),
                                     PeriodRange = g.Select(p => p.periodRange).First(),
                                     TotalSales = g.Sum(x => x.Total),
                                     Year = g.Select(h=>h.Year).First(),
                                     YearPart = g.Select(h=>h.YearPart).First()
                                 })
                                 .OrderBy(k=>k.Country)
                                 .ThenBy(i=>i.Year)
                                 .ThenBy(z=>z.YearPart);

        }

    }

}
