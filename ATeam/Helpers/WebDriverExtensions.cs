using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ATeam.Helpers
{
    public static class WebDriverExtensions
    {
        public static void WaitForAjax(this IWebDriver webDriver)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < 30 * 1000)
            {
                try
                {
                    var executor = webDriver as IJavaScriptExecutor;
                    var isjQuery = (bool)executor.ExecuteScript("return window.jQuery != null");
                    if (isjQuery)
                    {
                        var isjQueryComplete = (bool)executor.ExecuteScript("return jQuery.active == 0");
                        if (isjQueryComplete)
                        {
                            return;
                        }
                    }

                    if (!isjQuery)
                    {
                        return;
                    }

                    Thread.Sleep(300);
                }
                catch
                {
                    return;
                }
            }
        }

        public static bool CheckAlertExists(this IWebDriver webDriver)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(1));
                if (wait.Until(ExpectedConditions.AlertIsPresent()) == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public static bool AlertHandling(this IWebDriver webDriver, bool confirmAlert = true)
        {
            try
            {
                var alert = webDriver.SwitchTo().Alert();
                if (confirmAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }

                return true;
            }
            catch(NoAlertPresentException)
            {
                return false;
            }
        }

        public static string GetVisibleText(this IWebDriver webDriver)
        {
            return webDriver.FindElement(By.TagName("body")).Text;
        }
    }
}
