using ATeam.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATeam.Tests
{
    using ATeam.Helpers;
    using ATeam.Pages;
    using ATeam.Pages.Session;
    using OpenQA.Selenium;
    using System.Threading;

    [TestClass]
    public class AddSessionTests : BaseTest
    {
        [TestMethod]
        public void CheckProductsAreNotVisibleWithoutDate()
        {
            var startPage = new LandingPage(this.driver, true);
            var loginPage = new Login(this.driver);
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            var session = new AddSession(this.driver);
            session.SessionLink.Click();
            var sessionData = new SessionData();

            session.ProductSelect.Click();
            Thread.Sleep(500);
            Assert.IsFalse(session.IstqbAdvancedLevelTechnicalTestAnalystEnglishPolish.Exists(), "Product is visible but date of session and difficulty level were not set!");
            Assert.IsFalse(session.IstqbAdvancedLevelTechnicalTestAnalystPlaces.Exists(), "Product is visible but date of session and difficulty level were not set!");
            Assert.IsFalse(session.IstqbAdvancedLevelTestAnalystEnglishPolish.Exists(), "Product is visible but date of session and difficulty level were not set!");
            Assert.IsFalse(session.IstqbAdvancedLevelTestManagerEnglishPolish.Exists(), "Product is visible but date of session and difficulty level were not set!");
            Assert.IsFalse(session.IstqbAdvancedLevelTestManagerPlaces.Exists(), "Product is visible but date of session and difficulty level were not set!");
            Assert.IsFalse(session.IstqbAgileTesterExtensionEnglishPolish.Exists(), "Product is visible but date of session and difficulty level were not set!");
            Assert.IsFalse(session.IstqbAgileTesterExtensionPlaces.Exists(), "Product is visible but date of session and difficulty level were not set!");
            Assert.IsFalse(session.IstqbFoundationLevelEnglishPolish.Exists(), "Product is visible but date of session and difficulty level were not set!");
            Assert.IsFalse(session.IstqbFoundationLevelPlaces.Exists(), "Product is visible but date of session and difficulty level were not set!");
            Assert.IsFalse(session.IstqbImprovingTheTestProcessEnglish.Exists(), "Product is visible but date of session and difficulty level were not set!");
            Assert.IsFalse(session.IstqbImprovingTheTestProcessPlaces.Exists(), "Product is visible but date of session and difficulty level were not set!");
            Assert.IsFalse(session.IstqbTestManagementEnglish.Exists(), "Product is visible but date of session and difficulty level were not set!");
            Assert.IsFalse(session.IstqbTestManagementPlaces.Exists(), "Product is visible but date of session and difficulty level were not set!");
            session.ProductSelect.SendKeys(Keys.Escape);

            session.LevelSelect.Click();
            session.LevelBase.WaitForElement(500);
            session.LevelBase.Click();
            session.LevelAdvanced.Click();
            session.LevelExpert.Click();
            session.LevelOther.Click();
            session.LevelSelect.Click();
            session.LevelSelect.SendKeys(Keys.Escape);

            session.ProductSelect.Click();
            Thread.Sleep(500);
            Assert.IsFalse(session.IstqbAdvancedLevelTechnicalTestAnalystEnglishPolish.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbAdvancedLevelTechnicalTestAnalystPlaces.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbAdvancedLevelTestAnalystEnglishPolish.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbAdvancedLevelTestAnalystPlaces.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbAdvancedLevelTestManagerEnglishPolish.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbAdvancedLevelTestManagerPlaces.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbAgileTesterExtensionEnglishPolish.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbAgileTesterExtensionPlaces.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbFoundationLevelEnglishPolish.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbFoundationLevelPlaces.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbImprovingTheTestProcessEnglish.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbImprovingTheTestProcessPlaces.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbTestManagementEnglish.Exists(), "Product is visible but date of session was not set!");
            Assert.IsFalse(session.IstqbTestManagementPlaces.Exists(), "Product is visible but date of session was not set!");
            session.ProductSelect.SendKeys(Keys.Escape);
        }

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
