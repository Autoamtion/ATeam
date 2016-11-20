using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATeam.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ATeam.Pages.RegisterProduct
{
    using ATeam.Objects;

    public class GetPersonData : Page
    {
        public GetPersonData(IWebDriver webdriver) : base(webdriver)
        {
        }

        [FindsBy(How = How.Id, Using = "PersonDataDto_Name")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.Id, Using = "PersonDataDto_Surname")]
        public IWebElement Surname { get; set; }
        
        [FindsBy(How = How.Id, Using = "PersonDataDto_Email")]
        public IWebElement Email { get; set; }
        
        [FindsBy(How = How.Id, Using = "PersonDataDto_Phone")]
        public IWebElement Phone { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[value='Back']")]
        public IWebElement Back { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[value='Forward']")]
        public IWebElement Forward { get; set; }

        public void Populate(ContactData data)
        {
            this.Name.WaitForElement(1000);
            this.Name.SendKeys(data.PersonDataName);
            this.Surname.SendKeys(data.PersonDataPhone);
            this.Email.SendKeys(data.PersonDataEmail);
            if (data.PersonSendDataPhone)
            {
                this.Phone.SendKeys(data.PersonDataPhone);
            }
        }
    }
}
