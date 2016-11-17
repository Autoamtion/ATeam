using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Pages.Products
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class List : Page
    {
       public List(IWebDriver driver) : base(driver)
       {
           
       }
        [FindsBy(How = How.CssSelector, Using = "input[id*='search']")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "table[id*='DataTables_Table_0']>tbody>tr")]
        public List<IWebElement> ProductList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='/ateam/Products/AddProduct']")]
        public IWebElement AddProductBtn { get; set; }
        //TOOD:
        ////public void GetProducts()
        ////{
        ////    foreach (var item in ProductList)
        ////    {
        ////        item.FindElement(By.CssSelector(""))
        ////    }
        ////    this.ProductList
        ////}
    }
}
