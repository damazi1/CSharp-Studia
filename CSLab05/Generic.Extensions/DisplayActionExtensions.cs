using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Extensions
{
    public static class DisplayActionExtensions
    {
        public static void Print<TObjectType>(this TObjectType obj) 
        {
            var obiekt = obj;
            Console.WriteLine(obiekt.ToString());
        }
        public static void Print<TObjectType>(this IList<TObjectType> list)
        {
            var kolekcjaWObiekcie = list;
            if (kolekcjaWObiekcie == null) return;
            foreach ( var item in kolekcjaWObiekcie)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
