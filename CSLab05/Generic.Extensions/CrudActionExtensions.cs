using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Extensions
{
    public static class CrudActionExtensions
    {
        public static IList<TObjectType> Set<TObjectType>(this IContainer conteinerObject)
        {
            if (conteinerObject == null) return null;
            var typ = conteinerObject?.GetType();
            if (typ == null) return null;

            var kolekcjaWTypie = typ
            .GetProperties()
            .FirstOrDefault(p => p.PropertyType == typeof(IList<TObjectType>));
            if (kolekcjaWTypie == null) return null;

            var kolekcjaWObiekcie = kolekcjaWTypie
                .GetValue(conteinerObject) as IList<TObjectType>;
            if (kolekcjaWObiekcie == null) return null;
            return kolekcjaWObiekcie;
        }
        public static IContainer Add<TObjectType>(this IContainer container, TObjectType obj)
        {
            var kolekcjaWObiekcie = Set<TObjectType>(container);
            if (kolekcjaWObiekcie == null) return null;
            kolekcjaWObiekcie.Add(obj);
            return container;
        }
        
        public static IContainer AddRange<TObjectType>(this IContainer container, IList<TObjectType> listOfElemtnts)
        {
            foreach (TObjectType obj in listOfElemtnts) { container.Add(obj); }
            return container;
        }
        public static void ForEach<TObjectType>(this IContainer container, Action<TObjectType> action)
        {
            var kolekcjaWObiekcie = Set<TObjectType>(container);
            if (kolekcjaWObiekcie == null) return;
            foreach (TObjectType obj in kolekcjaWObiekcie) { action(obj); }
        }
        public static TObjectType Get<TObjectType>(this IContainer container, Func<TObjectType,bool> searchPredict = null) {
            var kolekcjaWObiekcie = Set<TObjectType>(container);
            if (kolekcjaWObiekcie == null) return default;
            if (searchPredict==null){
                return kolekcjaWObiekcie[0];
            }
            foreach (TObjectType obiekt in kolekcjaWObiekcie)
            {
                if (searchPredict(obiekt))
                    return obiekt;
            }
            return default;
        }
        public static IList<TObjectType> GetList<TObjectType>(this IContainer container, Func<TObjectType,bool>searchPredict = null) {
            var kolekcjaWObiekcie = Set<TObjectType>(container);
            if (kolekcjaWObiekcie == null) return null;
            var znalezione = Activator.CreateInstance(typeof(List<TObjectType>)) as IList<TObjectType>;
            foreach (TObjectType obiekt in kolekcjaWObiekcie)
            {
                if(searchPredict(obiekt))
                    znalezione.Add(obiekt);
            }
            return znalezione;
        }
        public static bool Remove<TObjectType>(this IContainer container, Func<TObjectType,bool> searchFn)
        {
            var kolekcjaWObiekcie = Set<TObjectType>(container);
            if (kolekcjaWObiekcie == null) return false;
            foreach (var ob in kolekcjaWObiekcie)
            {
                if (searchFn(ob))
                {
                    kolekcjaWObiekcie.Remove(ob);
                    return true;
                }
            }
            return false;
        }
    }
}
