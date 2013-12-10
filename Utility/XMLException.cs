    using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    #region xPath表达式不能为NULL或Empty的异常类
    /// <summary>
    /// xPath表达式不能为NULL或Empty的异常类
    /// </summary>
    public class XPathIsNullOrEmptyException : Exception
    {
        private const string m_Message = "xPath表达式不能为null或空值！";

        /// <summary>
        /// 当xPath表达式为Null或空时引发的异常
        /// </summary>
        public XPathIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当xPath表达式为Null或空时引发的异常
        /// </summary>
        public XPathIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当xPath表达式为Null或空时引发的异常
        /// </summary>
        public XPathIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region XML文件不存在的异常类
    /// <summary>
    /// XML文件不存在的异常类
    /// </summary>
    public class XmlFileNotExistException : Exception
    {
        private const string m_Message = "XML文件不存在，请检查路径是否正确！";

        /// <summary>
        /// 当XML文件不存在时引发的异常
        /// </summary>
        public XmlFileNotExistException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当XML文件不存在时引发的异常
        /// </summary>
        public XmlFileNotExistException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当XML文件不存在时引发的异常
        /// </summary>
        public XmlFileNotExistException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region XML文档为Null的异常类
    /// <summary>
    /// XML文档为Null的异常类
    /// </summary>
    public class XmlDocumentIsNullException : Exception
    {
        private const string m_Message = "XML文档为Null，请确认文档的正确性！";

        /// <summary>
        /// 当XML文档为Null时引发的异常
        /// </summary>
        public XmlDocumentIsNullException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当XML文档为Null时引发的异常
        /// </summary>
        public XmlDocumentIsNullException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当XML文档为Null时引发的异常
        /// </summary>
        public XmlDocumentIsNullException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region Xml节点错误的异常类
    /// <summary>
    /// Xml节点错误的异常类
    /// </summary>
    public class XmlNodeIsErrorException : Exception
    {
        private const string m_Message = "Xml节点错误，请确认节点的正确性！";

        /// <summary>
        /// 当Xml节点错误时引发的异常
        /// </summary>
        public XmlNodeIsErrorException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当Xml节点错误时引发的异常
        /// </summary>
        public XmlNodeIsErrorException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当Xl节点错误时引发的异常
        /// </summary>
        public XmlNodeIsErrorException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region XmlNode为Null的异常类
    /// <summary>
    /// XmlNode为Null的异常类
    /// </summary>
    public class XmlNodeIsNullException : Exception
    {
        private const string m_Message = "XmlNode为Null，请确认节点的正确性！";

        /// <summary>
        /// 当XmlNode为Null时引发的异常
        /// </summary>
        public XmlNodeIsNullException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当XmlNode为Null时引发的异常
        /// </summary>
        public XmlNodeIsNullException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当XmlNode为Null时引发的异常
        /// </summary>
        public XmlNodeIsNullException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region Xml节点集合错误的异常类
    /// <summary>
    /// Xml节点集合错误的异常类
    /// </summary>
    public class XmlNodeListIsErrorException : Exception
    {
        private const string m_Message = "Xml节点集合错误，请确认节点的正确性！";

        /// <summary>
        /// 当Xml节点集合错误时引发的异常
        /// </summary>
        public XmlNodeListIsErrorException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当Xml节点集合错误时引发的异常
        /// </summary>
        public XmlNodeListIsErrorException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当Xml节点集合错误时引发的异常
        /// </summary>
        public XmlNodeListIsErrorException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion
}
