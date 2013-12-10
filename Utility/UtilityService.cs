using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace Utility
{
    public class UtilityService
    {
        #region 截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="InputStr">所要截取的字符串</param>
        /// <param name="CutLen">要截取的长度</param>
        /// <param name="postfix">截取后所要加上的后缀，比如"…"之类的</param>
        /// <returns>截取后的字符串</returns>
        public static string CuttingStrings(string InputStr, int CutLen, string postfix)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            char[] charArray = InputStr.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int lenTemp = 0;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (regex.IsMatch((charArray[i]).ToString()))
                {
                    lenTemp += 2;
                }
                else
                {
                    lenTemp++;
                }

                if (lenTemp <= CutLen)
                {
                    sb.Append(charArray[i]);
                }
                else
                {
                    break;
                }
            }

            if (sb.ToString().Length < InputStr.Length)
            {
                sb.Append(postfix);
            }

            return sb.ToString();
        }
        #endregion

        #region 获得用户登录时的真实IP
        /// <summary>
        /// 获得用户登录时的真实IP
        /// </summary>
        /// <returns>客户端IP地址</returns>
        public static string GetClientIP()
        {
            string result = "未知";
            try
            {
                string httpXForwardedFor = HttpContext.Current.Request.
                    ServerVariables["HTTP_X_FORWARDED_FOR"] as string;
                if (httpXForwardedFor != null && httpXForwardedFor.Trim().Length > 0)
                {
                    string[] strFromIP = httpXForwardedFor.Trim().Split(',');
                    for (int i = 0; i < strFromIP.Length; i++)
                    {
                        if (RegexService.IsMatch(
                            strFromIP[i], RegexPattern.IpAddress))
                        {
                            result = strFromIP[i];
                            break;
                        }
                    }
                }

                string httpVia = HttpContext.Current.Request.ServerVariables["HTTP_VIA"] as string;
                if (result == "未知" && httpVia != null && httpVia.Trim().Length > 0)
                {
                    result = httpVia;
                }

                string remoteAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] as string;
                if (result == "未知" && remoteAddr != null && remoteAddr.Trim().Length > 0)
                {
                    result = remoteAddr;
                }

                if (result == "未知" && HttpContext.Current.Request.UserHostName.Trim().Length > 0)
                {
                    if (RegexService.IsMatch(HttpContext.Current.Request.UserHostName,
                        RegexPattern.IpAddress))
                    {
                        result = HttpContext.Current.Request.UserHostName;
                    }
                    else
                    {
                        IPAddress[] ipAddr = Dns.GetHostAddresses(HttpContext.Current.Request.UserHostName);
                        for (int i = 0; i < ipAddr.Length; i++)
                        {
                            if (RegexService.IsMatch(ipAddr[i].ToString(), RegexPattern.IpAddress))
                            {
                                result = ipAddr[i].ToString();
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                result = "未知";
            }
            return result;
        }
        #endregion

        #region 获取当前时间到指定时间相差的秒数
        /// <summary>
        /// 获取当前时间到指定时间相差的秒数
        /// </summary>
        /// <param name="appointedDateTime">指定的时间</param>
        /// <param name="dateTimeType">当前时间的类型</param>
        /// <param name="dateTimeRetType">返回的类型（返回的是秒还是毫秒）</param>
        /// <returns>当前时间到指定时间相差的秒数</returns>
        //public static double GetTimeInterval(UEnum.TimestampStartTime appointedDateTime,
        //    UEnum.DateTimeType dateTimeType, UEnum.DateTimeRetType dateTimeRetType)
        //{
        //    //初始化日期
        //    DateTime dt = new DateTime();
        //    switch (appointedDateTime)
        //    {
        //        case UEnum.TimestampStartTime.Year1970:
        //            dt = Convert.ToDateTime(UConstColl.YEAR1970);
        //            break;
        //        default:
        //            dt = Convert.ToDateTime(UConstColl.YEAR2000);
        //            break;
        //    }

        //    return GetTimeInterval(dt, dateTimeType, dateTimeRetType);
        //}
        #endregion

        #region 获取当前时间到指定时间相差的秒数
        /// <summary>
        /// 获取当前时间到指定时间相差的秒数
        /// </summary>
        /// <param name="dt">指定的时间</param>
        /// <param name="dateTimeType">当前时间的类型</param>
        /// <param name="dateTimeRetType">返回的类型（返回的是秒还是毫秒）</param>
        /// <returns>当前时间到指定时间相差的秒数</returns>
        //public static double GetTimeInterval(DateTime dt, UEnum.DateTimeType dateTimeType,
        //    UEnum.DateTimeRetType dateTimeRetType)
        //{
        //    if (DateTime.UtcNow < dt || DateTime.Now < dt)
        //    {
        //        throw new DateTimeIsGreaterThanNowException();
        //    }

        //    TimeSpan tsInterval = new TimeSpan();
        //    //计算当前日期到初始日期相差的秒数
        //    switch (dateTimeType)
        //    {
        //        case UEnum.DateTimeType.UTCNow:
        //            tsInterval = DateTime.UtcNow - dt;
        //            break;
        //        default:
        //            tsInterval = DateTime.Now - dt;
        //            break;
        //    }

        //    double dInterval = 0;

        //    switch (dateTimeRetType)
        //    {
        //        case UEnum.DateTimeRetType.Millisecond:
        //            dInterval = tsInterval.TotalMilliseconds;
        //            break;
        //        default:
        //            dInterval = tsInterval.TotalSeconds;
        //            break;
        //    }

        //    return dInterval;
        //}
        #endregion

        #region Html代码上的Ascii字符转换函数
        /// <summary>
        /// Html代码上的Ascii字符转换函数
        /// </summary>
        /// <param name="strInput">要转换的字符串</param>
        /// <returns>转换后的结果</returns>
        public static string AsciiToChar(string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
            {
                throw new HtmlInputIsNullOrEmptyException();
            }

            string retStr = strInput;
            //如：&#56;转换成8
            MatchCollection Matches;
            Matches = Regex.Matches(retStr, @"&#(\d+)?;", RegexOptions.Compiled);

            if (Matches.Count > 0)
            {
                for (int i = 0; i < Matches.Count; i++)
                {
                    retStr = Regex.Replace(retStr, Matches[i].Groups[0].Value,
                        Convert.ToChar(Convert.ToInt32(Matches[i].Groups[1].Value)).ToString());
                }

            }
            return retStr;
        }
        #endregion

        #region 获取当前请求页面的虚拟根路径
        /// <summary>
        /// 获取当前请求页面的虚拟根路径（带有/符号）（如：http://win.139.com/）
        /// </summary>
        /// <returns>绝对URL路径</returns>
        public static string GetRootUri()
        {
            string AppPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            HttpRequest Req;
            if (HttpCurrent != null)
            {
                Req = HttpCurrent.Request;

                string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
                if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                {
                    //直接安装在   Web   站点   
                    AppPath = UrlAuthority + "/";
                }
                else
                {
                    //安装在虚拟子目录下   
                    AppPath = UrlAuthority + Req.ApplicationPath + "/";
                }
            }
            return AppPath;
        }
        #endregion

        #region 获取请求页面的虚拟根路径
        /// <summary>
        /// 获取请求页面的虚拟根路径（带有/符号）（如：http://win.139.com/）
        /// </summary>
        /// <param name="Req">HttpRequest</param>
        /// <returns>绝对URL路径</returns>
        public static string GetRootUri(HttpRequest Req)
        {
            string AppPath = "";
            if (Req != null)
            {
                string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
                if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                {
                    //直接安装在   Web   站点   
                    AppPath = UrlAuthority + "/";
                }
                else
                {
                    //安装在虚拟子目录下   
                    AppPath = UrlAuthority + Req.ApplicationPath + "/";
                }
            }
            return AppPath;
        }
        #endregion

        #region 获取当前请求页面的Url的文件名的前部分
        /// <summary>
        /// 获取当前请求页面的Url的文件名的前部分（不带文件名和任何参数，但带有/符号）（如：http://win.139.com/aaa/bbb/）
        /// </summary>
        /// <returns>绝对URL路径</returns>
        public static string GetForesideUri()
        {
            //获取绝对URI
            string urlPath = HttpContext.Current.Request.Url.AbsoluteUri;
            int lastIndexOfUrlPath = urlPath.LastIndexOf("/");
            return urlPath.Remove(lastIndexOfUrlPath + 1, urlPath.Length - lastIndexOfUrlPath - 1);
        }
        #endregion

        #region 获取当前请求页面的完整Url
        /// <summary>
        /// 获取当前请求页面的完整Url（带文件名和参数）
        /// </summary>
        /// <returns>当前请求页面的完整Url</returns>
        public static string GetAbsoluteUriPath()
        {
            //获取绝对URI
            return HttpContext.Current.Request.Url.AbsoluteUri;
        }
        #endregion

        #region 取得网站根目录的物理路径
        /// <summary>
        /// 取得网站根目录的物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetRootPath()
        {
            string AppPath = "";

            HttpContext HttpCurrent = HttpContext.Current;

            if (HttpCurrent != null)
            {
                AppPath = HttpCurrent.Server.MapPath("~");
            }
            else
            {
                AppPath = AppDomain.CurrentDomain.BaseDirectory;

                if (Regex.Match(AppPath, @"\\$", RegexOptions.Compiled).Success)
                {
                    AppPath = AppPath.Substring(0, AppPath.Length - 1);
                }
            }
            return AppPath;
        }
        #endregion

        #region 把字符串的Encoding转换成Encoding类型
        /// <summary>
        /// 把字符串的Encoding转换成Encoding类型
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static Encoding GetEncodingForString(string encoding)
        {
            Encoding retEncoding = null;

            switch (encoding.ToUpper())
            {
                case "UTF-8":
                    retEncoding = Encoding.UTF8;
                    break;
                case "UTF8":
                    retEncoding = Encoding.UTF8;
                    break;
                default:
                    retEncoding = Encoding.Default;
                    break;
            }

            return retEncoding;
        }
        #endregion



        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="msg"></param>
        public static void Alert(Page p,string msg)
        {
            //System.Web.HttpContext.Current.Response.Write("<script>alert('" + msg + "')</script>");
            p.ClientScript.RegisterStartupScript(p.GetType(), "", "<script>alert('" + msg + "')</script>");
        }


        public static void AlertAndRedirect(Page p,string msg, string url)
        {
            //System.Web.HttpContext.Current.Response.Write("<script>alert('" + msg + "');location.href='" + url + "';</script>");
            p.ClientScript.RegisterStartupScript(p.GetType(), "", "<script>alert('" + msg + "');location.href='" + url + "';</script>");
        }

        //public static void Redirect(string url)
        //{
        //    System.Web.HttpContext.Current.Response.Redirect(url);
        //}

        public static void Redirect(System.Web.UI.Page page, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript'>");
            Builder.AppendFormat("window.parent.fm.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }

        /// <summary>
        /// 弹出窗口
        /// </summary>
        /// <param name="p"></param>
        /// <param name="url"></param>
        public static void Open(Page p,string url)
        {
            p.ClientScript.RegisterStartupScript(p.GetType(), "", "<script>window.open('" + url + "','newwindow');</script>");
        }


        //获取数据服务器时间
        public static DateTime GetDataBaseTime()
        {
            //string sql = "SELECT GETDATE()";
            //object result = DbHelperSQL. SqlHelper.ExecuteScalar(sql);
            //return Convert.ToDateTime(result);
            return DateTime.Now;
        }

        // onClick="WdatePicker()"


        ///// <summary>
        ///// 显示消息提示对话框
        ///// </summary>
        ///// <param name="page">当前页面指针，一般为this</param>
        ///// <param name="msg">提示信息</param>
        //public static void Show(System.Web.UI.Page page, string msg)
        //{
        //    page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        //}

        ///// <summary>
        ///// 控件点击 消息确认提示框
        ///// </summary>
        ///// <param name="page">当前页面指针，一般为this</param>
        ///// <param name="msg">提示信息</param>
        //public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        //{
        //    //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
        //    Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        //}

        ///// <summary>
        ///// 显示消息提示对话框，并进行页面跳转
        ///// </summary>
        ///// <param name="page">当前页面指针，一般为this</param>
        ///// <param name="msg">提示信息</param>
        ///// <param name="url">跳转的目标URL</param>
        //public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        //{
        //    StringBuilder Builder = new StringBuilder();
        //    Builder.Append("<script language='javascript' defer>");
        //    Builder.AppendFormat("alert('{0}');", msg);
        //    Builder.AppendFormat("window.location.href='{0}'", url);
        //    Builder.Append("</script>");
        //    page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        //}

        //public static void TopShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        //{
        //    StringBuilder Builder = new StringBuilder();
        //    Builder.Append("<script language='javascript' defer>");
        //    Builder.AppendFormat("alert('{0}');", msg);
        //    Builder.AppendFormat("top.location.href='{0}'", url);
        //    Builder.Append("</script>");
        //    page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        //}


        ///// <summary>
        ///// 输出自定义脚本信息
        ///// </summary>
        ///// <param name="page">当前页面指针，一般为this</param>
        ///// <param name="script">输出脚本</param>
        //public static void ResponseScript(System.Web.UI.Page page, string script)
        //{
        //    page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");

        //}



    }
}
