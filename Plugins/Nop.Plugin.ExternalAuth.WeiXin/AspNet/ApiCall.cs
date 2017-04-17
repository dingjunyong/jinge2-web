using System;

namespace Nop.Plugin.ExternalAuth.WeiXin.AspNet
{
    public class ApiCall
    {
        /// <summary>
        /// 尝试多次与服务器交互
        /// </summary>
        /// <typeparam name="T">返回对象</typeparam>
        /// <param name="func"></param>
        /// <param name="param"></param>
        /// <param name="requestCount">交互次数</param>
        /// <returns></returns>
        public static T TryCallServer<T>(Func<object, T> func, object param, int requestCount)
        {
            int tryCount = 1;
            while (tryCount <= requestCount)
            {
                try
                {
                    return func(param);
                }
                catch (Exception)
                {
                    if (tryCount == requestCount)
                        throw;
                }
                tryCount++;
            }

            return default(T);
        }
    }
}
