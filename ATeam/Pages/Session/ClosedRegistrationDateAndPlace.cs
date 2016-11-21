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
    }
}
