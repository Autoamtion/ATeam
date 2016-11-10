using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Pages.Session
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class AddSession : Page
    {
        public AddSession(IWebDriver webdriver)
            : base(webdriver)
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

        [FindsBy(How = How.XPath, Using = "//select[contains(@class,'product')]/..")]
        public IWebElement ProductSelect { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Foundation Level / Angielski, Polski")]
        public IWebElement IstqbFoundationLevelEnglishPolish { get; set; }

        [FindsBy(How = How.LinkText, Using = "REQB Foundation Level / Angielski, Polski")]
        public IWebElement ReqbFoundationLevelEnglishPolish { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Advanced Level Test Manager / Angielski, Polski")]
        public IWebElement IstqbAdvancedLevelTestManagerEnglishPolish { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Advancel Level Test Analyst / Angielski, Polski")]
        public IWebElement IstqbAdvancedLevelTestAnalystEnglishPolish { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Advanced Level Technical Test Analyst / Angielski, Polski")]
        public IWebElement IstqbAdvancedLevelTechnicalTestAnalystEnglishPolish { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Agile Tester Extension / Angielski, Polski")]
        public IWebElement IstqbAgileTesterExtensionEnglishPolish { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Test Management / Angielski")]
        public IWebElement IstqbTestManagementEnglish { get; set; }

        [FindsBy(How = How.LinkText, Using = "ISTQB Improving the Test Process / Angielski")]
        public IWebElement IstqbImprovingTheTestProcessEnglish { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[data-id='SessionDto_ExaminerId']")]
        public IWebElement ExaminerId { get; set; }

        [FindsBy(How = How.LinkText, Using = "(brak)")]
        public IWebElement ExaminerNone { get; set; }

        [FindsBy(How = How.LinkText, Using = "Ateam1 Test")]
        public IWebElement ExaminerAteam1 { get; set; }

        [FindsBy(How = How.LinkText, Using = "Ateam2 Test")]
        public IWebElement ExaminerAteam2 { get; set; }

        [FindsBy(How = How.LinkText, Using = "Anuluj")]
        public IWebElement Cancel { get; set; }

        [FindsBy(How = How.LinkText, Using = "Zapisz sesję")]
        public IWebElement SaveSession { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[4].CapacityForProductSession")]
        public IWebElement IstqbAdvancedLevelTestManagerPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[18].CapacityForProductSession")]
        public IWebElement IstqbAdvancedLevelTestAnalystPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[19].CapacityForProductSession")]
        public IWebElement IstqbAdvancedLevelTechnicalTestAnalystPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[3].CapacityForProductSession")]
        public IWebElement IstqbFoundationLevelPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[22].CapacityForProductSession")]
        public IWebElement ReqbFoundationLevelPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[20].CapacityForProductSession")]
        public IWebElement IstqbTestManagementPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[21].CapacityForProductSession")]
        public IWebElement IstqbImprovingTheTestProcessPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.Products[23].CapacityForProductSession")]
        public IWebElement IstqbAgileTesterExtensionPlaces { get; set; }

        [FindsBy(How = How.Name, Using = "SessionDto.SpaceForSession")]
        public IWebElement SpaceForSession { get; set; }
    }
}
