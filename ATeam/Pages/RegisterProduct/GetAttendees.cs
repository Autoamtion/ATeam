using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ATeam.Pages.RegisterProduct
{
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using System.Threading;

    using ATeam.Helpers;
    using ATeam.Objects;

    public class GetAttendees : Page
    {
        public GetAttendees(IWebDriver webdriver) : base(webdriver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "input[name='name']")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.Name, Using = "surname")]
        public IWebElement Surname { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using = "phone")]
        public IWebElement Phone { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label[for*='ProductPerSessionID']")]
        public IList<IWebElement> Product { get; set; }

        [FindsBy(How = How.Id, Using = "RegistrationLanguageID38add")]
        public IWebElement ProductLanguageEnglish { get; set; }

        [FindsBy(How = How.Id, Using = "RegistrationLanguageID37add")]
        public IWebElement ProductLanguagePolish { get; set; }

        [FindsBy(How = How.Id, Using = "ProductFormIdpapierowaadd")]
        public IWebElement ProductFormPaper { get; set; }

        [FindsBy(How = How.Id, Using = "ProductFormIdelektronicznaadd")]
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

        [FindsBy(How = How.CssSelector, Using = "[class*='registration__product--label-session']")]
        public IWebElement NumberOfFreePlaces { get; set; }

        public void Populate(Attendee att)
        {
            this.Name.SendKeys(att.Name);
            this.Surname.SendKeys(att.SurName);
            this.Email.SendKeys(att.Email);
            if (att.FillPhone)
            {
                this.Phone.SendKeys(att.PhoneNumber);
            }

            var sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < 10000)
            {
                if (this.Product.ToList().Count > att.SelectedProductId)
                {
                    break;
                }

                Thread.Sleep(200);
            }

            this.Product[att.SelectedProductId].Click();
            this.driver.WaitForAjax();
            this.ProductLanguagePolish.WaitForElement(500);

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
            WebDriverExtensions.WaitForAjax(driver);
            string value = this.NumberOfFreePlaces.Text;
            string result = Regex.Match(value, @"\d+").ToString();
            return int.Parse(result);
        }
    }
}
