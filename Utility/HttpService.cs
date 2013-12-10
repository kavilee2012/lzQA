using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace Utility
{
    /// <summary>
    /// Http协议相关的操作
    /// </summary>
    public static class HttpService
    {
        #region 获取远程页面的返回信息
        /// <summary>
        /// 获取远程页面的返回信息，只获取，不上载
        /// </summary>
        /// <param name="url">带请求参数的url地址</param>
        /// <returns>响应后的资源</returns>
        public static string GetHttpResponse(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new UrlIsNullOrEmptyException();
            }

            if (!RegexService.IsMatch(url, RegexPattern.Url))
            {
                throw new UrlFormatIsErrorException();
            }

            string strReturnString = null;

            using (WebClient webClient = new WebClient())
            {
                webClient.Credentials = CredentialCache.DefaultCredentials;
                webClient.Encoding = Encoding.Default;
                strReturnString = webClient.DownloadString(url);
            }

            return strReturnString;
        }
        #endregion

        #region 获取远程页面的返回信息
        /// <summary>
        /// 获取远程页面的返回信息，只获取，不上载
        /// </summary>
        /// <param name="url">带请求参数的url地址</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应后的资源</returns>
        public static string GetHttpResponse(string url, Encoding encoding)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new UrlIsNullOrEmptyException();
            }

            if (!RegexService.IsMatch(url, RegexPattern.Url))
            {
                throw new UrlFormatIsErrorException();
            }

            if (encoding == null)
            {
                throw new EncodingIsNullException();
            }

            string strReturnString = null;

            using (WebClient webClient = new WebClient())
            {
                webClient.Credentials = CredentialCache.DefaultCredentials;
                webClient.Encoding = encoding;
                strReturnString = webClient.DownloadString(url);
            }

            return strReturnString;
        }
        #endregion

        #region 获取远程页面的返回信息
        /// <summary>
        /// 获取远程页面的返回信息，以XML格式上载后获取
        /// </summary>
        /// <param name="url">资源的URL</param>
        /// <param name="parameter">要上载的字符串</param>
        /// <returns>响应后的资源</returns>
        public static string GetHttpResponse(string url, string parameter)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new UrlIsNullOrEmptyException();
            }

            if (!RegexService.IsMatch(url, RegexPattern.Url))
            {
                throw new UrlFormatIsErrorException();
            }

            if (string.IsNullOrEmpty(parameter))
            {
                throw new UploadParamsIsNullOrEmptyException();
            }

            string strReturnString = null;

            using (WebClient webClient = new WebClient())
            {
                webClient.Credentials = CredentialCache.DefaultCredentials;
                webClient.Encoding = Encoding.Default;
                webClient.Headers.Add(HttpRequestHeader.ContentType, "text/xml");
                strReturnString = webClient.UploadString(url, parameter);
            }

            return strReturnString;
        }
        #endregion

        #region 获取远程页面的返回信息
        /// <summary>
        /// 获取远程页面的返回信息，以不同字符集并以XML格式上载后获取
        /// </summary>
        /// <param name="url">请求页面地址</param>
        /// <param name="parameter">请求提交数据</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>返回页面内容</returns>
        public static string GetHttpResponse(string url, string parameter, Encoding encoding)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new UrlIsNullOrEmptyException();
            }

            if (!RegexService.IsMatch(url, RegexPattern.Url))
            {
                throw new UrlFormatIsErrorException();
            }

            if (string.IsNullOrEmpty(parameter))
            {
                throw new UploadParamsIsNullOrEmptyException();
            }

            if (encoding == null)
            {
                throw new EncodingIsNullException();
            }

            string strRespData = null;

            using (WebClient objWClient = new WebClient())
            {
                objWClient.Credentials = CredentialCache.DefaultCredentials;
                objWClient.Encoding = encoding;
                objWClient.Headers.Add(HttpRequestHeader.ContentType, "text/xml");

                if (parameter.Length > 0)
                {
                    strRespData = objWClient.UploadString(url, parameter);
                }
                else
                {
                    strRespData = objWClient.DownloadString(url);
                }
            }

            return strRespData;
        }
        #endregion

        #region 获取远程页面的返回信息
        /// <summary>
        /// 获取远程页面的返回信息，以不同字符集并以XML格式上载后获取，在请求的头部加上MD5的校验
        /// </summary>
        /// <param name="url">请求页面地址</param>
        /// <param name="parameter">请求提交数据</param>
        /// <param name="encoding">编码方式</param>
        /// <param name="contentMd5">Content-MD5头域</param>
        /// <returns>返回页面内容</returns>
        public static string GetHttpResponse(string url, string parameter, Encoding encoding, string contentMd5)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new UrlIsNullOrEmptyException();
            }

            if (!RegexService.IsMatch(url, RegexPattern.Url))
            {
                throw new UrlFormatIsErrorException();
            }

            if (string.IsNullOrEmpty(parameter))
            {
                throw new UploadParamsIsNullOrEmptyException();
            }

            if (encoding == null)
            {
                throw new EncodingIsNullException();
            }

            if (string.IsNullOrEmpty(contentMd5))
            {
                throw new ContentMD5IsNullOrEmptyException();
            }

            string strRespData = null;

            using (WebClient objWClient = new WebClient())
            {
                objWClient.Credentials = CredentialCache.DefaultCredentials;
                objWClient.Encoding = encoding;
                objWClient.Headers.Add(HttpRequestHeader.ContentType, "text/xml");
                objWClient.Headers.Add(HttpRequestHeader.ContentMd5, contentMd5);

                if (parameter.Length > 0)
                {
                    strRespData = objWClient.UploadString(url, parameter);
                }
                else
                {
                    strRespData = objWClient.DownloadString(url);
                }
            }

            return strRespData;
        }
        #endregion

        #region 获取指定路径下的模板的HTML源代码
        /// <summary>
        /// 获取指定路径下的模板的HTML源代码
        /// </summary>
        /// <param name="templateUrlPath">模板的路径（URL格式的路径）</param>
        /// <param name="encoding">网页类型（有些是UTF8，有些是GB2312）</param>
        /// <returns>源代码</returns>
        public static string GetHtmlCode(string templateUrlPath, Encoding encoding)
        {
            if (string.IsNullOrEmpty(templateUrlPath))
            {
                throw new UrlIsNullOrEmptyException();
            }

            if (!RegexService.IsMatch(templateUrlPath, RegexPattern.Url))
            {
                throw new UrlFormatIsErrorException();
            }

            if (encoding == null)
            {
                throw new EncodingIsNullException();
            }

            string htmlCode = "";

            htmlCode = GetHttpResponse(templateUrlPath, encoding);

            htmlCode = Regex.Replace(htmlCode, @"<!DOCTYPE\s*HTML\s*PUBLIC[^>]+>", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            return htmlCode;
        }
        #endregion
    }
}
