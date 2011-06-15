using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mod02_AdvProgramming.LinqToXML
{
    using System.Collections;

    using Mod02_AdvProgramming.Data;

    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Customer> customers = GetCustomers();
        }

        private static IEnumerable<Customer> GetCustomers()
        {
            //XDocument.Parse(customers).
            throw new NotImplementedException();
        }
    }
}
