using System;
using ATeam.Objects.Enumerators;
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
    }
}
