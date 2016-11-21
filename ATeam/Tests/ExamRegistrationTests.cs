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
    using System.Threading;

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

            //startPage.GroupRegistration.First().Click();
            var sessionId = startPage.GetExistingSessionIdWithFreePlacesAndManyExams(4, 2);
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
            getAttendees.Email.WaitForElement(1000);
            getAttendees.Populate(attendee2);
            Assert.IsTrue(getAttendees.AddUserToList.Displayed);
            getAttendees.AddUserToList.Click();
            Assert.IsTrue(this.driver.VisibleText().Contains("Uczestnicy\r\n2"));
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
            getAddress.Name.WaitForElement(1000);
            getAddress.Forward.Click();
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

            /*landingPage.PgsLogo.Click();
            Thread.Sleep(500);
            var sid = landingPage.GetExistingSessionIdWithFreePlacesAndManyExams(3, 2);
            var examButton = this.driver.FindElement(By.CssSelector(string.Format("div[data-session='{0}']", sid)));
            examButton.FocusAtElement(this.driver);
            examButton.Click();*/

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
            Thread.Sleep(500);
            Assert.IsTrue(dashboard.CheckSessionExistsOnDate(sessionData.SessionDate, sessionData.City));
            dashboard.ClickSessionLink(sessionData.City);
            dashboard.SessionDetailsLink.WaitForElement(1000);
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

        [TestMethod]
        public void RegisterMultiUserToDifferentExmasLoggedOff()
        {
            var startPage = new LandingPage(this.driver);
            var sessionId = startPage.GetExistingSessionIdWithFreePlacesAndManyExams(4, 3);
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

        [TestMethod]
        public void RegisterUserToExamWithoutFreePlace()
        {

            var loginPage = new Login(this.driver);
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            var dashboard = new Dashboard(this.driver);
            dashboard.AddSessionButton.Click();
            var session = new AddSession(this.driver);
            session.SessionLink.Click();
            var sessionData = new SessionData();
            sessionData.PlaceForSession = 5;
            sessionData.IsSpacePerSession = true;
            sessionData.LevelAdvanced = false;
            sessionData.LevelExpert = false;
            sessionData.LevelOther = false;
            sessionData.IstqbAdvancedLevelTechnicalTestAnalystEnglishPolish = false;
            sessionData.IstqbAdvancedLevelTestAnalystEnglishPolish = false;
            sessionData.IstqbAdvancedLevelTestManagerEnglishPolish = false;
            sessionData.IstqbAgileTesterExtensionEnglishPolish = false;
            sessionData.IstqbImprovingTheTestProcessEnglish = false;
            sessionData.ReqbFoundationLevelEnglishPolish = false;
            sessionData.IstqbTestManagementEnglish = false;
            session.Populate(sessionData);
            session.SaveSession.Click();
            session.DashboardLink.Click();
            var landingPage = new LandingPage(this.driver);
            landingPage.PgsLogo.Click();
            Thread.Sleep(2000);
            var sessionId = landingPage.GetExistingSessionIdWithFreePlacesAndManyExams(5, 1);
            var examButton = this.driver.FindElement(By.CssSelector(string.Format("div[data-session='{0}']", sessionId)));
            examButton.Click();

            var attendee = new Attendee();
            var getAttendees = new GetAttendees(this.driver);
            int freePlaces = getAttendees.GetFreePlaces();
            getAttendees.Email.WaitForElement(1000);
            getAttendees.Populate(attendee);
            Assert.IsTrue(getAttendees.AddUserToList.Displayed);
            getAttendees.AddUserToList.Click();

            var attendee2 = new Attendee();
            attendee2.SelectedProductId = 1;
            getAttendees.Email.WaitForElement(1000);
            getAttendees.Populate(attendee2);
            int freePlaces2 = getAttendees.GetFreePlaces();
            Assert.AreEqual(freePlaces-1, freePlaces2);
            Assert.IsTrue(getAttendees.AddUserToList.Displayed);
            getAttendees.AddUserToList.Click();
            Assert.IsTrue(this.driver.VisibleText().Contains("Uczestnicy\r\n2"));

            var attendee3 = new Attendee();
            attendee3.SelectedProductId = 1;
            getAttendees.Email.WaitForElement(1000);
            getAttendees.Populate(attendee3);
            int freePlaces3 = getAttendees.GetFreePlaces();
            Assert.AreEqual(freePlaces2-1,freePlaces3);
            Assert.IsTrue(getAttendees.AddUserToList.Displayed);
            getAttendees.AddUserToList.Click();
            Assert.IsTrue(this.driver.VisibleText().Contains("Uczestnicy\r\n3"));

            var attendee4 = new Attendee();
            attendee4.SelectedProductId = 1;
            getAttendees.Email.WaitForElement(1000);
            int freePlaces4 = getAttendees.GetFreePlaces();
            getAttendees.Populate(attendee4);
            Assert.IsTrue(getAttendees.AddUserToList.Displayed);
            getAttendees.AddUserToList.Click();
            Assert.IsTrue(this.driver.VisibleText().Contains("Uczestnicy\r\n4"));

            var attendee5 = new Attendee();
            attendee5.SelectedProductId = 1;
            int freePlaces5 = getAttendees.GetFreePlaces();
            getAttendees.Email.WaitForElement(1000);
            getAttendees.Populate(attendee5);
            Assert.IsTrue(getAttendees.AddUserToList.Displayed);
            getAttendees.AddUserToList.Click();
            Assert.IsTrue(this.driver.VisibleText().Contains("Uczestnicy\r\n5"));

            var attendee6 = new Attendee();
            attendee6.SelectedProductId = 1;
            int freePlaces6 = getAttendees.GetFreePlaces();
            getAttendees.Email.WaitForElement(1000);
            getAttendees.Populate(attendee6);
            Assert.IsTrue(getAttendees.AddUserToList.Displayed);
            getAttendees.AddUserToList.Click();

            var attendee7 = new Attendee();
            attendee7.SelectedProductId = 1;
            int freePlaces7 = getAttendees.GetFreePlaces();
            getAttendees.Email.WaitForElement(1000);
            getAttendees.Product[0].Click();
            string text = this.driver.SwitchTo().Alert().Text;
            Assert.IsTrue(getAttendees.AddUserToList.Displayed);
            getAttendees.AddUserToList.Click();

        }

    }
}
