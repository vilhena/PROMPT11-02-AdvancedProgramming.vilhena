using System.Collections.Generic;

namespace DIChelas.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddIfNotContainsKey<TKey,TValue>(this IDictionary<TKey,TValue> dic,TKey key, TValue value )
        {
            if (!dic.ContainsKey(key))
                dic.Add(key, value);
        }

        public static TValue Value<TKey,TValue>(this IDictionary<TKey,TValue> dic,TKey key)
        {
            if (dic.ContainsKey(key))
                return dic[key];

            return default(TValue);
        }
    }
}
