using System;
using System.Text.RegularExpressions;
using ATeam.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ATeam.Pages
{
    public class Dashboard : Page
    {
        public Dashboard(IWebDriver webdriver)
            : base(webdriver)
        {
        }

        [FindsBy(How = How.Name, Using = "DataTables_Table_0_length")]
        private IWebElement RecordsSelectList { get; set; }

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

        [FindsBy(How = How.ClassName, Using = "popover-content")]
        public IWebElement SessionPopup { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='/ateam/Session/Details']")]
        public IWebElement SessionDetailsLink { get; set; }

        [FindsBy(How = How.ClassName, Using = "js-session-delete")]
        public IWebElement DeleteSessionLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Data rejestracji")]
        public IWebElement RegisteresDateColumnHeader { get; set; }

        [FindsBy(How = How.LinkText, Using = "Imię")]
        public IWebElement FirstNameColumnHeader { get; set; }

        [FindsBy(How = How.LinkText, Using = "Nazwisko")]
        public IWebElement LastNameColumnHeader { get; set; }

        [FindsBy(How = How.LinkText, Using = "Firma")]
        public IWebElement CompanyColumnHeader { get; set; }

        [FindsBy(How = How.LinkText, Using = "Uczestnicy")]
        public IWebElement ParticipantsColumnHeader { get; set; }

        [FindsBy(How = How.LinkText, Using = "Termin")]
        public IWebElement TermColumnHeader { get; set; }

        [FindsBy(How = How.LinkText, Using = "Miejsce")]
        public IWebElement CityColumnHeader { get; set; }

        [FindsBy(How = How.LinkText, Using = "Rejestracja")]
        public IWebElement RegistrationColumnHeader { get; set; }

        [FindsBy(How = How.LinkText, Using = "Status")]
        public IWebElement StatusColumnHeader { get; set; }

        [FindsBy(How = How.LinkText, Using = "Akcje")]
        public IWebElement ActionsColumnHeader { get; set; }

        [FindsBy(How = How.LinkText, Using = "Poprzednia")]
        public IWebElement PreviousRecordsPage { get; set; }

        [FindsBy(How = How.LinkText, Using = "Następna")]
        public IWebElement NextRecordsPage { get; set; }


        public SelectElement RecordsDropDownList
        {
            get
            {
                return new SelectElement(this.RecordsSelectList);
            }
        }

        public void SwitchMonthByDate(DateTime expectedDate)
        {
            var now = DateTime.Now;
            var monthDiff = (expectedDate.Month - now.Month) + 12 * (expectedDate.Year - now.Year);
            if (monthDiff == 0)
            {
                if (this.TodayLink.Exists() && this.TodayLink.Enabled)
                {
                    this.TodayLink.Click();
                }

                return;
            }

            var arrowButton = monthDiff > 0 ? this.NextMonthLink : this.PreviousMonthLink;
            var monthDiffAbs = Math.Abs(monthDiff);
            for (var i = 0; i < monthDiffAbs; i++)
            {
                arrowButton.Click();
            }
        }

        public void ClickSessionLinkNoCheck(string cityName)
        {
            this.driver.FindElement(By.XPath(string.Format("//span[contains(@class, 'fc-title') and text() = '{0}']", cityName))).Click();
        }

        public bool ClickSessionLink(string cityName)
        {
            var sessionLink = this.driver.FindElement(By.XPath(string.Format("//span[contains(@class, 'fc-title') and text() = '{0}']", cityName)));
            if (!sessionLink.Exists())
            {
                return false;
            }

            sessionLink.Click();
            return true;
        }

        public bool CheckSessionExistsOnDate(DateTime checkDate, string cityName)
        {
            this.SwitchMonthByDate(checkDate);
            var sessionLink = this.driver.FindElement(By.XPath(string.Format("//span[contains(@class, 'fc-title') and text() = '{0}']", cityName)));
            if (!sessionLink.Exists())
            {
                return false;
            }

            return true;
        }

        public int GetRegisteredCountFromSessionPopup()
        {
            return int.Parse(Regex.Match(this.SessionPopup.Text, "Zarejestrowanych : ([0-9]+)").Groups[1].Value);
        }

        public int GetFreeSpaceCountFromSessionPopup()
        {
            return int.Parse(Regex.Match(this.SessionPopup.Text, "Wolnych miejsc : ([0-9]+)").Groups[1].Value);
        }

        public int GetRecordsCountOnPage()
        {
            return this.driver.FindElements(By.CssSelector("#DataTables_Table_0 tbody tr")).Count;
        }

        public IWebElement GetCellFromRecord(int record, int column)
        {
            return this.driver.FindElements(By.CssSelector("#DataTables_Table_0 tbody tr .row"))[record - 1]
                .FindElements(By.TagName("td"))[column - 1];
        }

        public void GoToIndividualDetailsOfRecord(int record)
        {
            this.RecordActionElementClick(record, By.CssSelector("a[href*='/ateam/Registration/IndividualDetails']"));
        }

        public void DeleteRecord(int record)
        {
            this.RecordActionElementClick(record, By.ClassName("js-registration-delete"));
        }

        private void RecordActionElementClick(int record, By selector)
        {
            this.driver.FindElement(By.CssSelector("#DataTables_Table_0")).FocusAtElement(this.driver);
            var link = this.driver.FindElements(selector)[record - 1];
            link.FocusAtElement(this.driver);
            link.Click();
        }
    }
}
