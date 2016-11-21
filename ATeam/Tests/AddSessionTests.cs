using ATeam.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATeam.Tests
{
    using System;

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
            session.SessionDtoDate.Click();
            session.SessionDtoDate.SendKeys(DateTime.Now.AddDays(10).ToString("dd.MM.yyyy HH:mm"));
            session.AdditionalInformation.Click();
            session.SessionDtoDate.Click();
            session.SessionDtoDate.Clear();
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
            Assert.IsTrue(text.Contains("ISTQB Foundation Level"));
            Assert.IsTrue(text.Contains("REQB Foundation Level"));
            Assert.IsTrue(text.Contains("ISTQB Advanced Level Test Manager"));
            Assert.IsTrue(text.Contains("ISTQB Advanced Level Test Analyst"));
            Assert.IsTrue(text.Contains("ISTQB Advanced Level Technical Test Analyst"));
            Assert.IsTrue(text.Contains("ISTQB Test Management"));
            Assert.IsTrue(text.Contains("ISTQB Improving the Testing Process"));
            Assert.IsTrue(text.Contains("ISTQB Agile Tester Extension"));
            session.SaveSession.Click();
            text = this.driver.VisibleText();
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("dd.MM.yyyy")));
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("HH:mm")));
            Assert.IsTrue(text.Contains("40"));
            Assert.IsTrue(text.Contains(sessionData.PostCode));
            Assert.IsTrue(text.Contains(sessionData.Address));
            Assert.IsTrue(text.Contains(sessionData.City));
            Assert.IsTrue(text.Contains("Ateam 1 Test"));
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
            Assert.IsTrue(text.Contains("ISTQB Foundation Level"));
            Assert.IsTrue(text.Contains("REQB Foundation Level"));
            Assert.IsTrue(text.Contains("ISTQB Advanced Level Test Manager"));
            Assert.IsTrue(text.Contains("ISTQB Advanced Level Test Analyst"));
            Assert.IsTrue(text.Contains("ISTQB Advanced Level Technical Test Analyst"));
            Assert.IsTrue(text.Contains("ISTQB Test Management"));
            Assert.IsTrue(text.Contains("ISTQB Improving the Testing Process"));
            Assert.IsTrue(text.Contains("ISTQB Agile Tester Extension"));
            session.SaveSession.Click();
            text = this.driver.VisibleText();
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("dd.MM.yyyy")));
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("HH:mm")));
            Assert.IsTrue(text.Contains(sessionData.PlaceForSession.ToString()));
            Assert.IsTrue(text.Contains(sessionData.PostCode));
            Assert.IsTrue(text.Contains(sessionData.Address));
            Assert.IsTrue(text.Contains(sessionData.City));
            Assert.IsTrue(text.Contains("Ateam 1 Test"));
            var sessionId = this.driver.Url.Substring(this.driver.Url.LastIndexOf("/") + 1);
        }

        [TestMethod]
        public void CreateSessionForFewTypesAtSameLevel()
        {
            var startPage = new LandingPage(this.driver, true);
            var loginPage = new Login(this.driver);
            loginPage.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            var session = new AddSession(this.driver);
            session.SessionLink.Click();
            var sessionData = new SessionData();
            sessionData.IsSpacePerSession = true;
            sessionData.LevelAdvanced = false;
            sessionData.LevelExpert = false;
            sessionData.LevelOther = false;
            sessionData.IstqbAdvancedLevelTechnicalTestAnalystEnglishPolish = false;
            sessionData.IstqbAdvancedLevelTestAnalystEnglishPolish = false;
            sessionData.IstqbAdvancedLevelTestManagerEnglishPolish = false;
            sessionData.IstqbAgileTesterExtensionEnglishPolish = false;
            sessionData.IstqbImprovingTheTestProcessEnglish = false;
            sessionData.IstqbTestManagementEnglish = false;
            session.Populate(sessionData);
            var text = this.driver.VisibleText();
            Assert.IsTrue(text.Contains("ISTQB Foundation Level / Angielski, Polski"));
            Assert.IsTrue(text.Contains("REQB Foundation Level / Angielski, Polski"));
            session.SaveSession.Click();
            text = this.driver.VisibleText();
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("dd.MM.yyyy")));
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("HH:mm")));
            Assert.IsTrue(text.Contains(sessionData.PlaceForSession.ToString()));
            Assert.IsTrue(text.Contains(sessionData.PostCode));
            Assert.IsTrue(text.Contains(sessionData.Address));
            Assert.IsTrue(text.Contains(sessionData.City));
            Assert.IsTrue(text.Contains("Ateam1 Test"));

            var sessionDetails = new Details(this.driver);
            sessionDetails.ExamsBtn.Click();

            var examsPage = new Exams(this.driver);
            Assert.AreEqual(2, examsPage.GetExamsIds().Count, "Not all selected products are included in session exams list!");
        }
        [TestMethod]
        public void ExamSessionForOneTypeOfExam()
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
            sessionData.ReqbFoundationLevelEnglishPolish = false;
            sessionData.IstqbImprovingTheTestProcessEnglish = false;
            sessionData.IstqbTestManagementEnglish = false;
            session.Populate(sessionData);
            var text = this.driver.VisibleText();
            Assert.IsTrue(text.Contains("ISTQB Foundation Level / Angielski, Polski"));
            session.SaveSession.Click();
            Thread.Sleep(1500);
            text = this.driver.VisibleText();
            Assert.IsTrue(text.Contains(sessionData.SessionDate.ToString("HH:mm")));
            Assert.IsTrue(text.Contains(sessionData.PlaceForSession.ToString()));
            Assert.IsTrue(text.Contains(sessionData.PostCode));
            Assert.IsTrue(text.Contains(sessionData.Address));
            Assert.IsTrue(text.Contains(sessionData.City));
            session.DashboardLink.Click();
            var landingPage = new LandingPage(this.driver);
            landingPage.PgsLogo.Click();
        }
    }
}
