// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Result.cs" company="Centro de Cálculo do ISEL">
//   PROMPT 2011/2012
// </copyright>
// <summary>
//   Defines the Result type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mod02_AdvProgramming_FromCSharp2_0ToLinq 
{
    using System;

    public class Result {
        private String _city;
        private int _count;

        public String City
        {
            get { return _city; }
            set { _city = value; }
        }

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

    }
}