﻿using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

using erecruiter.Pages;
using erecruiter.Common;

namespace erecruiter.Tests
{
    class Regression
    {

        public IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new FirefoxDriver("C:\\Users\\Jan\\Source\\Repos\\jliwski\\erecruiter\\drivers");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void RecruitmentFormTest()
        {
            CommonActions commonActions = new CommonActions(driver);
            RecruitmentFormPage applicationFormPage = new RecruitmentFormPage(driver);
            ThankYouPage thankYouPage = new ThankYouPage(driver);

            commonActions.openURL("https://system.erecruiter.pl/FormTemplates/RecruitmentForm.aspx?WebID=c907acdcca724851bbc924b001609f67");
            applicationFormPage.disableCookieInfo();
            applicationFormPage.inputName("Jan");
            applicationFormPage.inputSurname("Testowy");
            applicationFormPage.inputEmail("Jan.Testowy@pracuj.pl");
            applicationFormPage.inputPhoneNo("692558963");
            applicationFormPage.selectCountry("Polska");
            applicationFormPage.selectRegion("mazowieckie");
            applicationFormPage.inputCity("Warszawa");
            applicationFormPage.uploadCV("C:\\Users\\Jan\\Source\\Repos\\jliwski\\erecruiter\\external_files\\Test CV.pdf");
            applicationFormPage.sendForm();
            thankYouPage.assertSuccessfulApplication();
        }

        [Test]
        public void RecruitmentFormValidationsTest()
        {
            CommonActions commonActions = new CommonActions(driver);
            RecruitmentFormPage applicationFormPage = new RecruitmentFormPage(driver);
            ThankYouPage thankYouPage = new ThankYouPage(driver);

            commonActions.openURL("https://system.erecruiter.pl/FormTemplates/RecruitmentForm.aspx?WebID=c907acdcca724851bbc924b001609f67");
            applicationFormPage.sendForm();
            applicationFormPage.assertAllRequiredElementsNotFilledAlertAppears();
            applicationFormPage.inputName("Jan");
            applicationFormPage.inputSurname("Testowy");
            applicationFormPage.inputEmail("Jan.Testowypracuj.pl");
            applicationFormPage.inputPhoneNo("qwertyuio");
            applicationFormPage.selectCountry("Hiszpania");
            applicationFormPage.inputCity("Madryt");
            applicationFormPage.sendForm();
            applicationFormPage.assertImproperEmailFormatAlertAppears();
            applicationFormPage.assertPhoneNoNotFilledAlertAppears();
            applicationFormPage.inputEmail("Jan.Testowy@pracujpl");
            applicationFormPage.inputPhoneNo("692558963");
            applicationFormPage.sendForm();
            applicationFormPage.assertImproperEmailFormatAlertAppears();
            applicationFormPage.inputEmail("Jan.Testowy@pracuj.pl");
            applicationFormPage.uploadCV("C:\\Users\\Jan\\Source\\Repos\\jliwski\\erecruiter\\external_files\\Test CV.pdf");
            applicationFormPage.deleteUploadedCV();
            applicationFormPage.sendForm();
            applicationFormPage.assertAttachmentRequiredAlertAppears();
            applicationFormPage.uploadCV("C:\\Users\\Jan\\Source\\Repos\\jliwski\\erecruiter\\external_files\\Test CV.pdf");
            applicationFormPage.sendForm();
            thankYouPage.assertSuccessfulApplication();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

    }

}