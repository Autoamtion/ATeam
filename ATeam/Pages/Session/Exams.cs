using System.Collections.Generic;
using ATeam.Pages.Products;

namespace ATeam.Pages.Session
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class Exams : Page
    {
        public Exams(IWebDriver driver)
            : base(driver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "input[data-content*='dodatkowe']")]
        public IWebElement AllStepsCompleted { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content*='Wszystkie']")]
        public IWebElement InvoicesSent { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content*='Otrzymanie protoko']")]
        public IWebElement ReceiveExamProtocols { get; set; }

        [FindsBy(How = How.CssSelector, 
            Using = "input[data-content*='Przekazane informacje o uczestnikach do egzaminatora']")]
        public IWebElement SendInfoAboutAttendeeToExaminer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[data-content*='Aktywowanie sesji']")]
        public IWebElement SessionActivator { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*='delete']")]
        public IWebElement DeleteBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='/ateam/Session/EditSession/'")]
        public IWebElement EditBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='/ateam/Dashboard/Index']")]
        public IWebElement DashboardBtn { get; set; }

        public List<string> GetExamsIds()
        {
            var examsIds = new List<string>();
            var exams = this.driver.FindElements(By.ClassName("Exam-examItemLink"));
            foreach (var exam in exams)
            {
                examsIds.Add(exam.GetAttribute("data-productid"));
            }

            return examsIds;
        }

        public int GetExamIdByName(string examName)
        {
            try
            {
                var allExamRecords = this.driver.FindElements(By.ClassName("Exam-examItem"));
                foreach(var exam in allExamRecords)
                {
                    if(exam.Text.StartsWith(examName))
                    {
                        var examId = exam.FindElement(By.ClassName("Exam-examItemLink")).GetAttribute("data-productid");
                        return int.Parse(examId);
                    }
                }

                return -1;
            }
            catch
            {
                return -1;
            }
        }
    }
}