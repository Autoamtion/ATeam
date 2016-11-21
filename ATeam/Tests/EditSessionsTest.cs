using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATeam.Pages;
using ATeam.Pages.Session;
using ATeam.Objects;
using ATeam.Helpers;
using System.Threading;

namespace ATeam.Tests
{
    [TestClass]
    public class EditSessionsTest : BaseTest
    {
        [TestMethod]
        public void EditParticipantMaxNumberPerExamSessionTest()
        {
            var startPage = new LandingPage(this.driver, true);
            var loginPage = new Login(this.driver);
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            var session = new AddSession(this.driver);
            session.SessionLink.Click();
            var sessionData = new SessionData();
            sessionData.IsSpacePerSession = false;
            session.Populate(sessionData);
            var text = this.driver.VisibleText();
            session.SaveSession.Click();
            text = this.driver.VisibleText();

            var sessionDetails = new Details(this.driver);
            sessionDetails.EditBtn.WaitForElement(1000);
            Assert.IsTrue(this.driver.Url.Contains("ateam/Session/Details"), "Session was not created. SessionDetails page is not displayed");
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("dd.MM.yyyy")));
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("HH:mm")));
            Assert.IsTrue(text.Contains(sessionData.PostCode));
            Assert.IsTrue(text.Contains(sessionData.Address));
            Assert.IsTrue(text.Contains(sessionData.City));
            Assert.IsTrue(text.Contains("Ateam 1 Test"));
            
            sessionDetails.EditBtn.Click();

            var editSession = new EditSession(this.driver);
            editSession.IstqbFoundationLevelPlaces.WaitForElement(1000);
            editSession.IstqbFoundationLevelPlaces.Click();
            editSession.IstqbFoundationLevelPlaces.Clear();
            editSession.IstqbFoundationLevelPlaces.SendKeys("14");

            editSession.IstqbAdvancedLevelTestAnalystPlaces.WaitForElement(1000);
            editSession.IstqbAdvancedLevelTestAnalystPlaces.Click();
            editSession.IstqbAdvancedLevelTestAnalystPlaces.Clear();
            editSession.IstqbAdvancedLevelTestAnalystPlaces.SendKeys("24");

            editSession.SaveSession.Click();
            sessionDetails.ExamsBtn.Click();
            Thread.Sleep(1000);
            Assert.IsTrue(this.driver.VisibleText().Contains("Liczba miejsc: 19"), "Number of max places has not been changed");
            Assert.IsTrue(this.driver.VisibleText().Contains("Liczba miejsc: 34"), "Number of max places has not been changed");
        }
    }
}
