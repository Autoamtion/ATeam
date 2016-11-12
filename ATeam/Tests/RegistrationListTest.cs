using System;
using System.Threading;
using ATeam.Helpers;
using ATeam.Pages;
using ATeam.Pages.Registration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATeam.Tests
{
    [TestClass]
    public class RegistrationListTest : BaseTest
    {
        [TestMethod]
        public void RegistrationListTestMethod()
        {
            this.GetToRegistrationListPage(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            var registrationList = new RegistrationList(this.driver);
            registrationList.RecordsDropDownList.SelectByText("50");
            registrationList.Search.SendKeys("test");
            this.driver.WaitForAjax();
            Assert.AreEqual(0, registrationList.GetRecordsCountOnPage(), "Unexpected records displayed. Search functionality does not work!");
        }

        [TestMethod]
        public virtual void DashboardPageCheckPgsLogo()
        {
            this.GetToRegistrationListPage(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            base.CheckPgsLogoExists(new RegistrationList(this.driver));
        }

        [TestMethod]
        public virtual void DashboardPageCheckAvailableLanguageOptions()
        {
            this.GetToRegistrationListPage(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            base.CheckAvailableLanguageOptions(new RegistrationList(this.driver));
        }

        [TestMethod]
        public virtual void DashboardPageCheckAvailableUserMenuOptions()
        {
            this.GetToRegistrationListPage(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            base.CheckAvailableUserMenuOptions(new RegistrationList(this.driver));
        }

        private void GetToRegistrationListPage(string user, string password)
        {
            var landing = new LandingPage(this.driver, true);
            var login = new Login(this.driver);
            login.LogIntoServie(user, password);
            login.RegistrationLink.Click();
        }
    }
}
