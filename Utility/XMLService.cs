using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Utility
{
    public class XMLService
    {
        #region 获取XML文档
        /// <summary>
        /// 获取XML文档
        /// </summary>
        /// <param name="path">XML文档所在的路径</param>
        /// <returns>XML文档</returns>
        public static XmlDocument GetXml(string path)
        {
            if (!File.Exists(path))
            {
                throw new XmlFileNotExistException();
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            return xmlDoc;
        }
        #endregion

        #region 根据xPath返回单个节点
        /// <summary>
        /// 根据xPath返回单个节点
        /// </summary>
        /// <param name="xmlDoc">XML文档对象</param>
        /// <param name="xPath">xPath</param>
        /// <returns>配置信息</returns>
        public static XmlNode GetSingleNode(XmlDocument xmlDoc, string xPath)
        {
            if (xmlDoc == null)
            {
                throw new XmlDocumentIsNullException();
            }

            if (string.IsNullOrEmpty(xPath))
            {
                throw new XPathIsNullOrEmptyException();
            }

            XmlNode node = xmlDoc.SelectSingleNode(xPath) as XmlNode;

            if (node == null)
            {
                throw new XmlNodeIsErrorException();
            }

            return node;
        }
        #endregion

        #region 根据xPath返回单个节点
        /// <summary>
        /// 根据xPath返回单个节点
        /// </summary>
        /// <param name="xmlNode">XML节点</param>
        /// <param name="xPath">xPath</param>
        /// <returns>配置信息</returns>
        public static XmlNode GetSingleNode(XmlNode xmlNode, string xPath)
        {
            if (xmlNode == null)
            {
                throw new XmlNodeIsNullException();
            }

            if (string.IsNullOrEmpty(xPath))
            {
                throw new XPathIsNullOrEmptyException();
            }

            XmlNode node = xmlNode.SelectSingleNode(xPath) as XmlNode;

            if (node == null)
            {
                throw new XmlNodeIsErrorException();
            }

            return node;
        }
        #endregion

        #region 根据xPath返回单个节点
        /// <summary>
        /// 根据xPath返回单个节点
        /// </summary>
        /// <param name="xmlDoc">XML文档对象</param>
        /// <param name="xPath">xPath</param>
        /// <param name="nsmgr">XmlNamespaceManager</param>
        /// <returns>配置信息</returns>
        public static XmlNode GetSingleNode(XmlDocument xmlDoc, string xPath, XmlNamespaceManager nsmgr)
        {
            if (xmlDoc == null)
            {
                throw new XmlDocumentIsNullException();
            }

            if (string.IsNullOrEmpty(xPath))
            {
                throw new XPathIsNullOrEmptyException();
            }

            XmlNode node = xmlDoc.SelectSingleNode(xPath, nsmgr) as XmlNode;

            if (node == null)
            {
                throw new XmlNodeIsErrorException();
            }

            return node;
        }
        #endregion

        #region 根据xPath返回单个节点
        /// <summary>
        /// 根据xPath返回单个节点
        /// </summary>
        /// <param name="xmlNode">XML节点</param>
        /// <param name="xPath">xPath</param>
        /// <param name="nsmgr">XmlNamespaceManager</param>
        /// <returns>配置信息</returns>
        public static XmlNode GetSingleNode(XmlNode xmlNode, string xPath, XmlNamespaceManager nsmgr)
        {
            if (xmlNode == null)
            {
                throw new XmlNodeIsNullException();
            }

            if (string.IsNullOrEmpty(xPath))
            {
                throw new XPathIsNullOrEmptyException();
            }

            XmlNode node = xmlNode.SelectSingleNode(xPath, nsmgr) as XmlNode;

            if (node == null)
            {
                throw new XmlNodeIsErrorException();
            }

            return node;
        }
        #endregion

        #region 根据xPath返回节点集合
        /// <summary>
        /// 根据xPath返回节点集合
        /// </summary>
        /// <param name="xmlDoc">XML文档对象</param>
        /// <param name="xPath">xPath</param>
        /// <returns>配置信息</returns>
        public static XmlNodeList GetNodes(XmlDocument xmlDoc, string xPath)
        {
            if (xmlDoc == null)
            {
                throw new XmlDocumentIsNullException();
            }

            if (string.IsNullOrEmpty(xPath))
            {
                throw new XPathIsNullOrEmptyException();
            }

            XmlNodeList nodes = xmlDoc.SelectNodes(xPath) as XmlNodeList;

            if (nodes == null)
            {
                throw new XmlNodeListIsErrorException();
            }

            return nodes;
        }
        #endregion

        #region 根据xPath返回节点集合
        /// <summary>
        /// 根据xPath返回节点集合
        /// </summary>
        /// <param name="xmlNode">XML节点</param>
        /// <param name="xPath">xPath</param>
        /// <returns>配置信息</returns>
        public static XmlNodeList GetNodes(XmlNode xmlNode, string xPath)
        {
            if (xmlNode == null)
            {
                throw new XmlNodeIsNullException();
            }

            if (string.IsNullOrEmpty(xPath))
            {
                throw new XPathIsNullOrEmptyException();
            }

            XmlNodeList nodes = xmlNode.SelectNodes(xPath) as XmlNodeList;

            if (nodes == null)
            {
                throw new XmlNodeListIsErrorException();
            }

            return nodes;
        }
        #endregion

        #region 根据xPath返回节点集合
        /// <summary>
        /// 根据xPath返回节点集合
        /// </summary>
        /// <param name="xmlDoc">XML文档对象</param>
        /// <param name="xPath">xPath</param>
        /// <param name="nsmgr">XmlNamespaceManager</param>
        /// <returns>配置信息</returns>
        public static XmlNodeList GetNodes(XmlDocument xmlDoc, string xPath, XmlNamespaceManager nsmgr)
        {
            if (xmlDoc == null)
            {
                throw new XmlDocumentIsNullException();
            }

            if (string.IsNullOrEmpty(xPath))
            {
                throw new XPathIsNullOrEmptyException();
            }

            XmlNodeList nodes = xmlDoc.SelectNodes(xPath, nsmgr) as XmlNodeList;

            if (nodes == null)
            {
                throw new XmlNodeListIsErrorException();
            }

            return nodes;
        }
        #endregion

        #region 根据xPath返回节点集合
        /// <summary>
        /// 根据xPath返回节点集合
        /// </summary>
        /// <param name="xmlNode">XML节点</param>
        /// <param name="xPath">xPath</param>
        /// <param name="nsmgr">XmlNamespaceManager</param>
        /// <returns>配置信息</returns>
        public static XmlNodeList GetNodes(XmlNode xmlNode, string xPath, XmlNamespaceManager nsmgr)
        {
            if (xmlNode == null)
            {
                throw new XmlNodeIsNullException();
            }

            if (string.IsNullOrEmpty(xPath))
            {
                throw new XPathIsNullOrEmptyException();
            }

            XmlNodeList nodes = xmlNode.SelectNodes(xPath, nsmgr) as XmlNodeList;

            if (nodes == null)
            {
                throw new XmlNodeListIsErrorException();
            }

            return nodes;
        }
        #endregion
    }
}
