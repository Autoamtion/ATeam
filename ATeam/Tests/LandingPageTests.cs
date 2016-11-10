using System;
using ATeam.Helpers;
using ATeam.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATeam.Tests
{
    [TestClass]
    public class LandingPageTests : BaseTest
    {
        [TestMethod]
        public virtual void LandingPageCheckAvailableLanguageOptions()
        {
            base.CheckAvailableLanguageOptions(new LandingPage(this.driver));
        }
    }
}
