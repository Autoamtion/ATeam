using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ATeam.Pages.RegisterProduct
{
    public class GetAttendees : Page
    {
        public GetAttendees(IWebDriver webdriver) : base(webdriver)
        {
        }

        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.Name, Using = "surname")]
        public IWebElement Surname { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using = "phone")]
        public IWebElement Phone { get; set; }

        [FindsBy(How = How.Id, Using = "product")]
        public IWebElement Product { get; set; }

        [FindsBy(How = How.Id, Using = "RegistrationLanguageID7")]
        public IWebElement ProductLanguageEnglish { get; set; }

        [FindsBy(How = How.Id, Using = "RegistrationLanguageID8")]
        public IWebElement ProductLanguagePolish { get; set; }

        [FindsBy(How = How.Id, Using = "ProductFormIdpapierowa")]
        public IWebElement ProductFormPaper { get; set; }

        [FindsBy(How = How.Id, Using = "ProductFormIdelektroniczna")]
        public IWebElement ProductFormElectronic { get; set; }

        [FindsBy(How = How.Name, Using = "certificateNumber")]
        public IWebElement CertificateNumber { get; set; }

        [FindsBy(How = How.Name, Using = "certificatePicker")]
        public IWebElement CertificateDate { get; set; }

        [FindsBy(How = How.Name, Using = "certificateProvider")]
        public IWebElement CertificateProvider { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement AddUserToList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='Register-forwardBtn'] > button")]
        public IWebElement Forward { get; set; }
    }
}
