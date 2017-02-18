using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shinetechchina.Employee.Core
{
    public static class ContextDictionary
    {
        public static Dictionary<Type, ContextBase> ContextBaseDictionary = new Dictionary<Type, ContextBase> { };

        public static void Add<T>(ContextBase ctx)
        {
            if (!ContextBaseDictionary.Keys.ToList().Exists(t => t == typeof(T)))
            {
                ContextBaseDictionary.Add(typeof(T), ctx);
            }

        }

        public static T Get<T>()
        {
            object ctx = null; ;
            foreach (var item in ContextBaseDictionary)
            {
                if (item.Key == typeof(T))
                {
                    ctx = item.Value;
                }
            }
            return (T)ctx;
        }
    }
}
