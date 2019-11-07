using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;

namespace erecruiter.Pages
{
    class RecruitmentFormPage
    {

        private IWebDriver driver;

        public RecruitmentFormPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        string disableCookieInfoId = "disableCookieInfo";
        string inputTextNameId = "ctl00_DefaultContent_ctl17_tbName";
        string inputTextSurnameId = "ctl00_DefaultContent_ctl17_tbSurname";
        string inputTextEmailId = "ctl00_DefaultContent_ctl17_tbMail";
        string inputTextPhoneNoId = "ctl00_DefaultContent_ctl17_tbCellPhone";
        string selectListCountryId = "ctl00_DefaultContent_ctl31_lstCountries";
        string selectListRegionId = "ctl00_DefaultContent_ctl31_lstRegions";
        string inputTextCityId = "ctl00_DefaultContent_ctl31_tbCity";
        string uploadFileButtonId = "ctl00_DefaultContent_ctl45_fuCv";
        string sendButtonId = "ctl00_DefaultContent_bttnSend";

        public void disableCookieInfo()
        {
            driver.FindElement(By.Id(disableCookieInfoId)).Click();
        }

        public void inputName(string name)
        {
            driver.FindElement(By.Id(inputTextNameId)).Clear();
            driver.FindElement(By.Id(inputTextNameId)).SendKeys(name);
        }

        public void inputSurname(string surname)
        {
            driver.FindElement(By.Id(inputTextSurnameId)).Clear();
            driver.FindElement(By.Id(inputTextSurnameId)).SendKeys(surname);
        }
        public void inputEmail(string email)
        {
            driver.FindElement(By.Id(inputTextEmailId)).Clear();
            driver.FindElement(By.Id(inputTextEmailId)).SendKeys(email);
        }

        public void inputPhoneNo(string phoneNo)
        {
            driver.FindElement(By.Id(inputTextPhoneNoId)).Clear();
            driver.FindElement(By.Id(inputTextPhoneNoId)).SendKeys(phoneNo);
        }

        public void selectCountry(string country)
        {
            new SelectElement(driver.FindElement(By.Id(selectListCountryId))).SelectByText(country);
        }

        public void selectRegion(string region)
        {
            new SelectElement(driver.FindElement(By.Id(selectListRegionId))).SelectByText(region);
        }

        public void inputCity(string city)
        {
            driver.FindElement(By.Id(inputTextCityId)).Clear();
            driver.FindElement(By.Id(inputTextCityId)).SendKeys(city);
        }

        public void uploadCV(string filePath)
        {
            driver.FindElement(By.Id(uploadFileButtonId)).SendKeys(filePath);
        }

        public void sendForm()
        {
            driver.FindElement(By.Id(sendButtonId)).Click();
        }

        public void assertAllRequiredElementsNotFilledAlertAppears()
        {
            StringAssert.Contains("Nie wszystkie wymagane dane zostały wypełnione poprawnie, prosimy sprawdzić formularz", driver.FindElement(By.XPath("//body")).Text);
            StringAssert.Contains("Pole \"Imię\" nie może być puste.", driver.FindElement(By.XPath("//body")).Text);
            StringAssert.Contains("Pole \"Nazwisko\" nie może być puste.", driver.FindElement(By.XPath("//body")).Text);
            StringAssert.Contains("Pole \"E-mail\" nie może być puste.", driver.FindElement(By.XPath("//body")).Text);
            StringAssert.Contains("Pole \"Telefon\" nie może być puste.", driver.FindElement(By.XPath("//body")).Text);
            StringAssert.Contains("Pole \"Kraj\" nie może być puste.", driver.FindElement(By.XPath("//body")).Text);
            StringAssert.Contains("Pole \"Region\" nie może być puste.", driver.FindElement(By.XPath("//body")).Text);
            StringAssert.Contains("Pole \"Miasto\" nie może być puste.", driver.FindElement(By.XPath("//body")).Text);
            StringAssert.Contains("Co najmniej jeden plik CV musi być przesłany.", driver.FindElement(By.XPath("//body")).Text);
        }


    }
}