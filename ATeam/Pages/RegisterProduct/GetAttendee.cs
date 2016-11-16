using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ATeam.Pages.RegisterProduct
{
    public class GetAttendee : Page
    {
        public GetAttendee(IWebDriver webdriver) : base(webdriver)
        {
        }

        [FindsBy(How = How.Id, Using = "ProductSelectionDto_ProductLanguage7")]
        public IWebElement ProductLanguageEnglish { get; set; }

        [FindsBy(How = How.Id, Using = "ProductSelectionDto_ProductLanguage8")]
        public IWebElement ProductLanguagePolish { get; set; }

        [FindsBy(How = How.Id, Using = "ProductSelectionDto_ProductForm_papierowa")]
        public IWebElement ProductFormPaper { get; set; }

        [FindsBy(How = How.Id, Using = "ProductSelectionDto_ProductForm_elektroniczna")]
        public IWebElement ProductFormElectronic { get; set; }

        [FindsBy(How = How.Id, Using = "ProductSelectionDto_CertificateNumber")]
        public IWebElement CertificateNumber { get; set; }

        [FindsBy(How = How.Id, Using = "ProductSelectionDto_CertificateDateOfIssue")]
        public IWebElement CertificateDate { get; set; }

        [FindsBy(How = How.Id, Using = "ProductSelectionDto_CertificateProvider")]
        public IWebElement CertificateProvider { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement Forward { get; set; }

    }
}
