using System;
using ATeam.Helpers;
using ATeam.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace ATeam.Tests
{
    [TestClass]
    public class DashboardTests : BaseTest
    {
        [TestMethod]
        public virtual void DashboardPageCheckPgsLogo()
        {
            this.LoginToDashboard(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            base.CheckPgsLogoExists(new Dashboard(this.driver));
        }

        [TestMethod]
        public virtual void DashboardPageCheckAvailableLanguageOptions()
        {
            this.LoginToDashboard(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            base.CheckAvailableLanguageOptions(new Dashboard(this.driver));
        }

        [TestMethod]
        public virtual void DashboardPageCheckAvailableUserMenuOptions()
        {
            this.LoginToDashboard(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            base.CheckAvailableUserMenuOptions(new Dashboard(this.driver));
        }

        private void LoginToDashboard(string user, string password)
        {
            var landing = new LandingPage(this.driver, true);
            var login = new Login(this.driver);
            login.LogIntoServie(user, password);
        }
    }
}
