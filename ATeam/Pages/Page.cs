    using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.IE;

namespace ATeam.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public abstract class Page
    {
        protected IWebDriver driver;

        public Page(IWebDriver webdriver)
        {
            this.driver = webdriver;
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "img[src='/media/logo.png']")]
        public IWebElement PgsLogo { get; set; }

        [FindsBy(How = How.Id, Using = "dropdownMenu-language")]
        public IWebElement LanguageMenu { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='/ateam/Language/SetLanguage?language=pl-PL']")]
        public IWebElement PolishLanguageOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='/ateam/Language/SetLanguage?language=en-US']")]
        public IWebElement EnglishLanguageOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='/ateam/Dashboard/Index']")]
        public IWebElement DashboardLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='/ateam/Registration/List']")]
        public IWebElement RegistrationLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='/ateam/Session/AddSession']")]
        public IWebElement SessionsLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='/ateam/Products/List']")]
        public IWebElement ProductsLink { get; set; }

        [FindsBy(How = How.Id, Using = "dropdownMenu-user")]
        public IWebElement UserMenu { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='/ateam/Dashboard/UserProfileEdit']")]
        public IWebElement UserProfileEdit { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='/ateam/Account/LogOff']")]
        public IWebElement Logoff { get; set; }

        public string VisibleText
        {
            get
            {
                var body = this.driver.FindElement(By.TagName("body"));
                return body.Text;
            }
        }
    }
}
