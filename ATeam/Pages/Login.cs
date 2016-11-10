using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class Login : Page
    {

        public Login(IWebDriver webdriver)
            : base(webdriver)
        {
        }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "PasswordPass")]
        public IWebElement PasswordPass { get; set; }

        [FindsBy(How = How.Id, Using = "PasswordText")]
        public IWebElement PasswordText { get; set; }

        [FindsBy(How = How.Id, Using = "PasswordSwitch")]
        public IWebElement PasswordSwitch { get; set; }

        [FindsBy(How = How.Id, Using = "RememberMe")]
        public IWebElement RememberMe { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='Account/ForgotPassword']")]
        public IWebElement ForgotPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[type='submit']")]
        public IWebElement LogIn { get; set; }

        public void LogIntoServie(string user, string pwd)
        {
            var landingPage = new LandingPage(this.driver, true);
            this.Email.SendKeys(user);
            this.PasswordPass.SendKeys(pwd);
            this.LogIn.Click();
        }
    }
}
