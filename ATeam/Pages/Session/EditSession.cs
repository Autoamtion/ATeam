using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Pages.Session
{
    using ATeam.Helpers;
    using ATeam.Objects;
    using ATeam.Objects.Enumerators;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class EditSession : Page
    {
       public EditSession(IWebDriver driver) : base(driver)
       {
           
       }
        [FindsBy(How = How.LinkText, Using = "Sesje")]
        public IWebElement SessionLink { get; set; }

        [FindsBy(How = How.Id, Using = "SessionDto_Date")]
        public IWebElement SessionDtoDate { get; set; }

        [FindsBy(How = How.ClassName, Using = "icomoon-calendar")]
        public IWebElement CalendarIcon { get; set; }

        [FindsBy(How = How.Id, Using = "SessionDto_Location_PostalCode")]
        public IWebElement LocationPostCode { get; set; }

        [FindsBy(How = How.Id, Using = "SessionDto_Location_City")]
        public IWebElement LocationCity { get; set; }

        [FindsBy(How = How.Id, Using = "SessionDto_Location_Address")]
        public IWebElement LocationAddress { get; set; }

        [FindsBy(How = How.Id, Using = "SessionDto_AdditionalInformation")]
        public IWebElement AdditionalInformation { get; set; }

        [FindsBy(How = How.Id, Using = "spacePerProduct")]
        public IWebElement SpacePerProduct { get; set; }

        [FindsBy(How = How.Id, Using = "spacePerSession")]
        public IWebElement SpacePerSession { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@class,'level')]/..")]
        public IWebElement LevelSelect { get; set; }

        [FindsBy(How = How.LinkText, Using = "Podstawowy")]
        public IWebElement LevelBase { get; set; }

        [FindsBy(How = How.LinkText, Using = "Zaawansowany")]
        public IWebElement LevelAdvanced { get; set; }

        [FindsBy(How = How.LinkText, Using = "Ekspercki")]
        public IWebElement LevelExpert { get; set; }

        [FindsBy(How = How.LinkText, Using = "Inny")]
        public IWebElement LevelOther { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[class*='form-control js-session-closed valid']")]
        public IWebElement ProductSpace { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@class,'product')]/..")]
        public IWebElement ProductSelect { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Foundation Level / Polski, Angielski")]
        public IWebElement IstqbFoundationLevelEnglishPolish { get; set; }

        [FindsBy(How = How.LinkText, Using = "REQB Foundation Level / Polski, Angielski")]
        public IWebElement ReqbFoundationLevelEnglishPolish { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Advanced Level Test Manager / Polski, Angielski")]
        public IWebElement IstqbAdvancedLevelTestManagerEnglishPolish { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[normalize-space(text())=\"ISTQB Advanced Level Test Analyst / Polski, Angielski\"]")]
        public IWebElement IstqbAdvancedLevelTestAnalystEnglishPolish { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Advanced Level Technical Test Analyst / Polski, Angielski")]
        public IWebElement IstqbAdvancedLevelTechnicalTestAnalystEnglishPolish { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Agile Tester Extension / Polski, Angielski")]
        public IWebElement IstqbAgileTesterExtensionEnglishPolish { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Test Management / Angielski")]
        public IWebElement IstqbTestManagementEnglish { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Improving the Testing Process / Angielski")]
        public IWebElement IstqbImprovingTheTestProcessEnglish { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[data-id='SessionDto_ExaminerId']")]
        public IWebElement ExaminerId { get; set; }

        [FindsBy(How = How.LinkText, Using = "(brak)")]
        public IWebElement ExaminerNone { get; set; }

        [FindsBy(How = How.LinkText, Using = "Ateam 1 Test")]
        public IWebElement ExaminerAteam1 { get; set; }

        [FindsBy(How = How.LinkText, Using = "Ateam 2 Test")]
        public IWebElement ExaminerAteam2 { get; set; }

        [FindsBy(How = How.LinkText, Using = "Anuluj")]
        public IWebElement Cancel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement SaveSession { get; set; }

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

        [FindsBy(How = How.Name, Using = "SessionDto.SpaceForSession")]
        public IWebElement SpaceForSession { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[class*='fa fa-trash-o']")]
        public IList<IWebElement> DeleteExam { get; set;  }

        public void DeleteExamFromSession(int index)
        {
            this.DeleteExam[index].Click();
        }

        public void Populate(SessionData d)
        {
            this.SessionDtoDate.SendKeys(d.SessionDate.ToString("dd.MM.yyyy HH:mm"));
            this.LocationPostCode.Click();
            this.LocationPostCode.SendKeys(d.PostCode);
            this.LocationCity.SendKeys(d.City);
            this.LocationAddress.SendKeys(d.Address);
            if (d.FillComment)
            {
                this.AdditionalInformation.SendKeys(d.Comment);
            }

            if (d.IsSpacePerSession)
            {
                this.SpacePerSession.Click();
                this.SpaceForSession.SendKeys(d.PlaceForSession.ToString());
            }
            else
            {
                this.SpacePerProduct.Click();
            }

            this.LevelSelect.Click();
            this.LevelBase.WaitForElement(500);
            if (d.LevelBase)
            {
                this.LevelBase.Click();
            }

            if (d.LevelAdvanced)
            {
                this.LevelAdvanced.Click();
            }

            if (d.LevelExpert)
            {
                this.LevelExpert.Click();
            }

            if (d.LevelOther)
            {
                this.LevelOther.Click();
            }
            this.LevelSelect.Click();
            this.LevelSelect.SendKeys(Keys.Escape);
            this.ProductSelect.Click();
            this.IstqbAdvancedLevelTechnicalTestAnalystEnglishPolish.WaitForElement(1000);
            if (d.IstqbFoundationLevelEnglishPolish)
            {
                this.IstqbFoundationLevelEnglishPolish.WaitForElement(500);
                this.IstqbFoundationLevelEnglishPolish.Click();
            }

            if (d.ReqbFoundationLevelEnglishPolish)
            {
                this.ReqbFoundationLevelEnglishPolish.Click();
            }

            if (d.IstqbAdvancedLevelTestManagerEnglishPolish)
            {
                this.IstqbAdvancedLevelTestManagerEnglishPolish.Click();
            }

            if (d.IstqbAdvancedLevelTestAnalystEnglishPolish)
            {
                this.IstqbAdvancedLevelTestAnalystEnglishPolish.Click();
            }

            if (d.IstqbAdvancedLevelTechnicalTestAnalystEnglishPolish)
            {
                this.IstqbAdvancedLevelTechnicalTestAnalystEnglishPolish.Click();
            }

            if (d.IstqbAgileTesterExtensionEnglishPolish)
            {
                this.IstqbAgileTesterExtensionEnglishPolish.Click();
            }

            if (d.IstqbTestManagementEnglish)
            {
                this.IstqbTestManagementEnglish.Click();
            }

            if (d.IstqbImprovingTheTestProcessEnglish)
            {
                this.IstqbImprovingTheTestProcessEnglish.Click();
            }

            this.ProductSelect.SendKeys(Keys.Escape);

            if (!d.IsSpacePerSession)
            {
                if (d.IstqbFoundationLevelEnglishPolish)
                {
                    this.IstqbFoundationLevelPlaces.SendKeys(d.IstqbFoundationLevelPlaces.ToString());
                }

                if (d.ReqbFoundationLevelEnglishPolish)
                {
                    this.ReqbFoundationLevelPlaces.SendKeys(d.ReqbFoundationLevelPlaces.ToString());
                }

                if (d.IstqbAdvancedLevelTestManagerEnglishPolish)
                {
                    this.IstqbAdvancedLevelTestManagerPlaces.SendKeys(d.IstqbAdvancedLevelTestManagerPlaces.ToString());
                }

                if (d.IstqbAdvancedLevelTestAnalystEnglishPolish)
                {
                    this.IstqbAdvancedLevelTestAnalystPlaces.SendKeys(d.IstqbAdvancedLevelTestAnalystPlaces.ToString());
                }

                if (d.IstqbAdvancedLevelTechnicalTestAnalystEnglishPolish)
                {
                    this.IstqbAdvancedLevelTechnicalTestAnalystPlaces.SendKeys(
                        d.IstqbAdvancedLevelTechnicalTestAnalystPlaces.ToString());
                }

                if (d.IstqbAgileTesterExtensionEnglishPolish)
                {
                    this.IstqbAgileTesterExtensionPlaces.SendKeys(d.IstqbAgileTesterExtensionPlaces.ToString());
                }

                if (d.IstqbTestManagementEnglish)
                {
                    this.IstqbTestManagementPlaces.SendKeys(d.IstqbTestManagementPlaces.ToString());
                }

                if (d.IstqbImprovingTheTestProcessEnglish)
                {
                    this.IstqbImprovingTheTestProcessPlaces.SendKeys(d.IstqbImprovingTheTestProcessPlaces.ToString());
                }
            }

            this.ExaminerId.Click();
            switch (d.ExaminerId)
            {
                case Examiner.ATeam1:
                    this.ExaminerAteam1.Click();
                    break;
                case Examiner.ATeam2:
                    this.ExaminerAteam2.Click();
                    break;
                case Examiner.None:
                    this.ExaminerNone.Click();
                    break;
            }
        }

        public IWebElement Notes { get; set; }
    }
}
