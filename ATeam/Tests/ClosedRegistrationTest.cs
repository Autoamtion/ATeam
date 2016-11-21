using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATeam.Pages;
using ATeam.Objects;
using ATeam.Pages.Session;
using ATeam.Helpers;

namespace ATeam.Tests
{
    using ATeam.Pages.RegisterProduct;

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
            proposePage.ProposedDate.WaitForElement(500);
            proposePage.Populate(sessionData);
            proposePage.ForwardButton.Click();

            var attendee = new Attendee();
            var users = new ClosedSessionParticipants(this.driver);
            users.Populate(attendee);
            users.AddParticipant.Click();
            users.GoToContactData.Click();
        }

        [TestMethod]
        public void ClosedRegistrationWithoutKnownLocalization()
        {
            var startPage = new LandingPage(this.driver);
            startPage.RegisterClosedSession.Click();

            var sessionData = new SessionData();
            sessionData.SetSpecificLocation = false;

            var proposePage = new ClosedRegistrationDateAndPlace(this.driver);
            proposePage.Populate(sessionData);
            proposePage.ForwardButton.Click();

            var attendee = new Attendee();
            var users = new ClosedSessionParticipants(this.driver);
            users.Populate(attendee);
            users.AddParticipant.Click();
            users.GoToContactData.Click();

            var contactData = new ContactData();
            var personData = new GetPersonData(this.driver);
            personData.Populate(contactData);
            personData.Forward.Click();
            var address = new GetAddress(this.driver);
            address.Populate(contactData);
            address.Forward.Click();
        }
    }
}
