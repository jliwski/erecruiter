//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using OpenQA.Selenium;
using NUnit.Framework;

namespace erecruiter.Pages
{
    class ThankYouPage
    {

        private IWebDriver driver;

        public ThankYouPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void assertSuccessfulApplication()
        {
            StringAssert.Contains("Dziękujemy za wypełnienie formularza.", driver.FindElement(By.XPath("//body")).Text);
        }

    }
}