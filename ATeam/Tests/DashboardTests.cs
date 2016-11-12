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
        public void DashboardMethodsTestMethod()
        {
            this.LoginToDashboard(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            var dashboard = new Dashboard(this.driver);
            this.driver.WaitForAjax();
            dashboard.ClickSessionLinkNoCheck("Warszawa");
            Assert.IsTrue(dashboard.SessionDetailsLink.WaitForElement(1000), "Session popup with details button has not been displayed!");
            var registered = dashboard.GetRegisteredCountFromSessionPopup();
            var freeSpace = dashboard.GetFreeSpaceCountFromSessionPopup();
            var recordsCount = dashboard.GetRecordsCountOnPage();
            dashboard.RecordsDropDownList.SelectByText("50");
            Assert.AreEqual("tea", dashboard.GetCellFromRecord(1, 3).Text, "Improper value of a Last name in record nr 1!");
            dashboard.GoToIndividualDetailsOfRecord(1);
        }

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
