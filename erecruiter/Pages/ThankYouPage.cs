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