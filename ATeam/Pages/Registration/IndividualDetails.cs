using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ATeam.Pages.Registration
{
    public class IndividualDetails : Page
    {
        public IndividualDetails(IWebDriver webdriver) : base(webdriver)
        {
        }

        [FindsBy(How = How.ClassName, Using = "Backoffice-backButton")]
        public IWebElement RegistrationButton { get; set; }

        [FindsBy(How = How.Id, Using = "dropdownMenu48")]
        public IWebElement StatusList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[data-status='2']")]
        public IWebElement StatusActive { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content='Potwierdzony']")]
        public IWebElement AttributeConfirmed { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content='Przypomnienie']")]
        public IWebElement AttributeReminder { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content='Płatność']")]
        public IWebElement AttributePayment { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content='Faktura']")]
        public IWebElement AttributeInvoice { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content='Wynik']")]
        public IWebElement AttributeResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content='Druk']")]
        public IWebElement AttributePrinting { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content='Certyfikat']")]
        public IWebElement AttributeCertificate { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content='Kara']")]
        public IWebElement AttributeFine { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content='Rezygnacja']")]
        public IWebElement AttributeResign { get; set; }

        [FindsBy(How = How.Id, Using = "sidebarItem-IndividualDetails")]
        public IWebElement ExamLink { get; set; }

        [FindsBy(How = How.Id, Using = "sidebarItem-RegisteringPerson")]
        public IWebElement RegisteringPersonLink { get; set; }

        [FindsBy(How = How.Id, Using = "sidebarItem-DataForCertification")]
        public IWebElement DataForCertificationPersonLink { get; set; }
    }
}
