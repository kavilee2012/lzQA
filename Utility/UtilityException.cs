using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    #region 指定的时间不能大于当前时间的异常类
    /// <summary>
    /// 指定的时间不能大于当前时间的异常类
    /// </summary>
    public class DateTimeIsGreaterThanNowException : Exception
    {
        private const string m_Message = "指定的时间不能大于当前时间！";

        /// <summary>
        /// 当指定的时间大于当前时间时引发的异常
        /// </summary>
        public DateTimeIsGreaterThanNowException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当指定的时间大于当前时间时引发的异常
        /// </summary>
        public DateTimeIsGreaterThanNowException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当指定的时间大于当前时间时引发的异常
        /// </summary>
        public DateTimeIsGreaterThanNowException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region Html字符串不能为NULL或Empty的异常类
    /// <summary>
    /// Html字符串不能为NULL或Empty的异常类
    /// </summary>
    public class HtmlInputIsNullOrEmptyException : Exception
    {
        private const string m_Message = "Html字符串不能为NULL或空值！";

        /// <summary>
        /// 当Html字符串为Null或空时引发的异常
        /// </summary>
        public HtmlInputIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当Html字符串为Null或空时引发的异常
        /// </summary>
        public HtmlInputIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当Html字符串为Null或空时引发的异常
        /// </summary>
        public HtmlInputIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region Encoding不能为NULL的异常类
    /// <summary>
    /// Encoding不能为NULL的异常类
    /// </summary>
    public class EncodingIsNullException : Exception
    {
        private const string m_Message = "字符编码不能为NULL！";

        /// <summary>
        /// 当字符编码为Null时引发的异常
        /// </summary>
        public EncodingIsNullException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当字符编码为Null时引发的异常
        /// </summary>
        public EncodingIsNullException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当字符编码为Null时引发的异常
        /// </summary>
        public EncodingIsNullException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region URL不能为NULL或Empty的异常类
    /// <summary>
    /// URL不能为NULL或Empty的异常类
    /// </summary>
    public class UrlIsNullOrEmptyException : Exception
    {
        private const string m_Message = "URL不能为NULL或空值！";

        /// <summary>
        /// 当URL为Null或空时引发的异常
        /// </summary>
        public UrlIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当URL为Null或空时引发的异常
        /// </summary>
        public UrlIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当URL为Null或空时引发的异常
        /// </summary>
        public UrlIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 错误的URL格式的异常类
    /// <summary>
    /// 错误的URL格式的异常类
    /// </summary>
    public class UrlFormatIsErrorException : Exception
    {
        private const string m_Message = "错误的URL格式，请确定你的URL是有效的！";

        /// <summary>
        /// 当URL格式错误时引发的异常
        /// </summary>
        public UrlFormatIsErrorException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当URL格式错误时引发的异常
        /// </summary>
        public UrlFormatIsErrorException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当URL格式错误时引发的异常
        /// </summary>
        public UrlFormatIsErrorException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion


}
