using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    #region 需要匹配的字符串不能为NULL或Empty的异常类
    /// <summary>
    /// 需要匹配的字符串不能为NULL或Empty的异常类
    /// </summary>
    public class MatchInputIsNullOrEmptyException : Exception
    {
        private const string m_Message = "需要匹配的字符串不能为NULL或空值！";

        /// <summary>
        /// 当需要匹配的字符串为Null或空时引发的异常
        /// </summary>
        public MatchInputIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当需要匹配的字符串为Null或空时引发的异常
        /// </summary>
        public MatchInputIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当需要匹配的字符串为Null或空时引发的异常
        /// </summary>
        public MatchInputIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 正则表达式不能为NULL或Empty的异常类
    /// <summary>
    /// 正则表达式不能为NULL或Empty的异常类
    /// </summary>
    public class MatchPatternIsNullOrEmptyException : Exception
    {
        private const string m_Message = "正则表达式不能为NULL或空值！";

        /// <summary>
        /// 当正则表达式为Null或空时引发的异常
        /// </summary>
        public MatchPatternIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当正则表达式为Null或空时引发的异常
        /// </summary>
        public MatchPatternIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当正则表达式为Null或空时引发的异常
        /// </summary>
        public MatchPatternIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region RegexService.xml配置文件不存在的异常类
    /// <summary>
    /// RegexService.xml配置文件不存在的异常类
    /// </summary>
    public class RegexServiceFileNotExistException : Exception
    {
        private const string m_Message = "RegexService.xml配置文件不存在，请检查路径是否正确！";

        /// <summary>
        /// 当AppConfig.xml配置文件不存在时引发的异常
        /// </summary>
        public RegexServiceFileNotExistException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当AppConfig.xml配置文件不存在时引发的异常
        /// </summary>
        public RegexServiceFileNotExistException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当AppConfig.xml配置文件不存在时引发的异常
        /// </summary>
        public RegexServiceFileNotExistException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion
}
