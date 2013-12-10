using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    #region 要上载的内容不能为NULL或Empty的异常类
    /// <summary>
    /// 要上载的内容不能为NULL或Empty的异常类
    /// </summary>
    public class UploadParamsIsNullOrEmptyException : Exception
    {
        private const string m_Message = "要上载的内容不能为NULL或空值！";

        /// <summary>
        /// 当要上载的内容为Null或空时引发的异常
        /// </summary>
        public UploadParamsIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当要上载的内容为Null或空时引发的异常
        /// </summary>
        public UploadParamsIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当要上载的内容为Null或空时引发的异常
        /// </summary>
        public UploadParamsIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region Content-MD5头域不能为NULL或Empty的异常类
    /// <summary>
    /// Content-MD5头域不能为NULL或Empty的异常类
    /// </summary>
    public class ContentMD5IsNullOrEmptyException : Exception
    {
        private const string m_Message = "Content-MD5头域不能为NULL或空值！";

        /// <summary>
        /// 当Content-MD5头域为Null或空时引发的异常
        /// </summary>
        public ContentMD5IsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当Content-MD5头域为Null或空时引发的异常
        /// </summary>
        public ContentMD5IsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当Content-MD5头域为Null或空时引发的异常
        /// </summary>
        public ContentMD5IsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion
}
