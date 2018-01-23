using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumTemplate
{
    public class PropertiesManager
    {
        private static DesiredCapabilities capabilities;

        public static void SetCapabilities(DesiredCapabilities capabilities)
        {
            PropertiesManager.capabilities = capabilities;
        }

        public static Platform GetPlatform()
        {
            if (capabilities == null)
            {
                throw new Exception("You did not set capabilities");
            }

            return capabilities.Platform;
        }

        public static string GetBrowserName()
        {
            if (capabilities == null)
            {
                throw new Exception("You did not set capabilities");
            }

            return capabilities.BrowserName;
        }

        public static Boolean IsRemote()
        {
            return System.Environment.GetEnvironmentVariable("remote").Equals("true");
        }

        public static DesiredCapabilities GetCapabilities()
        {
            return capabilities;
        }
    }
}
