using System;
using ATeam.Objects.Enumerators;
using ATeam.Pages.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATeam.Tests
{
    using System.Linq;

    using ATeam.Helpers;
    using ATeam.Objects;
    using ATeam.Pages;
    using ATeam.Pages.RegisterProduct;
    using OpenQA.Selenium;

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
            Assert.IsTrue(this.driver.VisibleText().Contains("2"));
            getAttendees.Forward.Click();
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
        public void RegisterOneUserWithLogin()
        {
            var startPage = new LandingPage(this.driver, true);
            var loginPage = new Login(this.driver);
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            startPage.PgsLogo.Click();
            startPage.IndividualRegistration.First().Click();
            var attendee = new Attendee();
            var getAttendee = new GetAttendee(this.driver);
            getAttendee.CertificateNumber.WaitForElement(1000);
            getAttendee.Populate(attendee);
          
            getAttendee.Forward.Click();
            var getPersonData = new GetPersonData(this.driver);
            var personData = new ContactData();
            personData.InvoiceType = InvoiceType.Digital;
            getPersonData.Populate(personData);
            getPersonData.Forward.Click();
            var getAddress = new GetAddress(this.driver);
            getAddress.Populate(personData);
            getAddress.Forward.Click();
            Assert.IsTrue(this.driver.VisibleText().Contains("Dziękujemy za zapisanie się na egzamin"));
            Assert.IsTrue(this.driver.VisibleText().Contains(personData.PersonDataEmail));
        }

        [TestMethod]
        public void CheckRequiredFieldIsRequiredIndividual()
        {
            var startPage = new LandingPage(this.driver, true);
            var loginPage = new Login(this.driver);
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            startPage.PgsLogo.Click();
            startPage.IndividualRegistration.First().Click();
            var attendee = new Attendee();
            var getAttendee = new GetAttendee(this.driver);
            getAttendee.CertificateNumber.WaitForElement(1000);
            getAttendee.Forward.Click();
            var text = this.driver.VisibleText();
            Assert.IsTrue(text.Contains("Pole Język egzaminu jest wymagane"));
            Assert.IsTrue(text.Contains("Pole Forma Produktu jest wymagane"));
            var getPersonData = new GetPersonData(this.driver);
            var personData = new ContactData();
            personData.InvoiceType = InvoiceType.Digital;
            Assert.IsFalse(getPersonData.Email.Exists());
            
            getAttendee.Populate(attendee);
            
            getAttendee.Forward.Click();
           
            getPersonData.Forward.Click();
            text = this.driver.VisibleText();
            Assert.IsTrue(text.Contains("Pole Imię jest wymagane"));
            Assert.IsTrue(text.Contains("Pole Nazwisko jest wymagane"));
            Assert.IsTrue(text.Contains("Pole Adres e-mail jest wymagane"));
            Assert.IsFalse(text.Contains("Pole Telefon kontaktowy jest wymagane"));
            getPersonData.Forward.Click();
            personData.PersonSendDataPhone = false;
            getPersonData.Populate(personData);
            getPersonData.Forward.Click();
            var getAddress = new GetAddress(this.driver);
            getAddress.Forward.Click();
            text = this.driver.VisibleText();
            Assert.IsTrue(text.Contains("Pole Imię jest wymagane"));
            Assert.IsTrue(text.Contains("Pole Nazwisko jest wymagane"));
            Assert.IsTrue(text.Contains("Pole Nazwisko jest wymagane"));
            Assert.IsTrue(text.Contains("Pole Kod Pocztowy jest wymagane"));
            Assert.IsTrue(text.Contains("Pole Miasto jest wymagane"));
            Assert.IsTrue(text.Contains("Pole Adres jest wymagane"));
            Assert.IsTrue(text.Contains("Pole Faktura VAT jest wymagane"));
            Assert.IsTrue(text.Contains("Wymagana jest zgoda użytkownika"));
            personData.AcceptedMarketingPolicy = false;
            getAddress.Populate(personData);
            getAddress.Forward.Click();
            Assert.IsTrue(this.driver.VisibleText().Contains("Dziękujemy za zapisanie się na egzamin"));
            Assert.IsTrue(this.driver.VisibleText().Contains(personData.PersonDataEmail));
        }

        [TestMethod]
        public void RegisterExamWithoutLogin()
        {
            var startPage = new LandingPage(this.driver, true);
            var loginPage = new Login(this.driver);
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            var session = new AddSession(this.driver);
            var sessionData = new SessionData();
            var dashboard = new Dashboard(this.driver);
            dashboard.AddSessionButton.Click();
            sessionData.IsSpacePerSession = false;
            sessionData.LevelOther = false;
            sessionData.LevelAdvanced = false;
            sessionData.LevelExpert = false;
            sessionData.IstqbAdvancedLevelTechnicalTestAnalystEnglishPolish = false;
            sessionData.IstqbAdvancedLevelTestAnalystEnglishPolish = false;
            sessionData.IstqbAdvancedLevelTestManagerEnglishPolish = false;
            sessionData.IstqbTestManagementEnglish = false;
            sessionData.IstqbAgileTesterExtensionEnglishPolish = false;
            sessionData.IstqbImprovingTheTestProcessEnglish = false;
            session.Populate(sessionData);
            session.SaveSession.Click();
            var sessionId = this.driver.Url.Substring(this.driver.Url.LastIndexOf("/") + 1);
            var sessionDetails = new Details(this.driver);
            sessionDetails.ActivateSession();
            sessionDetails.UserMenu.Click();
            sessionDetails.Logoff.Click();
            var landingPage  = new LandingPage(this.driver);
            var groupRegistration = landingPage.GroupRegistration.Where(x => x.GetAttribute("data-session").Equals(sessionId)).ToList();
            if (!groupRegistration.Any())
            {
                throw new Exception("Exam is not available for registration for logged off user");
            }

            groupRegistration.FirstOrDefault().Click();
            var getAttendees = new GetAttendees(this.driver);
            var attendee = new Attendee();
            getAttendees.Email.WaitForElement(1000);
            getAttendees.Populate(attendee);
            Assert.IsTrue(getAttendees.AddUserToList.Displayed);
            getAttendees.AddUserToList.Click();
            var attendee2 = new Attendee();
            getAttendees.Email.WaitForElement(1000);
            getAttendees.Populate(attendee2);
            Assert.IsTrue(getAttendees.AddUserToList.Displayed);
            getAttendees.AddUserToList.Click();
            Assert.IsTrue(this.driver.VisibleText().Contains("2"));
            getAttendees.Forward.Click();
            var getPersonData = new GetPersonData(this.driver);
            var personData = new ContactData();
            getPersonData.Populate(personData);
            getPersonData.Forward.Click();
            var getAddress = new GetAddress(this.driver);
            getAddress.Populate(personData);
            getAddress.Forward.Click();
            Assert.IsTrue(this.driver.VisibleText().Contains("Dziękujemy za zapisanie się na egzamin"));
            Assert.IsTrue(this.driver.VisibleText().Contains(personData.PersonDataEmail));
            getAddress.PgsLogo.Click();
            startPage.LoginLink.Click();
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            dashboard.CompanyColumnHeader.WaitForElement(1000);
            Assert.IsTrue(dashboard.CheckSessionExistsOnDate(sessionData.SessionDate, sessionData.City));
            dashboard.ClickSessionLink(sessionData.City);
            Assert.AreEqual(8, dashboard.GetFreeSpaceCountFromSessionPopup());
        }

        [TestMethod]
        public void RegisterMultiUserToDifferentExmasWithLoggedInUser()
        {
            var startPage = new LandingPage(this.driver, true);
            var loginPage = new Login(this.driver);
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            startPage.PgsLogo.Click();
            var sessionId = startPage.GetExistingSessionIdWithFreePlacesAndManyExams(4, 3);
            if (sessionId > -1)
            {
                var examButton = this.driver.FindElement(By.CssSelector(string.Format("div[data-session='{0}']", sessionId)));
                examButton.FocusAtElement(this.driver);
                examButton.Click();
                var attendee = new Attendee();
                var getAttendees = new GetAttendees(this.driver);
                getAttendees.Email.WaitForElement(1000);
                getAttendees.Populate(attendee);
                Assert.IsTrue(getAttendees.AddUserToList.Displayed);
                getAttendees.AddUserToList.Click();

                var attendee2 = new Attendee();
                attendee2.SelectedProductId = 1;
                getAttendees.Email.WaitForElement(1000);
                getAttendees.Populate(attendee2);
                Assert.IsTrue(getAttendees.AddUserToList.Displayed);
                getAttendees.AddUserToList.Click();
                Assert.IsTrue(this.driver.VisibleText().Contains("Uczestnicy\r\n2"));

                var attendee3 = new Attendee();
                attendee3.SelectedProductId = 2;
                getAttendees.Email.WaitForElement(1000);
                getAttendees.Populate(attendee3);
                Assert.IsTrue(getAttendees.AddUserToList.Displayed);
                getAttendees.AddUserToList.Click();
                Assert.IsTrue(this.driver.VisibleText().Contains("Uczestnicy\r\n3"));

                getAttendees.Forward.Click();
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
         }
    }
}
