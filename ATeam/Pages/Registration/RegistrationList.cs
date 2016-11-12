using ATeam.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ATeam.Pages.Registration
{
    public class RegistrationList : Page
    {
        public RegistrationList(IWebDriver webdriver) : base(webdriver)
        {
        }

        [FindsBy(How = How.Name, Using = "DataTables_Table_0_length")]
        private IWebElement RecordsSelectList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[type='search']")]
        public IWebElement Search { get; set; }

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

        public int GetRecordsCountOnPage()
        {
            return this.driver.FindElements(By.CssSelector("#DataTables_Table_0 tbody tr .row")).Count;
        }

        public IWebElement GetCellFromRecord(int record, int column)
        {
            return this.driver.FindElements(By.CssSelector("#DataTables_Table_0 tbody tr"))[record - 1]
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