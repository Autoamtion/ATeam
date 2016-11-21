using ATeam.Helpers;
using ATeam.Objects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Pages.Session
{
    public class ClosedRegistrationDateAndPlace : Page
    {
        public ClosedRegistrationDateAndPlace(IWebDriver webDriver) : base(webDriver)
        {
        }

        [FindsBy(How = How.Id, Using = "ClosedRegistrationDateAndPlaceDto_ProposedDateTime")]
        public IWebElement ProposedDate { get; set; }

        [FindsBy(How = How.Id, Using = "ClosedRegistrationDateAndPlaceDto_IsLocationSpecifiedTrue")]
        public IWebElement SetSpecificLocation { get; set; }

        [FindsBy(How = How.Id, Using = "ClosedRegistrationDateAndPlaceDto_IsLocationSpecifiedFalse")]
        public IWebElement NoSpecificLocation { get; set; }

        [FindsBy(How = How.Id, Using = "ClosedRegistrationDateAndPlaceDto_PostalCode")]
        public IWebElement PostCode { get; set; }

        [FindsBy(How = How.Id, Using = "ClosedRegistrationDateAndPlaceDto_City")]
        public IWebElement City { get; set; }

        [FindsBy(How = How.Id, Using = "ClosedRegistrationDateAndPlaceDto_Address")]
        public IWebElement Address { get; set; }

        [FindsBy(How = How.Id, Using = "ClosedRegistrationDateAndPlaceDto_AdditionalInformation")]
        public IWebElement AdditionalInformation { get; set; }

        [FindsBy(How = How.ClassName, Using = "Register-forwardBtn")]
        public IWebElement ForwardButton { get; set; }

        public void Populate(SessionData d)
        {
            this.ProposedDate.SendKeys(d.SessionDate.ToString("dd.MM.yyyy HH:mm"));
            if (d.SetSpecificLocation)
            {
                this.SetSpecificLocation.Click();
                this.PostCode.Click();
                this.PostCode.Clear();
                this.PostCode.SendKeys(d.PostCode);
                this.City.SendKeys(d.City);
                this.Address.SendKeys(d.Address);
            }
            else
            {
                this.ProposedDate.SendKeys(d.SessionDate.ToString("dd.MM.yyyy HH:mm"));
                this.NoSpecificLocation.Click();
            }

            this.AdditionalInformation.SendKeys(string.Format("Additional information: {0}", RandomDataHelper.GetRandomString(10)));
        }
    }
}
