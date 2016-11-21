using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ATeam.Pages.RegisterProduct
{
    using ATeam.Helpers;
    using ATeam.Objects;
    using ATeam.Objects.Enumerators;

    public class GetAddress : Page
    {
        public GetAddress(IWebDriver webdriver) : base(webdriver)
        {
        }

        [FindsBy(How = How.Id, Using = "AddressDto_Name")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_Surname")]
        public IWebElement Surname { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_PostalCode")]
        public IWebElement PostalCode { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_City")]
        public IWebElement City { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_Address")]
        public IWebElement Address { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_Comment")]
        public IWebElement Comment { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_InvoiceTypesNone")]
        public IWebElement InvoiceTypesNone { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_InvoiceTypesElectronic")]
        public IWebElement InvoiceTypesElectronic { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_InvoiceTypesPaper")]
        public IWebElement InvoiceTypesPaper { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_InvoiceCompanyName")]
        public IWebElement InvoiceCompanyName { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_InvoicePostalCode")]
        public IWebElement InvoicePostalCode { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_InvoiceCity")]
        public IWebElement InvoiceCity { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_InvoiceAddress")]
        public IWebElement InvoiceAddress { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_InvoiceNIP")]
        public IWebElement InvoiceNip { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_InvoiceEmail")]
        public IWebElement InvoiceEmail { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_InvoiceAddressIsTheSame")]
        public IWebElement InvoiceAddressIsTheSame { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_LetterCompanyName")]
        public IWebElement LetterCompanyName { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_LetterPostalCode")]
        public IWebElement LetterPostalCode { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_LetterCity")]
        public IWebElement LetterCity { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_LetterAddress")]
        public IWebElement LetterAddress { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_AcceptedPrivacyPolicy")]
        public IWebElement AcceptedPrivacyPolicy { get; set; }

        [FindsBy(How = How.Id, Using = "AddressDto_AcceptedMarketingPolicy")]
        public IWebElement AcceptedMarketingPolicy { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[value='Back']")]
        public IWebElement Back { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[value='Forward']")]
        public IWebElement Forward { get; set; }

        public void Populate(ContactData d)
        {
            this.Name.WaitForElement(1000);
            this.Name.SendKeys(d.ContactName);
            this.Surname.SendKeys(d.ContactSurname);
            this.PostalCode.Click();
            this.PostalCode.SendKeys(d.ContactPostCode);
            this.City.SendKeys(d.ContactCity);
            this.Address.SendKeys(d.ContactAddress);
            if (d.FillComment)
            {
                this.Comment.SendKeys(d.Comment);
            }

            switch (d.InvoiceType)
            {
                    case InvoiceType.None:
                    this.InvoiceTypesNone.Click();
                    break;
                    case InvoiceType.Digital:
                    this.InvoiceTypesElectronic.Click();
                    this.InvoicePostalCode.Click();
                    this.InvoicePostalCode.Clear();
                    this.InvoiceCompanyName.SendKeys(d.InvoiceCompanyName);
                    this.InvoicePostalCode.SendKeys(d.InvoicePostalCode);
                    this.InvoiceCity.Clear();
                    this.InvoiceCity.SendKeys(d.InvoiceCity);
                    this.InvoiceAddress.Clear();
                    this.InvoiceAddress.SendKeys(d.InvoiceAddress);
                    this.InvoiceNip.SendKeys(d.InvoiceNip);
                    this.InvoiceEmail.SendKeys(d.InvoiceEmail);
                    break;
                    case InvoiceType.Paper:
                    this.InvoiceTypesPaper.Click();
                    this.InvoiceCompanyName.SendKeys(d.InvoiceCompanyName);
                    this.InvoicePostalCode.Click();
                    this.InvoicePostalCode.Clear();
                    this.InvoicePostalCode.SendKeys(d.InvoicePostalCode);
                    this.InvoiceCity.Click();
                    this.InvoiceCity.SendKeys(d.InvoiceCity);
                    this.InvoiceNip.SendKeys(d.InvoiceNip);
                    this.InvoiceAddress.Clear();
                    this.InvoiceAddress.SendKeys(d.InvoiceAddress);
                    if (d.InvoiceAddressIsTheSame != this.InvoiceAddressIsTheSame.Selected)
                    {
                        this.InvoiceAddressIsTheSame.Click();
                    }

                    if (!d.InvoiceAddressIsTheSame)
                    {
                        this.LetterCompanyName.WaitForElement(500);
                        this.LetterCompanyName.SendKeys(d.LetterCompanyName);
                        this.LetterPostalCode.Click();
                        this.LetterPostalCode.SendKeys(d.LetterPostalCode);
                        this.LetterCity.SendKeys(d.LetterCity);
                        this.LetterAddress.SendKeys(d.LetterAddress);
                    }

                    break;
            }

            if (this.AcceptedPrivacyPolicy.Selected != d.AcceptedPrivacyPolicy)
            {
                this.AcceptedPrivacyPolicy.Click();
            }

            if (this.AcceptedMarketingPolicy.Selected != d.AcceptedMarketingPolicy)
            {
                this.AcceptedMarketingPolicy.Click();
            }
        }
    }
}
