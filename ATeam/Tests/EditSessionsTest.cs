using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATeam.Tests
{
    using System.Threading;

    using ATeam.Helpers;
    using ATeam.Objects;
    using ATeam.Pages;
    using ATeam.Pages.Session;

    [TestClass]
    public class EditSessionsTest : BaseTest
    {
        [TestMethod]
        public void EditParticipantMaxNumberPerExamSessionTest()
        {
        }

        [TestMethod]

        public void EditParticipantMaximumNumberDefinition()
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
            Assert.IsTrue(text.Contains("ISTQB Foundation Level"));
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
            dashboard.DashboardLink.Click();
            dashboard.SwitchMonthByDate(sessionData.SessionDate);
            WebDriverExtensions.WaitForAjax(this.driver);
            dashboard.ClickSessionLinkNoCheck(sessionData.City);
            dashboard.EditSessionLink.Click();
            var editSession = new EditSession(this.driver);
            string s = editSession.SpaceForSession.Text;
            editSession.SpacePerProduct.Click();
            Assert.Equals(s, editSession.SpacePerProduct.Text);


        }
    }
}
