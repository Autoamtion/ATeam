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
        public virtual void RegistrationLisPageCheckPgsLogo()
        {
            this.GetToRegistrationListPage(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            base.CheckPgsLogoExists(new RegistrationList(this.driver));
        }

        [TestMethod]
        public virtual void RegistrationLisPageCheckAvailableLanguageOptions()
        {
            this.GetToRegistrationListPage(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            base.CheckAvailableLanguageOptions(new RegistrationList(this.driver));
        }

        [TestMethod]
        public virtual void DashboarRegistrationLisPageCheckAvailableUserMenuOptions()
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
