using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATeam.Pages;
using ATeam.Objects;
using ATeam.Pages.Session;

namespace ATeam.Tests
{
    [TestClass]
    public class ClosedRegistrationTest : BaseTest
    {
        [TestMethod]
        public void ClosedRegistrationWithSpecificLocationUserNotLoggedIn()
        {
            var startPage = new LandingPage(this.driver);
            startPage.RegisterClosedSession.Click();

            var sessionData = new SessionData();
            sessionData.SetSpecificLocation = true;

            var proposePage = new ClosedRegistrationDateAndPlace(this.driver);
            proposePage.Populate(sessionData);
        }
    }
}
