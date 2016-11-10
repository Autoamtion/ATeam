using System;
using ATeam.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATeam.Tests
{
    using ATeam.Pages;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Remote;

    [TestClass]
    public class LoginTests : BaseTest
    {
        [TestMethod]
        public void ValidLoginWorks()
        {
            var landingPage = new LandingPage(this.driver);
            landingPage.LoginLink.Click();

            var page = new Login(this.driver);
            page.Email.SendKeys("ateam1@pgs-soft.com");
            page.PasswordPass.SendKeys("YhBQWmtQLt");
            page.LogIn.Click();
            Assert.IsTrue(page.VisibleText.Contains("Dashboard"), "Dashboard is not displayed after log in");
            Assert.IsFalse(page.VisibleText.Contains("Zaloguj się"), "Login is still displated after valid log in");
            Assert.IsFalse(page.Email.Exists());
        }
    }
}
