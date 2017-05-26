using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.Utilities
{
    public static class UriParser
    {
        public static Uri ParseWebUrl(string webUrl)
        {
            if (webUrl == null) throw new ArgumentNullException(nameof(webUrl));
            if (string.IsNullOrWhiteSpace(webUrl)) throw new ArgumentException(nameof(webUrl));

            if (Uri.TryCreate(webUrl, UriKind.Absolute, out Uri webUri) || Uri.TryCreate("http://" + webUrl, UriKind.Absolute, out webUri))
            {
                return webUri;
            }

            throw new UriFormatException($"'{webUrl}' couldn't be parsed as a URI.");
        }
    }
}
