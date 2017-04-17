using System;
using System.Collections.Generic;

namespace Nop.Plugin.ExternalAuth.WeiXin.AspNet
{
    internal static class DictionaryExtensions
    {
        /// <summary>
        /// 添加字典参数
        /// </summary>
        internal static void AddItemIfNotEmpty(this IDictionary<string, string> dictionary, string key, string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (!string.IsNullOrEmpty(value))
            {
                dictionary[key] = value;
            }
        }

        /// <summary>
        /// 转换object为字典对象
        /// </summary>
        /// <typeparam name="T">key</typeparam>
        /// <typeparam name="TV">T value</typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static Dictionary<T, TV> CastFrom<T, TV>(object obj)
        {
            return (Dictionary<T, TV>)obj;
        }
    }
}
