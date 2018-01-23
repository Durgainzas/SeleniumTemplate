using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

namespace SeleniumTemplate
{
    public class DriverManager
    {
        private RemoteWebDriver driver;

        private static DriverManager instance;

        public static DriverManager GetInstance()
        {
            if (instance == null)
            {
                instance = new DriverManager();
            }

            return instance;
        }

        private DriverManager()
        {
            
        }

        public IWebDriver GetDriver()
        {
            if (driver != null)
            {
                return driver;
            }

            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:/tools/chromedriver.exe");

            if (PropertiesManager.IsRemote())
            {
                try
                {
                    Uri uri = new Uri(System.Environment.GetEnvironmentVariable("remoteURL"));
                    driver = new RemoteWebDriver(uri, PropertiesManager.GetCapabilities());
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
            else
            {
                Platform platform = PropertiesManager.GetPlatform();

                switch (platform.PlatformType)
                { 
                    default:
                        driver = new ChromeDriver();
                        break;
                }
            }

            string url = System.Environment.GetEnvironmentVariable("URL");

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            return driver;
        }

        public void WaitForElement(IWebElement element)
        {
            
        }

        public void WaitForPageToLoad()
        {

        }
    }
}
