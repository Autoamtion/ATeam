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
        public virtual void LoginPageCheckAvailableLanguageOptions()
        {
            var landing = new LandingPage(this.driver, true);
            base.CheckAvailableLanguageOptions(new Login(this.driver));
        }

        [TestMethod]
        public virtual void LoginPageCheckPgsLogo()
        {
            var landing = new LandingPage(this.driver, true);
            base.CheckPgsLogoExists(new Login(this.driver));
        }

        [TestMethod]
        public void ValidLoginWorks()
        {
            var page = new Login(this.driver);
            page.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            Assert.IsTrue(page.VisibleText.Contains("Dashboard"), "Dashboard is not displayed after log in");
            Assert.IsFalse(page.VisibleText.Contains("Zaloguj się"), "Login is still displated after valid log in");
            Assert.IsFalse(page.Email.Exists());
        }
    }
}
