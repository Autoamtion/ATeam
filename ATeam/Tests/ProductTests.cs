using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Tests
{
    using System.Diagnostics;
    using System.Threading;

    using ATeam.Helpers;
    using ATeam.Pages;
    using ATeam.Pages.Products;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class ProductTests : BaseTest
    {

        [TestMethod]
        public void GoToProductList()
        {
            var login = new Login(this.driver);
            login.LogIntoServie(Properties.Settings.Default.UserAteam1, Properties.Settings.Default.PasswordAteam1);
            var dashboard = new Dashboard(this.driver);
            dashboard.GotoProductPage();
            var productList = new List(this.driver);
           // var products = productList.GetCellFromRecord(2, 2);
            //Debug.WriteLine(products.Text);
            this.driver.WaitForAjax();
            productList.GetProductDetailsByName("ISTQB Foundation Level");
            //productList.GetProductDetailsByName("ISTQB Advanced Level Technical Test Analyst");
           
            Thread.Sleep(4000);
        }

    }
}
