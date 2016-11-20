using System;
using System.Globalization;
using System.Threading;
using ATeam.Helpers;
using ATeam.Objects;
using ATeam.Pages;
using ATeam.Pages.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace ATeam.Tests
{
    [TestClass]
    public class LandingTests : BaseTest
    {
        [TestMethod]
        public virtual void LandingPageCheckPgsLogo()
        {
            var landing = new LandingPage(this.driver);
            base.CheckPgsLogoExists(new LandingPage(this.driver));
        }

        [TestMethod]
        public void CheckRegistrationButtonIsActiveAndOrange()
        {
            this.CreateSessionToCheckButtonsAvailability();
        }

        [TestMethod]
        public void CheckRegistrationButtonIsActiveAndOrangeAfterLogout()
        {
            this.CreateSessionToCheckButtonsAvailability(true);
        }

        private void CreateSessionToCheckButtonsAvailability(bool logoff = false)
        {
            var startPage = new LandingPage(this.driver, true);
            var loginPage = new Login(this.driver);
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            var session = new AddSession(this.driver);
            session.SessionLink.Click();
            var sessionData = new SessionData();
            sessionData.IsSpacePerSession = true;
            session.Populate(sessionData);
            session.SaveSession.Click();
            var sessionId = this.driver.Url.Substring(this.driver.Url.LastIndexOf("/") + 1);
            var sessionIdNumber = -1;
            Assert.IsTrue(!string.IsNullOrEmpty(sessionId) && int.TryParse(sessionId, NumberStyles.Integer, CultureInfo.InvariantCulture, out sessionIdNumber), "Session has not been created!");
            var sessionDetails = new Details(this.driver);
            sessionDetails.ActivateSession();
            Thread.Sleep(1000);
            var visibleText = this.driver.VisibleText();
            Assert.IsTrue(visibleText.Contains("Status\r\nOtwarta - potwierdzony"), string.Format("Session with ID {0} has not been activated", sessionIdNumber));
            sessionDetails.ExamsBtn.Click();
            var sessionExmas = new Exams(this.driver);
            var examsIds = sessionExmas.GetExamsIds();
            this.driver.Navigate().GoToUrl(Properties.Settings.Default.StartUrl);

            if (logoff)
            {
                sessionDetails.UserMenu.Click();
                sessionDetails.Logoff.Click();
            }
            
            var registrationButton = this.driver.FindElement(By.CssSelector(string.Format("div[data-session='{0}']", sessionIdNumber)));
            Assert.IsTrue(registrationButton.Exists() && registrationButton.Displayed, string.Format("Group registration button for session with ID {0} is not displayed", sessionIdNumber));
            Assert.AreEqual("rgba(255, 119, 38, 1)", registrationButton.GetCssValue("background-color"), "Registration button colour is not orange");

            foreach (var examId in examsIds)
            {
                registrationButton = this.driver.FindElement(By.CssSelector(string.Format("td[data-productsessionid='{0}']", examId)));
                Assert.IsTrue(registrationButton.Exists() && registrationButton.Displayed, string.Format("Individual registration button for exam with ID {0} is not displayed", examId));
            }
        }
    }
}
