using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    #region 源图路径不能为NULL或Empty的异常类
    /// <summary>
    /// 源图路径不能为NULL或Empty的异常类
    /// </summary>
    public class SourceImagePathIsNullOrEmptyException : Exception
    {
        private const string m_Message = "源图路径不能为NULL或空值！";

        /// <summary>
        /// 当源图路径为Null或空时引发的异常
        /// </summary>
        public SourceImagePathIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当源图路径为Null或空时引发的异常
        /// </summary>
        public SourceImagePathIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当源图路径为Null或空时引发的异常
        /// </summary>
        public SourceImagePathIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 源图文件不存在的异常类
    /// <summary>
    /// 源图文件不存在的异常类
    /// </summary>
    public class SourceFileNotExistException : Exception
    {
        private const string m_Message = "源图文件不存在，请检查路径是否正确！";

        /// <summary>
        /// 当源图文件不存在时引发的异常
        /// </summary>
        public SourceFileNotExistException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当源图文件不存在时引发的异常
        /// </summary>
        public SourceFileNotExistException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当源图文件不存在时引发的异常
        /// </summary>
        public SourceFileNotExistException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 源文件不是图型文件的异常类
    /// <summary>
    /// 源文件不是图型文件的异常类
    /// </summary>
    public class SourceFileIsNotImageException : Exception
    {
        private const string m_Message = "源文件不是图型文件，请检查路径是否正确！";

        /// <summary>
        /// 当源文件不是图型文件时引发的异常
        /// </summary>
        public SourceFileIsNotImageException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当源文件不是图型文件时引发的异常
        /// </summary>
        public SourceFileIsNotImageException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当源文件不是图型文件时引发的异常
        /// </summary>
        public SourceFileIsNotImageException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 缩略图路径不能为NULL或Empty的异常类
    /// <summary>
    /// 源图路径不能为NULL或Empty的异常类
    /// </summary>
    public class ThumbImagePathIsNullOrEmptyException : Exception
    {
        private const string m_Message = "缩略图路径不能为NULL或空值！";

        /// <summary>
        /// 当缩略图路径为Null或空时引发的异常
        /// </summary>
        public ThumbImagePathIsNullOrEmptyException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当缩略图路径为Null或空时引发的异常
        /// </summary>
        public ThumbImagePathIsNullOrEmptyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当缩略图路径为Null或空时引发的异常
        /// </summary>
        public ThumbImagePathIsNullOrEmptyException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 缩略图文件保存路径不存在的异常类
    /// <summary>
    /// 缩略图文件保存路径不存在的异常类
    /// </summary>
    public class ThumbImagePathNotExistException : Exception
    {
        private const string m_Message = "缩略图文件保存路径不存在，请检查路径是否正确！";

        /// <summary>
        /// 当缩略图文件保存路径不存在时引发的异常
        /// </summary>
        public ThumbImagePathNotExistException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当缩略图文件保存路径不存在时引发的异常
        /// </summary>
        public ThumbImagePathNotExistException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当缩略图文件保存路径不存在时引发的异常
        /// </summary>
        public ThumbImagePathNotExistException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 缩略图宽度错误的异常类
    /// <summary>
    /// 缩略图宽度错误的异常类
    /// </summary>
    public class ThumbImageWidthIsErrorException : Exception
    {
        private const string m_Message = "缩略图宽度必须大于0并且小于源图的宽度！";

        /// <summary>
        /// 当缩略图宽度小于或等于0或缩略图宽度小于源图宽度时引发的异常
        /// </summary>
        public ThumbImageWidthIsErrorException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当缩略图宽度小于或等于0或缩略图宽度小于源图宽度时引发的异常
        /// </summary>
        public ThumbImageWidthIsErrorException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当缩略图宽度小于或等于0或缩略图宽度小于源图宽度时引发的异常
        /// </summary>
        public ThumbImageWidthIsErrorException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion

    #region 缩略图高度错误的异常类
    /// <summary>
    /// 缩略图高度错误的异常类
    /// </summary>
    public class ThumbImageHeigthIsErrorException : Exception
    {
        private const string m_Message = "缩略图高度必须大于0并且小于源图的高度！";

        /// <summary>
        /// 当缩略图高度小于或等于0或缩略图高度小于源图高度时引发的异常
        /// </summary>
        public ThumbImageHeigthIsErrorException()
            : base(m_Message)
        {

        }

        /// <summary>
        /// 当缩略图高度小于或等于0或缩略图高度小于源图高度时引发的异常
        /// </summary>
        public ThumbImageHeigthIsErrorException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 当缩略图高度小于或等于0或缩略图高度小于源图高度时引发的异常
        /// </summary>
        public ThumbImageHeigthIsErrorException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
    #endregion
}
