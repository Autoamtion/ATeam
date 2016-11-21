using ATeam.Helpers;
using ATeam.Objects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATeam.Pages.Session
{
    public class ClosedSessionParticipants : Page
    {
        public ClosedSessionParticipants(IWebDriver driver) : base(driver)
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

        [FindsBy(How = How.Name, Using = "certificate-leveladd")]
        public IList<IWebElement> DifficultyLevel { get; set; }

        [FindsBy(How = How.LinkText, Using = "(brak)")]
        public IWebElement ExaminerNone { get; set; }

        [FindsBy(How = How.Id, Using = "Language37add")]
        public IWebElement PolishLanguage { get; set; }

        [FindsBy(How = How.Id, Using = "Language38add")]
        public IWebElement EnglishLanguage { get; set; }

        [FindsBy(How = How.Id, Using = "Form1add")]
        public IWebElement PaperForm { get; set; }

        [FindsBy(How = How.Id, Using = "Form2add")]
        public IWebElement ElectronicForm { get; set; }

        [FindsBy(How = How.Name, Using = "product")]
        public IList<IWebElement> Product { get; set; }

        [FindsBy(How = How.Name, Using = "certificateNumber")]
        public IWebElement CertificateNumber { get; set; }

        [FindsBy(How = How.Name, Using = "certificatePicker")]
        public IWebElement CertificateDate { get; set; }

        [FindsBy(How = How.Name, Using = "certificateProvider")]
        public IWebElement CertificateProvider { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement AddParticipant { get; set; }

        [FindsBy(How = How.LinkText, Using = "Termin oraz miejsce")]
        public IWebElement DateAndPlaceButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "Register-forwardBtn")]
        public IWebElement GoToContactData { get; set; }

        public void Populate(Attendee a)
        {
            this.Name.WaitForElement(500);
            this.Name.SendKeys(a.Name);
            this.Surname.SendKeys(a.SurName);
            this.Email.SendKeys(a.Email);
            this.Phone.SendKeys(a.PhoneNumber);
            this.DifficultyLevel[a.SelectedLevelId].Click();
            this.EnglishLanguage.WaitForElement(1000);
            if (a.IsEnglish)
            {
                this.EnglishLanguage.Click();
            }
            else
            {
                this.PolishLanguage.Click();
            }

            this.PaperForm.WaitForElement(1000);
            if (a.IsPaperExam)
            {
                this.PaperForm.Click();
            }
            else
            {
                this.ElectronicForm.Click();
            }

            Thread.Sleep(1000);
            this.Product[a.SelectedProductId].Click();
            this.CertificateNumber.WaitForElement(1000);
            if (this.CertificateNumber.Exists())
            {
                this.CertificateNumber.SendKeys(a.CertificateNumber);
                this.CertificateDate.SendKeys(a.CertificateIssueDate);
                this.CertificateProvider.SendKeys(a.CertificateIssuer);
            }
        }
    }
}
