using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    #region AppConfig.xml配置文件不存在的异常类
    /// <summary>
    /// AppConfig.xml配置文件不存在的异常类
    /// </summary>
    public class AppConfigFileNotExistException : Exception
    {
        private const string m_Message = "AppConfig.xml配置文件不存在，请检查路径是否正确！";

        /// <summary>
        /// 当AppConfig.xml配置文件不存在时引发的异常
        /// </summary>
        public AppConfigFileNotExistException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当AppConfig.xml配置文件不存在时引发的异常
        /// </summary>
        public AppConfigFileNotExistException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当AppConfig.xml配置文件不存在时引发的异常
        /// </summary>
        public AppConfigFileNotExistException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion
}
