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
        }
    }
}
