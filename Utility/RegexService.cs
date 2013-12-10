    using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace Utility
{

    /// <summary>
    /// 正则表达式的配置
    /// </summary>
    internal static class RegexService
    {
        /// <summary>
        /// RegexConfig.xml配置文件里的mobile的节点的xPath
        /// </summary>
        internal const string XPATH_REGEXCONFIG_MOBILE = "/regexconfig/mobile";

        /// <summary>
        /// RegexConfig.xml配置文件里的mail139alias的节点的xPath
        /// </summary>
        internal const string XPATH_REGEXCONFIG_MAIL139ALIAS = "/regexconfig/mail139alias";

        /// <summary>
        /// RegexConfig.xml配置文件里的mobile139alias的节点的xPath
        /// </summary>
        internal const string XPATH_REGEXCONFIG_MOBILE139ALIAS = "/regexconfig/mobile139alias";

        /// <summary>
        /// RegexConfig.xml配置文件里的mailpassword的节点的xPath
        /// </summary>
        internal const string XPATH_REGEXCONFIG_MAILPASSWORD = "/regexconfig/mailpassword";

        /// <summary>
        /// RegexConfig.xml配置文件里的mailaddress的节点的xPath
        /// </summary>
        internal const string XPATH_REGEXCONFIG_MAILADDRESS = "/regexconfig/mailaddress";

        /// <summary>
        /// RegexConfig.xml配置文件里的chinaphone的节点的xPath
        /// </summary>
        internal const string XPATH_REGEXCONFIG_CHINAPHONE = "/regexconfig/chinaphone";

        /// <summary>
        /// RegexConfig.xml配置文件里的chinaidcard的节点的xPath
        /// </summary>
        internal const string XPATH_REGEXCONFIG_CHINAIDCARD = "/regexconfig/chinaidcard";

        /// <summary>
        /// RegexConfig.xml配置文件里的zipcode的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_ZIPCODE = "/regexconfig/zipcode";

        /// <summary>
        /// RegexConfig.xml配置文件里的ipaddress的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_IPADDRESS = "/regexconfig/ipaddress";

        /// <summary>
        /// RegexConfig.xml配置文件里的url的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_URL = "/regexconfig/url";

        /// <summary>
        /// RegexConfig.xml配置文件里的filename的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_FILENAME = "/regexconfig/filename";

        /// <summary>
        /// RegexConfig.xml配置文件里的path的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_PATH = "/regexconfig/path";

        /// <summary>
        /// RegexConfig.xml配置文件里的numbercomma的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_NUMBERCOMMA = "/regexconfig/numbercomma";

        /// <summary>
        /// RegexConfig.xml配置文件里的number的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_NUMBER = "/regexconfig/number";

        /// <summary>
        /// RegexConfig.xml配置文件里的chinese的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_CHINESE = "/regexconfig/chinese";

        /// <summary>
        /// RegexConfig.xml配置文件里的letter的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_LETTER = "/regexconfig/letter";

        /// <summary>
        /// RegexConfig.xml配置文件里的letternumberunderline的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_LETTERNUMBERUNDERLINE = "/regexconfig/letternumberunderline";

        /// <summary>
        /// RegexConfig.xml配置文件里的yyyyMM的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_YYYYMM = "/regexconfig/yyyymm";

        /// <summary>
        /// RegexConfig.xml配置文件里的SBCCheck的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_SBC = "/regexconfig/sbccheck";

        /// <summary>
        /// RegexConfig.xml配置文件里的SpNumber的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_SPNUMBER = "/regexconfig/spnumber";

        /// <summary>
        /// RegexConfig.xml配置文件里的VerifyCode的节点的xPath
        /// </summary>
        internal const string XPATH_APPCONFIG_VERIFYCODE = "/regexconfig/verifycode";







        #region 正则表达式匹配，返回是否匹配成功，只匹配从头到尾的方式
        /// <summary>
        /// 正则表达式匹配，返回是否匹配成功，只匹配从头到尾的方式
        /// </summary>
        /// <param name="input">要匹配的字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <returns>true表示匹配正确，false表示匹配失败</returns>
        public static bool IsMatch(string input, RegexPattern pattern)
        {
            string regexPattern = string.Empty;

            regexPattern = RegexService.GetPattern(pattern);

            return IsMatch(input, regexPattern);
        }
        #endregion

        #region 正则表达式匹配，返回是否匹配成功，只匹配从头到尾的方式
        /// <summary>
        /// 正则表达式匹配，返回是否匹配成功，只匹配从头到尾的方式
        /// </summary>
        /// <param name="input">要匹配的字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <returns>true表示匹配正确，false表示匹配失败</returns>
        public static bool IsMatch(string input, string pattern)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new MatchInputIsNullOrEmptyException();
            }

            if (string.IsNullOrEmpty(pattern))
            {
                throw new MatchPatternIsNullOrEmptyException();
            }

            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }
        #endregion



        #region 获取正则表达式配置文档
        /// <summary>
        /// 获取正则表达式配置文档
        /// </summary>
        /// <returns>XML文档</returns>
        internal static XmlDocument GetRegexServiceDoc()
        {
            XmlDocument xmlDoc = null;

            //从Cache里取出RegexService.xml文档对象
            xmlDoc = CacheService.GetCache(
                CacheService.REGEXCONFIG_DOCUMENT_CACHENAME) as XmlDocument;

            if (xmlDoc == null)
            {
                string strRegexServicePath = ConfigService.GetRegexConfigPath();

                //判断RegexService.xml是否存在
                if (!File.Exists(strRegexServicePath))
                {
                    throw new RegexServiceFileNotExistException();
                }

                xmlDoc = XMLService.GetXml(strRegexServicePath);

                //写入缓存并与文件相关连
                CacheService.Insert(
                    CacheService.REGEXCONFIG_DOCUMENT_CACHENAME,
                    xmlDoc, strRegexServicePath);
            }

            return xmlDoc;
        }
        #endregion

        #region 获取正则表达式
        /// <summary>
        /// 获取正则表达式
        /// </summary>
        /// <param name="pattern">正则表达式</param>
        /// <returns>正则表达式</returns>
        internal static string GetPattern(RegexPattern pattern)
        {
            string regexPattern = string.Empty;
            switch (pattern)
            {
                case RegexPattern.Mobile:
                    regexPattern = RegexService.GetMobileRegex();
                    break;
                case RegexPattern.Mail139Alias:
                    regexPattern = RegexService.GetMail139AliasRegex();
                    break;
                case RegexPattern.Mobile139Alias:
                    regexPattern = RegexService.GetMobile139AliasRegex();
                    break;
                case RegexPattern.MailPassword:
                    regexPattern = RegexService.GetMailPasswordRegex();
                    break;
                case RegexPattern.MailAddress:
                    regexPattern = RegexService.GetMailAddressRegex();
                    break;
                case RegexPattern.ChinaPhone:
                    regexPattern = RegexService.GetChinaPhoneRegex();
                    break;
                case RegexPattern.ChinaIDCard:
                    regexPattern = RegexService.GetChinaIDCardRegex();
                    break;
                case RegexPattern.ZipCode:
                    regexPattern = RegexService.GetZipCodeRegex();
                    break;
                case RegexPattern.IpAddress:
                    regexPattern = RegexService.GetIpAddressRegex();
                    break;
                case RegexPattern.Url:
                    regexPattern = RegexService.GetUrlRegex();
                    break;
                case RegexPattern.FileName:
                    regexPattern = RegexService.GetFileNameRegex();
                    break;
                case RegexPattern.Path:
                    regexPattern = RegexService.GetPathRegex();
                    break;
                case RegexPattern.NumberComma:
                    regexPattern = RegexService.GetNumberCommaRegex();
                    break;
                case RegexPattern.Number:
                    regexPattern = RegexService.GetNumberRegex();
                    break;
                case RegexPattern.Chinese:
                    regexPattern = RegexService.GetChineseRegex();
                    break;
                case RegexPattern.Letter:
                    regexPattern = RegexService.GetLetterRegex();
                    break;
                case RegexPattern.LetterNumberUnderline:
                    regexPattern = RegexService.GetLetterNumberUnderlineRegex();
                    break;
                case RegexPattern.yyyyMM:
                    regexPattern = RegexService.GetYYYYMMRegex();
                    break;
                case RegexPattern.SBCCheck:
                    regexPattern = RegexService.GetSBCRegex();
                    break;
                case RegexPattern.SpNumber:
                    regexPattern = RegexService.GetSpNumberRegex();
                    break;
                case RegexPattern.VerifyCode:
                    regexPattern = RegexService.GetVerifyCodeRegex();
                    break;
            }

            return regexPattern;
        }
        #endregion

        #region 获取正则表达式
        /// <summary>
        /// 获取正则表达式
        /// </summary>
        /// <param name="xPath">正则表达式</param>
        /// <returns>正则表达式</returns>
        internal static string GetPattern(string xPath)
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc, xPath);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证手机号码的正则表达式
        /// <summary>
        /// 获取验证手机号码的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetMobileRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_REGEXCONFIG_MOBILE);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证139邮箱别名的正则表达式
        /// <summary>
        /// 获取验证139邮箱别名的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetMail139AliasRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_REGEXCONFIG_MAIL139ALIAS);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证139邮箱别名或手机号码的正则表达式
        /// <summary>
        /// 获取验证139邮箱别名或手机号码的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetMobile139AliasRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_REGEXCONFIG_MOBILE139ALIAS);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证139邮箱密码的正则表达式
        /// <summary>
        /// 获取验证139邮箱密码的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetMailPasswordRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_REGEXCONFIG_MAILPASSWORD);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证邮箱地址的正则表达式
        /// <summary>
        /// 获取验证邮箱地址的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetMailAddressRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_REGEXCONFIG_MAILADDRESS);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证国内固话或小灵通的正则表达式（带区号）
        /// <summary>
        /// 获取验证国内固话或小灵通的正则表达式（带区号）
        /// </summary>
        /// <returns></returns>
        private static string GetChinaPhoneRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_REGEXCONFIG_CHINAPHONE);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证中国身份证的正则表达式
        /// <summary>
        /// 获取验证中国身份证的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetChinaIDCardRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_REGEXCONFIG_CHINAIDCARD);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证邮编的正则表达式
        /// <summary>
        /// 获取验证邮编的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetZipCodeRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_ZIPCODE);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证IP地址的正则表达式
        /// <summary>
        /// 获取验证IP地址的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetIpAddressRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_IPADDRESS);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证URL的正则表达式
        /// <summary>
        /// 获取验证URL的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetUrlRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_URL);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证FileName的正则表达式
        /// <summary>
        /// 获取验证FileName的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetFileNameRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_FILENAME);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证Path的正则表达式
        /// <summary>
        /// 获取验证Path的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetPathRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_PATH);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证NumberComma的正则表达式
        /// <summary>
        /// 获取验证NumberComma的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetNumberCommaRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_NUMBERCOMMA);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证Number的正则表达式
        /// <summary>
        /// 获取验证Number的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetNumberRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_NUMBER);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证Chinese的正则表达式
        /// <summary>
        /// 获取验证Chinese的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetChineseRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_CHINESE);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证Letter的正则表达式
        /// <summary>
        /// 获取验证Letter的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetLetterRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_LETTER);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证LetterNumberUnderline的正则表达式
        /// <summary>
        /// 获取验证LetterNumberUnderline的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetLetterNumberUnderlineRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_LETTERNUMBERUNDERLINE);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取年月的正则表达式
        /// <summary>
        /// 获取年月的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetYYYYMMRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_YYYYMM);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取SBC check的正则表达式
        /// <summary>
        /// 获取SBC check的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetSBCRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_SBC);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证SpNumber的正则表达式
        /// <summary>
        /// 获取验证SpNumber的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetSpNumberRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_SPNUMBER);

            return node.InnerText.Trim();
        }
        #endregion

        #region 获取验证VerifyCode的正则表达式
        /// <summary>
        /// 获取验证VerifyCode的正则表达式
        /// </summary>
        /// <returns></returns>
        private static string GetVerifyCodeRegex()
        {
            XmlDocument xmlDoc = GetRegexServiceDoc();

            XmlNode node = XMLService.GetSingleNode(xmlDoc,
                XPATH_APPCONFIG_VERIFYCODE);

            return node.InnerText.Trim();
        }
        #endregion
    }
}
