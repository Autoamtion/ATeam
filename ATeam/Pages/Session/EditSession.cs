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
    }
}
