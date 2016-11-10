using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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
                this.LoginLink.Click();
            }
        }

        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement LoginLink { get; set; }
    }
}
