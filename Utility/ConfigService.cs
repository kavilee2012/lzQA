using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Utility
{
    public class ConfigService
    {
        /// <summary>
        /// 应用程序配置文件相对于程序集的位置
        /// </summary>
        internal const string APPCONFIG_PATH = @"bin\AppConfig.xml";

        #region 项目信息节点
        /// <summary>
        /// AppConfig.xml配置文件里的项目信息节点下的项目名称的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_PROJECTINFO_PROJECTNAME = "/appconfig/projectinfo/projectname";

        /// <summary>
        /// AppConfig.xml配置文件里的项目信息节点下的项目编号的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_PROJECTINFO_PROJECTCODE = "/appconfig/projectinfo/projectcode";
        #endregion

        #region 据库配置节点

        /// <summary>
        /// AppConfig.xml配置文件里的数据库配置节点下的数据库配置文件路径的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_DBCONFIG_PATH = "/appconfig/dbconfig/path";

        /// <summary>
        /// AppConfig.xml配置文件里的数据库节点下的数据库配置文件版本的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_DBCONFIG_VERSION = "/appconfig/dbconfig/version";
        #endregion

        #region 日志配置节点
        /// <summary>
        /// AppConfig.xml配置文件里的应用程序日志配置节点下的项目类型的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_PROJECTLOG_PROJECTTYPE = "/appconfig/projectlog/projecttype";

        /// <summary>
        /// AppConfig.xml配置文件里的应用程序日志配置节点下的日志配置文件路径的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_PROJECTLOG_PATH = "/appconfig/projectlog/path";

        /// <summary>
        /// AppConfig.xml配置文件里的应用程序日志配置节点下的日志配置文件版本的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_PROJECTLOG_VERSION = "/appconfig/projectlog/version";
        #endregion

        #region SSO的配置节点
        /// <summary>
        /// AppConfig.xml配置文件里的SSO配置节点下的写SSO日志的标识的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_SSOCONFIG_WRITELOGSFLAG = "/appconfig/ssoconfig/writelogsflag";

        /// <summary>
        /// AppConfig.xml配置文件里的SSO配置节点下的文件路径的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_SSOCONFIG_PATH = "/appconfig/ssoconfig/path";

        /// <summary>
        /// AppConfig.xml配置文件里的SSO配置节点下的文件版本的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_SSOCONFIG_VERSION = "/appconfig/ssoconfig/version";
        #endregion

        #region 活动时间控制配置节点
        /// <summary>
        /// AppConfig.xml配置文件里的活动时间控制配置节点下的活动时间控制状态的节点xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_WEBCONTROL_TIMESTATE = "/appconfig/webcontrol/timestate";

        /// <summary>
        /// AppConfig.xml配置文件里的活动时间控制配置节点下的活动开始时间的节点xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_WEBCONTROL_STARTTIME = "/appconfig/webcontrol/starttime";

        /// <summary>
        /// AppConfig.xml配置文件里的活动时间控制配置节点下的活动结束时间的节点xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_WEBCONTROL_ENDTIME = "/appconfig/webcontrol/endtime";

        /// <summary>
        /// AppConfig.xml配置文件里的活动时间控制配置节点下的逻辑处理标识的节点xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_WEBCONTROL_RETFLAG = "/appconfig/webcontrol/retflag";

        /// <summary>
        /// AppConfig.xml配置文件里的活动时间控制配置节点下的跳转的URL或需要显示的信息的节点xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_WEBCONTROL_RETINFO = "/appconfig/webcontrol/retinfo";
        #endregion

        #region 接口的配置节点
        /// <summary>
        /// AppConfig.xml配置文件里的接口配置节点下的接口配置文件路径的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_APICONFIG_PATH = "/appconfig/apiconfig/path";

        /// <summary>
        /// AppConfig.xml配置文件里的接口配置节点下的接口配置文件版本的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_APICONFIG_VERSION = "/appconfig/apiconfig/version";
        #endregion

        #region 邮件的配置节点
        /// <summary>
        /// AppConfig.xml配置文件里的邮件配置节点下的文件路径的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_MAILCONFIG_PATH = "/appconfig/mailconfig/path";

        /// <summary>
        /// AppConfig.xml配置文件里的邮件配置节点下的文件版本的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_MAILCONFIG_VERSION = "/appconfig/mailconfig/version";
        #endregion

        #region 短信的配置节点
        /// <summary>
        /// AppConfig.xml配置文件里的短信配置节点下的文件路径的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_SMSCONFIG_PATH = "/appconfig/smsconfig/path";

        /// <summary>
        /// AppConfig.xml配置文件里的短信配置节点下的文件版本的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_SMSCONFIG_VERSION = "/appconfig/smsconfig/version";
        #endregion

        #region 验证码的配置节点
        /// <summary>
        /// AppConfig.xml配置文件里的验证码配置节点下的文件路径的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_VERIFYCODECONFIG_PATH = "/appconfig/verifycodeconfig/path";

        /// <summary>
        /// AppConfig.xml配置文件里的验证码配置节点下的文件版本的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_VERIFYCODECONFIG_VERSION = "/appconfig/verifycodeconfig/version";
        #endregion

        #region 过滤关键字的配置节点
        /// <summary>
        /// AppConfig.xml配置文件里的过滤关键字配置节点下的文件路径的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_FILTERWORDSCONFIG_PATH = "/appconfig/filterwordsconfig/path";

        /// <summary>
        /// AppConfig.xml配置文件里的过滤关键字配置节点下的文件版本的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_FILTERWORDSCONFIG_VERSION = "/appconfig/filterwordsconfig/version";
        #endregion

        #region 正则表达式的配置节点
        /// <summary>
        /// AppConfig.xml配置文件里的正则表达式配置节点下的正则表达式配置文件路径的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_REGEXCONFIG_PATH = "/appconfig/regexconfig/path";

        /// <summary>
        /// AppConfig.xml配置文件里的正则表达式配置节点下的正则表达式配置文件版本的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_REGEXCONFIG_VERSION = "/appconfig/regexconfig/version";
        #endregion

        #region MemCached的配置节点
        /// <summary>
        /// AppConfig.xml配置文件里的MemCached配置节点下的文件路径的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_MEMCACHEDCONFIG_PATH = "/appconfig/memcachedconfig/path";

        /// <summary>
        /// AppConfig.xml配置文件里的正则表达式配置节点下的文件版本的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_MEMCACHEDCONFIG_VERSION = "/appconfig/memcachedconfig/version";
        #endregion


        #region 获取AppConfig.xml的路径
        /// <summary>
        /// 获取AppConfig.xml的路径
        /// </summary>
        /// <returns>路径</returns>
        public static string GetAppConfigPath()
        {
            string strAppConfigPath = string.Empty;

            //从Cache里取出应用程序路径
            strAppConfigPath = CacheService.GetCache(
                CacheService.APPCONFIG_PATH_CACHENAME) as string;

            //如果应用程序不存在则重新读取
            if (string.IsNullOrEmpty(strAppConfigPath))
            {
                string strTemp = System.AppDomain.CurrentDomain.BaseDirectory.ToString().Trim()
                    + APPCONFIG_PATH;

                strAppConfigPath = strTemp;

                //写入永久缓存
                CacheService.Insert(
                    CacheService.APPCONFIG_PATH_CACHENAME, strAppConfigPath);
            }

            return strAppConfigPath;
        }
        #endregion

        #region 获取应用程序配置文档
        /// <summary>
        /// 获取应用程序配置文档
        /// </summary>
        /// <returns>XML文档</returns>
        public static XmlDocument GetAppConfigDoc()
        {
            XmlDocument xmlDoc = null;

            //从Cache里取出AppConfig.xml文档对象
            xmlDoc = CacheService.GetCache(
                CacheService.APPCONFIG_DOCUMENT_CACHENAME) as XmlDocument;

            if (xmlDoc == null)
            {
                string strAppConfigPath = GetAppConfigPath();

                //判断AppConfig.xml是否存在
                if (!File.Exists(strAppConfigPath))
                {
                    throw new AppConfigFileNotExistException();
                }

                xmlDoc = XMLService.GetXml(strAppConfigPath);

                //写入缓存并与文件相关连
                CacheService.Insert(
                    CacheService.APPCONFIG_DOCUMENT_CACHENAME,
                    xmlDoc, strAppConfigPath);
            }

            return xmlDoc;
        }
        #endregion

        //===================AppConfig.xml配置节点的获取===================

        //获取项目相关的配置
        #region 获取AppConfig.xml配置文件里的项目名称
        /// <summary>
        /// 获取AppConfig.xml配置文件里的项目名称
        /// </summary>
        /// <returns></returns>
        public static string GetProjectName()
        {
            XmlDocument xmlDoc = GetAppConfigDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_PROJECTINFO_PROJECTNAME);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取AppConfig.xml配置文件里的项目编号
        /// <summary>
        /// 获取AppConfig.xml配置文件里的项目编号
        /// </summary>
        /// <returns></returns>
        public static string GetProjectCode()
        {
            XmlDocument xmlDoc = GetAppConfigDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_PROJECTINFO_PROJECTCODE);

            return node.InnerText.Trim();
        }
        #endregion

        //获取数据库相关的配置
        #region 获取AppConfig.xml配置文件里的数据库配置文件的路径
        /// <summary>
        /// 获取AppConfig.xml配置文件里的数据库配置文件的路径
        /// </summary>
        /// <returns></returns>
        public static string GetDBConfigPath()
        {
            XmlDocument xmlDoc = GetAppConfigDoc();

            XmlNode pathNode = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_DBCONFIG_PATH);

            XmlNode versionNode = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_DBCONFIG_VERSION);

            string strDBConfigPath = string.Format(pathNode.InnerText.Trim(), versionNode.InnerText.Trim());

            return strDBConfigPath;
        }
        #endregion

        //获取应用程序日志相关的配置
        #region 获取AppConfig.xml配置文件里的日志配置文件的路径
        /// <summary>
        /// 获取AppConfig.xml配置文件里的日志配置文件的路径
        /// </summary>
        /// <returns></returns>
        public static string GetLogConfigPath()
        {
            XmlDocument xmlDoc = GetAppConfigDoc();

            XmlNode pathNode = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_PROJECTLOG_PATH);

            XmlNode versionNode = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_PROJECTLOG_VERSION);

            string strLogConfigPath = string.Format(pathNode.InnerText.Trim(), versionNode.InnerText.Trim());

            return strLogConfigPath;
        }
        #endregion


        //获取邮件相关的配置
        #region 获取AppConfig.xml配置文件里的邮件配置文件的路径
        /// <summary>
        /// 获取AppConfig.xml配置文件里的邮件配置文件的路径
        /// </summary>
        /// <returns></returns>
        public static string GetMailConfigPath()
        {
            XmlDocument xmlDoc = GetAppConfigDoc();

            //获取路径
            XmlNode pathNode = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_MAILCONFIG_PATH);

            //获取版本
            XmlNode versionNode = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_MAILCONFIG_VERSION);

            string strMailConfigPath = string.Format(pathNode.InnerText.Trim(), versionNode.InnerText.Trim());

            return strMailConfigPath;
        }
        #endregion

        //获取过滤关键字相关的配置
        #region 获取AppConfig.xml配置文件里的过滤关键字配置文件的路径
        /// <summary>
        /// 获取AppConfig.xml配置文件里的过滤关键字配置文件的路径
        /// </summary>
        /// <returns></returns>
        public static string GetFilterWordsConfigPath()
        {
            XmlDocument xmlDoc = GetAppConfigDoc();

            //获取路径
            XmlNode pathNode = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_FILTERWORDSCONFIG_PATH);

            //获取版本
            XmlNode versionNode = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_FILTERWORDSCONFIG_VERSION);

            string strFilterWordsConfigPath = string.Format(pathNode.InnerText.Trim(), versionNode.InnerText.Trim());

            return strFilterWordsConfigPath;
        }
        #endregion

        //获取正则表达式相关的配置
        #region 获取AppConfig.xml配置文件里的正则表达式配置文件的路径
        /// <summary>
        /// 获取AppConfig.xml配置文件里的正则表达式配置文件的路径
        /// </summary>
        /// <returns></returns>
        public static string GetRegexConfigPath()
        {
            XmlDocument xmlDoc = GetAppConfigDoc();

            //获取路径
            XmlNode pathNode = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_REGEXCONFIG_PATH);

            //获取版本
            XmlNode versionNode = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_REGEXCONFIG_VERSION);

            string strRegexServicePath = string.Format(pathNode.InnerText.Trim(), versionNode.InnerText.Trim());

            return strRegexServicePath;
        }
        #endregion

        //获取MemCached相关的配置
        #region 获取AppConfig.xml配置文件里的MemCached配置文件的路径
        /// <summary>
        /// 获取AppConfig.xml配置文件里的MemCached配置文件的路径
        /// </summary>
        /// <returns></returns>
        public static string GetMemCachedConfigPath()
        {
            XmlDocument xmlDoc = GetAppConfigDoc();

            //获取路径
            XmlNode pathNode = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_MEMCACHEDCONFIG_PATH);

            //获取版本
            XmlNode versionNode = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_MEMCACHEDCONFIG_VERSION);

            string strMemCachedConfigPath = string.Format(pathNode.InnerText.Trim(), versionNode.InnerText.Trim());

            return strMemCachedConfigPath;
        }
        #endregion
    }
}
