using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATeam.Pages;
using ATeam.Objects;
using ATeam.Pages.Session;
using ATeam.Helpers;
using System.Threading;
using ATeam.Pages.RegisterProduct;

namespace ATeam.Tests
{
    using ATeam.Pages.RegisterProduct;

    [TestClass]
    public class ClosedRegistrationTest : BaseTest
    {
        [TestMethod]
        public void ClosedRegistrationWithSpecificLocationUserNotLoggedIn()
        {
            this.RegisterClosedSession(false, string.Empty, string.Empty);
        }

        [TestMethod]
        public void ClosedRegistrationWithSpecificLocationUserLoggedIn()
        {
            this.RegisterClosedSession(
                true,
                Properties.Settings.Default.UserAteam1,
                Properties.Settings.Default.PasswordAteam1);
        }

        [TestMethod]
        public void RegisterSameUserTwiceToClosedSession()
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
            Assert.IsTrue(users.AddParticipant.WaitForElement(1000), "Button Add Participant is not displayed. Unable to add a participant to closed session!");
            users.AddParticipant.Click();
            Thread.Sleep(1000);
            Assert.IsTrue(this.driver.VisibleText().Contains("Uczestnicy\r\n1"));
            attendee.SelectedLevelId = 1;
            attendee.IsEnglish = false;
            attendee.IsPaperExam = false;
            users.Populate(attendee);
            Assert.IsTrue(users.AddParticipant.WaitForElement(1000), "Button Add Participant is not displayed. Unable to add a participant to closed session!");
            users.AddParticipant.Click();
            Thread.Sleep(1000);
            Assert.IsFalse(this.driver.VisibleText().Contains("Uczestnicy\r\n2"));
            Assert.IsTrue(this.driver.VisibleText().Contains("Użytkownik o takim adresie email został już zarejestrowany"));
        }

        private void RegisterClosedSession(bool loggedUser, string user, string password)
        {
            var startPage = new LandingPage(this.driver);

            if (loggedUser)
            {
                startPage.LoginLink.Click();
                var login = new Login(this.driver);
                login.LogIntoServie(user, password);
                login.PgsLogo.Click();
            }

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
            Assert.IsTrue(users.AddParticipant.WaitForElement(1000), "Button Add Participant is not displayed. Unable to add a participant to closed session!");
            users.AddParticipant.Click();
            Thread.Sleep(1000);
            Assert.IsTrue(this.driver.VisibleText().Contains("Uczestnicy\r\n1"));

            var attendee1 = new Attendee();
            attendee1.SelectedLevelId = 1;
            attendee1.IsEnglish = false;
            attendee1.IsPaperExam = false;
            users.Populate(attendee1);
            Assert.IsTrue(users.AddParticipant.WaitForElement(1000), "Button Add Participant is not displayed. Unable to add a participant to closed session!");
            users.AddParticipant.Click();
            Thread.Sleep(1000);
            Assert.IsTrue(this.driver.VisibleText().Contains("Uczestnicy\r\n2"));

            users.GoToContactData.Click();
            var getPersonData = new GetPersonData(this.driver);
            var personData = new ContactData();
            getPersonData.Populate(personData);
            getPersonData.Forward.Click();
            var getAddress = new GetAddress(this.driver);
            getAddress.Populate(personData);
            getAddress.Forward.Click();
            Assert.IsTrue(this.driver.VisibleText().Contains("Dziękujemy za zapisanie się na egzamin"));
            Assert.IsTrue(this.driver.VisibleText().Contains(personData.PersonDataEmail));
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
