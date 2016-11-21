using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ATeam.Pages.RegisterProduct
{
    using System.Text.RegularExpressions;

    using ATeam.Helpers;
    using ATeam.Objects;

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

        [FindsBy(How = How.CssSelector, Using = "[class*='registration__product--label-session']")]
        public IWebElement NumberOfFreePlaces { get; set; }

        public void Populate(Attendee att)
        {
            if (att.IsEnglish)
            {
                this.ProductLanguageEnglish.Click();
            }
            else
            {
                this.ProductLanguagePolish.Click();
            }

            if (att.IsPaperExam)
            {
                this.ProductFormPaper.Click();
            }
            else
            {
                this.ProductFormElectronic.Click();
            }

            if (this.CertificateNumber.Exists())
            {
                this.CertificateNumber.SendKeys(att.CertificateNumber);
                this.CertificateDate.SendKeys(att.CertificateIssueDate);
                this.CertificateProvider.SendKeys(att.CertificateIssuer);
            }
        }

        public int GetFreePlaces()
        {
            string value = this.NumberOfFreePlaces.Text;
            string result = Regex.Replace(value, @"/d+", "");
            return int.Parse(result);
        }
    }
}
