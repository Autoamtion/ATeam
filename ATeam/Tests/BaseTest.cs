using System;
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
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(Properties.Settings.Default.StartUrl);
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Dispose();
        }
    }
}
