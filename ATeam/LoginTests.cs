using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATeam
{
    using ATeam.Pages;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Remote;

    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            this.driver = new FirefoxDriver();
            this.driver.Navigate().GoToUrl("https://examplanner.pgs-soft.com/ateam/Account/Login");
        }

        [TestMethod]
        public void ValidLoginWorks()
        {
            var page = new Login(this.driver);
            page.Email.SendKeys("ateam1@pgs-soft.com");
            page.PasswordPass.SendKeys("YhBQWmtQLt");
            page.LogIn.Click();
            Assert.IsTrue(page.VisibleText.Contains("Dashboard"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.driver.Dispose();
        }
    }
}
