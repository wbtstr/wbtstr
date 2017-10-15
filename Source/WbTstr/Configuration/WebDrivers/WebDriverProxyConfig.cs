using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.Configuration.WebDrivers
{
    public class WebDriverProxyConfig
    {
        public string Kind { get; set; }
        public bool IsAutoDetect { get; set; }
        public string FtpProxy { get; set; }
        public string HttpProxy { get; set; }
        public string NoProxy { get; set; }
        public string ProxyAutoConfigUrl { get; set; }
        public string SslProxy { get; set; }
        public string SocksProxy { get; set; }
        public string SocksUsername { get; set; }
        public string SocksPassword { get; set; }
    }
}
