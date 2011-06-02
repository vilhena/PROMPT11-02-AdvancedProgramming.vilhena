// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyExtensionClass.cs" company="Centro de Cálculo do ISEL">
//   PROMPT 2011/2012
// </copyright>
// <summary>
//   Extention class with sample extension method operators.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Mod02_AdvProgramming_FromCSharp2_0ToLinq
{
    using System.Collections.Generic;

    /// <summary>
    /// Extention class with sample extension method operators.
    /// </summary>
    public static class MyExtensionClass 
    {
        /// <summary>
        /// Converts all <see cref="Result.City"/> to uppercase.
        /// </summary>
        /// <param name="coll">The extended <see cref="IEnumerable{Result}"/></param>
        /// <returns>A sequence with all <see cref="Result.City"/> in uppercase.</returns>
        public static IEnumerable<Result> ToUpperCity(this IEnumerable<Result> coll)
        {
            foreach (Result item in coll) 
            {
                item.City = item.City.ToUpper();
                yield return item;
            }
        }
    }
}