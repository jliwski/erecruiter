//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using OpenQA.Selenium;
//using NUnit.Framework;

namespace erecruiter.Common
{
    class CommonActions
    {

        private IWebDriver driver;

        public CommonActions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void openURL(string url)
        {
            driver.Url = url;
            driver.Manage().Window.Maximize();
        }




}
}