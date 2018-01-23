using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumTemplate
{
    public abstract class PageObject
    {
        public DriverManager driverManager = DriverManager.GetInstance();

        public PageObject()
        {
            driverManager.WaitForPageToLoad();
        }

        public abstract void Synchronize();

        public void WaitForElement(IWebElement element)
        {
            driverManager.WaitForElement(element);
        }
    }
}
