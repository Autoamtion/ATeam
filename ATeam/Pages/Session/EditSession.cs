using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Pages.Session
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class EditSession : Page
    {
       public EditSession(IWebDriver driver) : base(driver)
       {
           
       }
        [FindsBy(How = How.Id, Using = "SessionDto_Location_PostalCode")]
        public IWebElement PostalCode { get; set; }

        [FindsBy(How = How.Id, Using = "SessionDto_Location_Address")]
        public IWebElement Address { get; set; }

        public IWebElement Notes { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[88].CapacityForProductSession")]
        public IWebElement IstqbAdvancedLevelTestManagerPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[87].CapacityForProductSession")]
        public IWebElement IstqbAdvancedLevelTestAnalystPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[86].CapacityForProductSession")]
        public IWebElement IstqbAdvancedLevelTechnicalTestAnalystPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[90].CapacityForProductSession")]
        public IWebElement IstqbFoundationLevelPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[93].CapacityForProductSession")]
        public IWebElement ReqbFoundationLevelPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[91].CapacityForProductSession")]
        public IWebElement IstqbTestManagementPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[92].CapacityForProductSession")]
        public IWebElement IstqbImprovingTheTestProcessPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[89].CapacityForProductSession")]
        public IWebElement IstqbAgileTesterExtensionPlaces { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement SaveSession { get; set; }
    }
}
