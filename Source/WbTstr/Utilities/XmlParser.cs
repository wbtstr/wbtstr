using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using WbTstr.Configuration.WebDrivers;

namespace WbTstr.Utilities
{
    public static class XmlParser
    {
        public static XmlNode GetSectionByName(string tagName, string presetName)
        {
            string dllLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(dllLocation, "WbTstr.config");

            var configDoc = new XmlDocument();
            configDoc.Load(filePath);

            return configDoc.SelectSingleNode($"//{tagName}[@name='{presetName}']");
        }

        public static Dictionary<string, T> KeyValuePairsToDictionary<T>(XmlNodeList nodes, string keyName = "key", string valueName = "value")
        {
            var dictionary = new Dictionary<string, T>();
            foreach (XmlNode node in nodes)
            {
                var key = node.Attributes[keyName]?.Value;
                var value = node.Attributes[valueName]?.Value;

                if (!string.IsNullOrWhiteSpace(key))
                {
                    dictionary.Add(key, (T)Convert.ChangeType(value, typeof(T)));
                }
            }

            return dictionary;
        }

        public static WebDriverProxyConfig XmlNodeToProxyConfig(XmlNode node)
        {
            if (node == null)
            {
                return null;
            }

            return new WebDriverProxyConfig
            {
                Kind = node.Attributes["kind"]?.Value,
                IsAutoDetect = Convert.ToBoolean(node.Attributes["isAutoDetect"]?.Value),
                FtpProxy = node.SelectSingleNode("ftpProxy").InnerText,
                HttpProxy = node.SelectSingleNode("httpProxy").InnerText,
                NoProxy = node.SelectSingleNode("noProxy").InnerText,
                ProxyAutoConfigUrl = node.SelectSingleNode("proxyAutoConfigUrl").InnerText,
                SslProxy = node.SelectSingleNode("sslProxy").InnerText,
                SocksProxy = node.SelectSingleNode("socksProxy").InnerText,
                SocksUsername = node.SelectSingleNode("socksUsername").InnerText,
                SocksPassword = node.SelectSingleNode("socksPassword").InnerText
            };
        }
    }
}
