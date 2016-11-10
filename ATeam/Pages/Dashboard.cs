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

        [FindsBy(How = How.LinkText, Using = "Dziś")]
        public IWebElement TodayLink { get; set; }
    }
}
