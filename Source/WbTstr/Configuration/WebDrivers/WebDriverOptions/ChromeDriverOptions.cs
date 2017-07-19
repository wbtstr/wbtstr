using System.Collections.Specialized;
using System.Configuration;
using WbTstr.Configuration.WebDrivers.Exceptions;

namespace WbTstr.Configuration.WebDrivers.Options
{
    public class ChromeWebDriverOptions
    {
        private static NameValueCollection _section;

        public ChromeWebDriverOptions(string preset)
        {
            _section =  (NameValueCollection)ConfigurationManager.GetSection(preset);
            if (_section == null) throw new MissingWebDriverConfigSectionException(nameof(preset));
        }

        /*
         * Summary:
         * For an complete list of all the arguments please see <a hreft="https://peter.sh/experiments/chromium-command-line-switches/" />
         */
        public string Args { get { return _section["args"]; } }

        public string DebuggerAddress { get { return _section["debuggerAddress"]; } }
    }
}
