namespace ATeam.Pages.Session
{
    using System.Collections.Generic;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class Details : Page
    {
        public Details(IWebDriver driver)
            : base(driver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "input[data-content*='dodatkowe']")]
        public IWebElement AllStepsCompleted { get; set; }

        [FindsBy(How = How.Id, Using = "sidebarIte-SessionAttachments")]
        public IWebElement AttachmentsBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='/ateam/Dashboard/Index']")]
        public IWebElement DashboardBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*='delete']")]
        public IWebElement DeleteBtn { get; set; }

        [FindsBy(How = How.Id, Using = "sidebarItem-SessionExams")]
        public IWebElement ExamsBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content*='Wszystkie']")]
        public IWebElement InvoicesSent { get; set; }

        [FindsBy(How = How.Id, Using = "sidebarItem-SessionNotes")]
        public IWebElement NotesBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content*='Otrzymanie protoko']")]
        public IWebElement ReceiveExamProtocols { get; set; }

        [FindsBy(How = How.CssSelector, 
            Using = "input[data-content*='Przekazane informacje o uczestnikach do egzaminatora']")]
        public IWebElement SendInfoAboutAttendeeToExaminer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content*='Aktywowanie sesji']")]
        public IWebElement SessionActivator { get; set; }

        [FindsBy(How = How.ClassName, Using = "BackofficeDetails-half")]
        public IList<IWebElement> SessionDateDetails { get; set; }

        [FindsBy(How = How.ClassName, Using = "BackofficeDetails-content")]
        public IList<IWebElement> SessionDetails { get; set; }

        public void ActivateSession()
        {
            this.SessionActivator.Click();
            Helpers.WebDriverExtensions.AlertHandling(driver);
        }

        public void AllInvoicesSent()
        {
            this.InvoicesSent.Click();
            Helpers.WebDriverExtensions.AlertHandling(driver);
        }

        public string GetExamineer()
        {
            return this.SessionDetails[2].Text;
        }

        public string GetExamMaximumAttendants()
        {
            return this.SessionDetails[1].Text;
        }

        public string GetPostalCode()
        {
            return this.SessionDetails[3].Text;
        }

        public string GetSessionDate()
        {
            return this.SessionDateDetails[2].Text;
        }

        public string GetSessionHour()
        {
            return this.SessionDateDetails[3].Text;
        }

        public void LastStep()
        {
            this.AllStepsCompleted.Click();
            Helpers.WebDriverExtensions.AlertHandling(driver);
        }

        public void ReceiveExamProtocol()
        {
            this.ReceiveExamProtocols.Click();
            Helpers.WebDriverExtensions.AlertHandling(driver);
        }

        public void SendAttendeesInfo()
        {
            this.SendInfoAboutAttendeeToExaminer.Click();
            Helpers.WebDriverExtensions.AlertHandling(driver);
        }
    }
}