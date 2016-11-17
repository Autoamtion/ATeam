using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class UserProfileEdit : Page
    {

       public UserProfileEdit(IWebDriver webdriver)
            : base(webdriver)
        {
        }

        [FindsBy(How = How.Id,Using = "AspNetUserOrganizationEditDto_Name")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.Id, Using = "AspNetUserOrganizationEditDto_Surname")]
        public IWebElement Surname { get; set; }

        [FindsBy(How = How.Id, Using = "AspNetUserOrganizationEditDto_CurrentPassword")]
        public IWebElement CurrentPassword { get; set; }

        [FindsBy(How = How.Id, Using = "AspNetUserOrganizationEditDto_NewPassword")]
        public IWebElement NewPassword { get; set; }

        [FindsBy(How = How.Id, Using = "AspNetUserOrganizationEditDto_NewPasswordRepeated")]
        public IWebElement NewPasswordRepeated { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[type*='submit']")]
        public IWebElement SaveBtn { get; set; }

        public void ChangeName(string newName)
        {
            this.Name.SendKeys(newName);
        }

        public void ChangeSurname(string newSurname)
        {
            this.Surname.SendKeys(newSurname);
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            this.CurrentPassword.SendKeys(oldPassword);
            this.NewPassword.SendKeys(newPassword);
            this.NewPasswordRepeated.SendKeys(newPassword);
        }

        public void SaveChanges()
        {
            this.SaveBtn.Click();
        }
    }
}
