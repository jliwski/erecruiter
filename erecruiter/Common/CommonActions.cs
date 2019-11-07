using OpenQA.Selenium;

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