using System;
using ATeam.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATeam.Tests
{
    [TestClass]
    public class LandingTests : BaseTest
    {
        [TestMethod]
        public virtual void LandingPageCheckPgsLogo()
        {
            var landing = new LandingPage(this.driver);
            base.CheckPgsLogoExists(new LandingPage(this.driver));
        }
    }
}
