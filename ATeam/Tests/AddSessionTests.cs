using System;
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
            var sessionDate = DateTime.Now.AddHours(3);
            session.SessionDtoDate.SendKeys(sessionDate.ToString("dd.MM.yyyy HH:mm"));
            session.LocationPostCode.SendKeys("00-867");
            session.LocationCity.SendKeys("Warszawa");
            session.LocationAddress.SendKeys("Złota 1");
            session.AdditionalInformation.SendKeys("Automated test");
            session.SpacePerProduct.Click();
            session.LevelSelect.Click();
            session.LevelAdvanced.Click();
            session.LevelSelect.Click();
            session.ProductSelect.Click();
            session.IstqbAdvancedLevelTestManagerEnglishPolish.Click();
            Assert.IsFalse(session.IstqbFoundationLevelEnglishPolish.Exists());
            session.ProductSelect.Click();
            session.IstqbAdvancedLevelTestManagerPlaces.SendKeys("5");
            session.ExaminerId.Click();
            session.ExaminerAteam1.Click();
            session.SaveSession.Click();
        }

        [TestMethod]
        public void AddNewSessionSessionPlace()
        {
            var startPage = new LandingPage(this.driver, true);
            var loginPage = new Login(this.driver);
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            var session = new AddSession(this.driver);
            session.SessionLink.Click();
            var sessionDate = DateTime.Now.AddHours(3);
            session.SessionDtoDate.SendKeys(sessionDate.ToString("dd.MM.yyyy HH:mm"));
            session.LocationPostCode.SendKeys("00-867");
            session.LocationCity.SendKeys("Warszawa");
            session.LocationAddress.SendKeys("Złota 1");
            session.AdditionalInformation.SendKeys("Automated test");
            session.SpacePerSession.Click();
            session.SpaceForSession.SendKeys("5");
            session.LevelSelect.Click();
            session.LevelAdvanced.Click();
            session.LevelSelect.Click();
            session.ProductSelect.Click();
            session.IstqbAdvancedLevelTestManagerEnglishPolish.Click();
            Assert.IsFalse(session.IstqbFoundationLevelEnglishPolish.Exists());
            session.ExaminerId.Click();
            session.ExaminerAteam1.Click();
            session.SaveSession.Click();
        }
    }
}
