using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ATeam.Pages
{
    public class Dashboard : Page
    {
        public Dashboard(IWebDriver webdriver)
            : base(webdriver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "button[class*='fc-today-button']")]
        public IWebElement TodayLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*='fc-prev-button']")]
        public IWebElement PreviousMonthLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*='fc-next-button']")]
        public IWebElement NextMonthLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Dodaj sesję")]
        public IWebElement AddSessionButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Dodaj zgłoszenie")]
        public IWebElement NewRegistrationButton { get; set; }
    }
}
