using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    #region 源字符串不能为NULL或Empty的异常类
    /// <summary>
    /// 源字符串不能为NULL或Empty的异常类
    /// </summary>
    public class SourceIsNullOrEmptyException : Exception
    {
        private const string m_Message = "源字符串不能为NULL或空值！";

        /// <summary>
        /// 当源字符串为NULL或空时引发的异常
        /// </summary>
        public SourceIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当源字符串为NULL或空时引发的异常
        /// </summary>
        public SourceIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当源字符串为NULL或空时引发的异常
        /// </summary>
        public SourceIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 密钥不能为NULL或Empty的异常类
    /// <summary>
    /// 密钥不能为NULL或Empty的异常类
    /// </summary>
    public class EncryptKeyIsNullOrEmptyException : Exception
    {
        private const string m_Message = "密钥不能为NULL或空值！";

        /// <summary>
        /// 当密钥为NULL或空时引发的异常
        /// </summary>
        public EncryptKeyIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当密钥为NULL或空时引发的异常
        /// </summary>
        public EncryptKeyIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当密钥为NULL或空时引发的异常
        /// </summary>
        public EncryptKeyIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 源文件路径不能为NULL或Empty的异常类
    /// <summary>
    /// 源文件的路径不能为NULL或Empty的异常类
    /// </summary>
    public class SourceFilePathIsNullOrEmptyException : Exception
    {
        private const string m_Message = "源文件的路径不能为NULL或空值！";

        /// <summary>
        /// 当源文件的路径为NULL或空时引发的异常
        /// </summary>
        public SourceFilePathIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当源文件的路径为NULL或空时引发的异常
        /// </summary>
        public SourceFilePathIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当源文件的路径为NULL或空时引发的异常
        /// </summary>
        public SourceFilePathIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    //#region 源文件不存在的异常类
    ///// <summary>
    ///// 源文件不存在的异常类
    ///// </summary>
    //public class SourceFileNotExistException : Exception
    //{
    //    private const string m_Message = "源文件不存在，请检查路径是否正确！";

    //    /// <summary>
    //    /// 当源文件不存在时引发的异常
    //    /// </summary>
    //    public SourceFileNotExistException()
    //        : base(m_Message)
    //    {

    //    }

    //    /// <summary>
    //    /// 当源文件不存在时引发的异常
    //    /// </summary>
    //    public SourceFileNotExistException(string message)
    //        : base(message)
    //    {

    //    }

    //    /// <summary>
    //    /// 当源文件不存在时引发的异常
    //    /// </summary>
    //    public SourceFileNotExistException(string message, Exception ex)
    //        : base(message, ex)
    //    {

    //    }
    //}
    //#endregion

    #region 目标文件路径不能为NULL或Empty的异常类
    /// <summary>
    /// 目标文件的路径不能为NULL或Empty的异常类
    /// </summary>
    public class TargetFilePathIsNullOrEmptyException : Exception
    {
        private const string m_Message = "目标文件的路径不能为NULL或空值！";

        /// <summary>
        /// 当目标文件的路径为NULL或空时引发的异常
        /// </summary>
        public TargetFilePathIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当目标文件的路径为NULL或空时引发的异常
        /// </summary>
        public TargetFilePathIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当目标文件的路径为NULL或空时引发的异常
        /// </summary>
        public TargetFilePathIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    //#region 加/解密的FileSize不能大于2M的异常类
    ///// <summary>
    ///// 加/解密的FileSize不能大于2M的异常类
    ///// </summary>
    //public class FileSizeIsGreaterThan2MException : Exception
    //{
    //    private const string m_Message = "加/解密的文件大小不能大于2M！";

    //    /// <summary>
    //    /// 当加/解密的文件大小大于2M时引发的异常
    //    /// </summary>
    //    public FileSizeIsGreaterThan2MException()
    //        : base(m_Message)
    //    {

    //    }

    //    /// <summary>
    //    /// 当加/解密的文件大小大于2M时引发的异常
    //    /// </summary>
    //    public FileSizeIsGreaterThan2MException(string message)
    //        : base(message)
    //    {

    //    }

    //    /// <summary>
    //    /// 当加/解密的文件大小大于2M时引发的异常
    //    /// </summary>
    //    public FileSizeIsGreaterThan2MException(string message, Exception ex)
    //        : base(message, ex)
    //    {

    //    }
    //}
    //#endregion

    #region 解密过程发生错误的异常类
    /// <summary>
    /// 解密过程发生错误的异常类
    /// </summary>
    public class DecryptErrorException : Exception
    {
        private const string m_Message = "解密过程发生错误！";

        /// <summary>
        /// 当解密过程发生错误时引发的异常
        /// </summary>
        public DecryptErrorException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当解密过程发生错误时引发的异常
        /// </summary>
        public DecryptErrorException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当解密过程发生错误时引发的异常
        /// </summary>
        public DecryptErrorException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion
}
