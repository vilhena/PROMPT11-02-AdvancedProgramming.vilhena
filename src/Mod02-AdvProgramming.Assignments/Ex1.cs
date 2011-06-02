namespace Mod02_AdvProgramming.Assignments {
    using System;
    using System.Collections.Generic;

    public class Ex1 {

        //1.Complete o método LessThan, que recebe um objecto de referência
        //    , de tipo genérico, e uma colecção genérica
        //        , cujos elementos são do tipo anulável correspondente 
        //            ao tipo do objecto de referência. LessThan devolve a 
        //                lista dos valores dos elementos da colecção de entrada
        //                    que são menores do que o objecto de referência.

        public static List<Prm> LessThan<Prm>(ICollection<Prm?> col, Prm r)
            where Prm : struct, IComparable<Prm>
        {
            var retList = new List<Prm>();
            if (col != null)
            {
                foreach (var prm in col)
                {
                    if (prm.HasValue && prm.Value.CompareTo(r) < 0)
                        retList.Add(prm.Value);
                }
            }
            return retList;
        }


    }
}