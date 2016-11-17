using System;
using System.Collections.Specialized;
using System.Net;
using ATeam.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATeam.Tests
{
    using ATeam.Helpers;
    using ATeam.Pages;
    using ATeam.Pages.Session;

    [TestClass]
    public class AddSessionTests : BaseTest
    {
        [TestMethod]
        public void AddNewSessionProductPlace()
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
            Assert.IsTrue(text.Contains("ISTQB Foundation Level / Angielski, Polski"));
            Assert.IsTrue(text.Contains("REQB Foundation Level / Angielski, Polski"));
            Assert.IsTrue(text.Contains("ISTQB Advanced Level Test Manager / Angielski, Polski"));
            Assert.IsTrue(text.Contains("ISTQB Advancel Level Test Analyst / Angielski, Polski"));
            Assert.IsTrue(text.Contains("ISTQB Advanced Level Technical Test Analyst / Angielski, Polski"));
            Assert.IsTrue(text.Contains("ISTQB Test Management / Angielski"));
            Assert.IsTrue(text.Contains("ISTQB Improving the Test Process / Angielski"));
            Assert.IsTrue(text.Contains("ISTQB Agile Tester Extension / Angielski, Polski"));
            session.SaveSession.Click();
            text = this.driver.VisibleText();
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("dd.MM.yyyy")));
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("HH:mm")));
            Assert.IsTrue(text.Contains("40"));
            Assert.IsTrue(text.Contains(sessionData.PostCode));
            Assert.IsTrue(text.Contains(sessionData.Address));
            Assert.IsTrue(text.Contains(sessionData.City));
            Assert.IsTrue(text.Contains("Ateam1 Test"));
        }

        [TestMethod]
        public void AddNewSessionSessionPlace()
        {
            var startPage = new LandingPage(this.driver, true);
            var loginPage = new Login(this.driver);
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            var session = new AddSession(this.driver);
            session.SessionLink.Click();
            var sessionData = new SessionData();
            sessionData.IsSpacePerSession = true;
            session.Populate(sessionData);
            var text = this.driver.VisibleText();
            Assert.IsTrue(text.Contains("ISTQB Foundation Level / Angielski, Polski"));
            Assert.IsTrue(text.Contains("REQB Foundation Level / Angielski, Polski"));
            Assert.IsTrue(text.Contains("ISTQB Advanced Level Test Manager / Angielski, Polski"));
            Assert.IsTrue(text.Contains("ISTQB Advancel Level Test Analyst / Angielski, Polski"));
            Assert.IsTrue(text.Contains("ISTQB Advanced Level Technical Test Analyst / Angielski, Polski"));
            Assert.IsTrue(text.Contains("ISTQB Test Management / Angielski"));
            Assert.IsTrue(text.Contains("ISTQB Improving the Test Process / Angielski"));
            Assert.IsTrue(text.Contains("ISTQB Agile Tester Extension / Angielski, Polski"));
            session.SaveSession.Click();
            text = this.driver.VisibleText();
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("dd.MM.yyyy")));
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("HH:mm")));
            Assert.IsTrue(text.Contains(sessionData.PlaceForSession.ToString()));
            Assert.IsTrue(text.Contains(sessionData.PostCode));
            Assert.IsTrue(text.Contains(sessionData.Address));
            Assert.IsTrue(text.Contains(sessionData.City));
            Assert.IsTrue(text.Contains("Ateam1 Test"));
        }
    }
}
