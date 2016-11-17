using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATeam.Tests
{
    using System.Linq;

    using ATeam.Helpers;
    using ATeam.Objects;
    using ATeam.Pages;
    using ATeam.Pages.RegisterProduct;

    [TestClass]
    public class ExamRegistrationTests : BaseTest
    {
        [TestMethod]
        public void RegisterMultiUserWithLoggedInUser()
        {
            var startPage = new LandingPage(this.driver, true);
            var loginPage = new Login(this.driver);
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            startPage.PgsLogo.Click();
            startPage.GroupRegistration.First().Click();
            var attendee = new Attendee();
            var getAttendees = new GetAttendees(this.driver);
            getAttendees.Email.WaitForElement(1000);
            getAttendees.Populate(attendee);
            Assert.IsTrue(getAttendees.AddUserToList.Displayed);
            getAttendees.AddUserToList.Click();
            var attendee2 = new Attendee();
            getAttendees.Email.WaitForElement(1000);
            getAttendees.Populate(attendee2);
            Assert.IsTrue(getAttendees.AddUserToList.Displayed);
            getAttendees.AddUserToList.Click();
            Assert.IsTrue(this.driver.GetVisibleText().Contains("2"));
            getAttendees.Forward.Click();
            var getPersonData = new GetPersonData(this.driver);
            var personData = new ContactData();
            getPersonData.Populate(personData);
            getPersonData.Forward.Click();
            var getAddress = new GetAddress(this.driver);
            getAddress.Populate(personData);
            getAddress.Forward.Click();
            Assert.IsTrue(this.driver.GetVisibleText().Contains("Dziękujemy za zapisanie się na egzamin"));
            Assert.IsTrue(this.driver.GetVisibleText().Contains(personData.PersonDataEmail));
        }
    }
}
