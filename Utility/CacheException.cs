using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    #region 标识缓存的缓存键不能为NULL或Empty的异常类
    /// <summary>
    /// 标识缓存的缓存键不能为NULL或Empty的异常类
    /// </summary>
    public class CacheKeyIsNullOrEmptyException : Exception
    {
        private const string m_Message = "标识缓存的缓存键不能为NULL或空值！";

        /// <summary>
        /// 当标识缓存的缓存键为Null或空时引发的异常
        /// </summary>
        public CacheKeyIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当标识缓存的缓存键为Null或空时引发的异常
        /// </summary>
        public CacheKeyIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当标识缓存的缓存键为Null或空时引发的异常
        /// </summary>
        public CacheKeyIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 需要缓存的对象不能为NUL的异常类
    /// <summary>
    /// 需要缓存的对象不能为NUL的异常类
    /// </summary>
    public class CacheObjectIsNullException : Exception
    {
        private const string m_Message = "需要缓存的对象不能为NULL！";

        /// <summary>
        /// 当需要缓存的对象为Null时引发的异常
        /// </summary>
        public CacheObjectIsNullException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当需要缓存的对象为Null时引发的异常
        /// </summary>
        public CacheObjectIsNullException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当需要缓存的对象为Null或DBNULL时引发的异常
        /// </summary>
        public CacheObjectIsNullException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    //#region 缓存对象不存在或缓存对象错误的异常类
    ///// <summary>
    ///// 缓存对象不存在或缓存对象错误的异常类
    ///// </summary>
    //public class CacheObjectIsErrorException : Exception
    //{
    //    private const string m_Message = "缓存对象不存在或缓存对象错误！";

    //    /// <summary>
    //    /// 当缓存对象不存在或缓存对象错误时引发的异常
    //    /// </summary>
    //    public CacheObjectIsErrorException()
    //        : base(m_Message)
    //    {

    //    }

    //    /// <summary>
    //    /// 当缓存对象不存在或缓存对象错误时引发的异常
    //    /// </summary>
    //    public CacheObjectIsErrorException(string message)
    //        : base(message)
    //    {

    //    }

    //    /// <summary>
    //    /// 当缓存对象不存在或缓存对象错误时引发的异常
    //    /// </summary>
    //    public CacheObjectIsErrorException(string message, Exception ex)
    //        : base(message, ex)
    //    {

    //    }
    //}
    //#endregion

    #region 缓存的对象的过期时间小于或等于当前时间的异常类
    /// <summary>
    /// 缓存的对象的过期时间小于或等于当前时间的异常类
    /// </summary>
    public class AbsoluteExpirationIsErrorException : Exception
    {
        private const string m_Message = "缓存的对象的过期时间必须要大于当前时间！";

        /// <summary>
        /// 当缓存的对象的过期时间小于或等于当前时间时引发的异常
        /// </summary>
        public AbsoluteExpirationIsErrorException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当缓存的对象的过期时间小于或等于当前时间时引发的异常
        /// </summary>
        public AbsoluteExpirationIsErrorException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当缓存的对象的过期时间小于或等于当前时间时引发的异常
        /// </summary>
        public AbsoluteExpirationIsErrorException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 缓存所依赖的文件的Path不能为NULL或Empty的异常类
    /// <summary>
    /// 缓存所依赖的文件的Path不能为NULL或Empty的异常类
    /// </summary>
    public class CachFilePathIsNullOrEmptyException : Exception
    {
        private const string m_Message = "缓存所依赖的文件的路径不能为NULL或空值！";

        /// <summary>
        /// 当缓存所依赖的文件的路径为Null或空时引发的异常
        /// </summary>
        public CachFilePathIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当缓存所依赖的文件的路径为Null或空时引发的异常
        /// </summary>
        public CachFilePathIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当缓存所依赖的文件的路径为Null或空时引发的异常
        /// </summary>
        public CachFilePathIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 缓存所依赖的文件不存在的异常类
    /// <summary>
    /// 缓存所依赖的文件不存在的异常类
    /// </summary>
    public class CacheFileNotExistException : Exception
    {
        private const string m_Message = "缓存所依赖的文件不存在，请检查路径是否正确！";

        /// <summary>
        /// 当缓存所依赖的文件不存在时引发的异常
        /// </summary>
        public CacheFileNotExistException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当缓存所依赖的文件不存在时引发的异常
        /// </summary>
        public CacheFileNotExistException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当缓存所依赖的文件不存在时引发的异常
        /// </summary>
        public CacheFileNotExistException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion
}
