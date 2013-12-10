using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;

namespace Utility
{
    public class CacheService
    {
        /// <summary>
        /// 应用程序配置文件的路径的CacheName
        /// </summary>
        internal const string APPCONFIG_PATH_CACHENAME = "DevDept_Lib_Utils_Utils_Cache_AppConfig_Path_200907281022";

        /// <summary>
        /// 应用程序配置文件(AppConfig.xml)的CacheName
        /// </summary>
        internal const string APPCONFIG_DOCUMENT_CACHENAME = "DevDept_Lib_Utils_Utils_Cache_AppConfig_Document_200907281022";

        /// <summary>
        /// 正则表达式配置文件(RegexConfig.xml)的CacheName
        /// </summary>
        internal const string REGEXCONFIG_DOCUMENT_CACHENAME = "DevDept_Lib_Utils_Utils_Cache_RegexConfig_Document_200907281022";

        /// <summary>
        /// MemCached配置文件(MemCachedConfig.xml)的CacheName
        /// </summary>
        internal const string MEMCACHEDCONFIG_DOCUMENT_CACHENAME = "DevDept_Lib_Utils_Utils_Cache_MemCachedConfig_Document_200907281022";


        #region 获取缓存的对象
        /// <summary>
        /// 获取缓存的对象
        /// </summary>
        /// <param name="key">用于标识该项的缓存键</param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new CacheKeyIsNullOrEmptyException();
            }

            return HttpRuntime.Cache[key];
        }
        #endregion

        #region 缓存对象，永久缓存
        /// <summary>
        /// 缓存对象，永久缓存
        /// </summary>
        /// <param name="key">用于标识该项的缓存键</param>
        /// <param name="value">要插入缓存的对象</param>
        public static void Insert(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new CacheKeyIsNullOrEmptyException();
            }

            if (value == null)
            {
                throw new CacheObjectIsNullException();
            }

            HttpRuntime.Cache.Insert(key, value);
        }
        #endregion

        #region 缓存对象，并时间为依赖
        /// <summary>
        /// 缓存对象，并时间为依赖
        /// </summary>
        /// <param name="key">用于标识该项的缓存键</param>
        /// <param name="value">要插入缓存的对象</param>
        /// <param name="absoluteExpiration">所插入的缓存对象过期并从缓存中移除的时间</param>
        public static void Insert(string key, object value, DateTime absoluteExpiration)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new CacheKeyIsNullOrEmptyException();
            }

            if (value == null)
            {
                throw new CacheObjectIsNullException();
            }

            if (DateTime.Now >= absoluteExpiration)
            {
                throw new AbsoluteExpirationIsErrorException();
            }

            HttpRuntime.Cache.Insert(key, value, null, absoluteExpiration, TimeSpan.Zero);
        }
        #endregion

        #region 缓存对象，并以文件做依赖
        /// <summary>
        /// 缓存对象，并以文件做依赖
        /// </summary>
        /// <param name="key">用于标识该项的缓存键</param>
        /// <param name="value">要插入缓存的对象</param>
        /// <param name="path">缓存所依赖的文件的路径</param>
        public static void Insert(string key, object value, string path)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new CacheKeyIsNullOrEmptyException();
            }

            if (value == null)
            {
                throw new CacheObjectIsNullException();
            }

            if (!File.Exists(path))
            {
                throw new CacheFileNotExistException();
            }

            HttpRuntime.Cache.Insert(key, value, new System.Web.Caching.CacheDependency(path));
        }
        #endregion
    }
}
