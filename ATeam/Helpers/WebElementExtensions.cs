using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ATeam.Helpers
{
    public static class WebElementExtensions
    {
        public static bool Exists(this IWebElement webElement)
        {
            try
            {
                return webElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool WaitForElement(this IWebElement webElement, long miliSeconds)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < miliSeconds)
            {
                try
                {
                    if (webElement.Exists() && webElement.Enabled)
                    {
                        return true;
                    }
                }
                catch
                {
                }

                Thread.Sleep(200);
            }

            return false;
        }

        public static void FocusAtElement(this IWebElement webElement, IWebDriver webDriver)
        {
            var actions = new Actions(webDriver);
            actions.MoveToElement(webElement);
            actions.Perform();
        }
    }
}
