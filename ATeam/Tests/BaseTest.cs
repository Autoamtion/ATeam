using System;
using ATeam.Helpers;
using ATeam.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ATeam.Tests
{
    [TestClass]
    public abstract class BaseTest
    {
        protected IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new FirefoxDriver();
            this.driver.Navigate().GoToUrl(Properties.Settings.Default.StartUrl);
        }

        [TestMethod]
        public virtual void CheckAvailableLanguageOptions(Page testedPage)
        {
            testedPage.LanguageMenu.Click();
            Assert.IsTrue(testedPage.PolishLanguageOption.Exists(), string.Format("Polish language option is not available in Language drop down list on page {0}!", testedPage.GetType().Name));
            Assert.IsTrue(testedPage.EnglishLanguageOption.Exists(), string.Format("English language option is not available in Language drop down list on page {0}!", testedPage.GetType().Name));
        }

        [TestMethod]
        public virtual void CheckPgsLogoExists(Page testedPage)
        {
            Assert.IsTrue(testedPage.PgsLogo.Exists(), string.Format("PGS logo is not displayed on page {0}!", testedPage.GetType().Name));
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Dispose();
        }
    }
}
