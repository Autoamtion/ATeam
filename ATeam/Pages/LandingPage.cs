using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Text.RegularExpressions;
using ATeam.Helpers;

namespace ATeam.Pages
{
    public class LandingPage : Page
    {
        public LandingPage(IWebDriver webdriver)
            : base(webdriver)
        {
        }

        public LandingPage(IWebDriver webdriver, bool goToLoginPage = false)
            : base(webdriver)
        {
            if (goToLoginPage)
            {
                this.LoginLink.WaitForElement(500);
                this.LoginLink.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement LoginLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td[data-productsessionid]")]
        public IList<IWebElement> IndividualRegistration { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[data-session]")]
        public IList<IWebElement> GroupRegistration { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span[class='btn js-closed LandingPage-registerBtn']")]
        public IWebElement RegisterClosedSession { get; set; }

        public int GetExistingSessionIdWithFreePlacesAndManyExams(int minPlaces, int minExams)
        {
            var freePlacesRegExp = @"Wolnych miejsc[\r\n]{1,2}([0-9]{1,3})[\r\n]{1,2}";
            var indRegistration = "Rejestracja indywidualna";
            var sessions = this.driver.FindElements(By.CssSelector("div[class='Agenda-dateContentContainer row']"));

            foreach(var session in sessions)
            {
                var visibleText = session.Text;
                if (!visibleText.Contains("nieaktywna"))
                {
                    var regExp = new Regex(freePlacesRegExp, RegexOptions.IgnoreCase);
                    var freePlaces = int.Parse(regExp.Match(visibleText).Groups[1].Value);
                    var examsCount = new Regex(indRegistration, RegexOptions.IgnoreCase).Matches(visibleText).Count;

                    if (freePlaces >= minPlaces && examsCount >= minExams)
                    {
                        return int.Parse(session.FindElement(By.CssSelector("div[data-session]")).GetAttribute("data-session"));
                    }
                }
            }

            return -1;
        }
    }
}
