using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Pages.Products
{
    using System.Diagnostics;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class List : Page
    {
        public List(IWebDriver driver)
            : base(driver)
        {

        }

        [FindsBy(How = How.CssSelector, Using = "input[id*='search']")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "table[id*='DataTables_Table_0']>tbody>tr")]
        public IList<IWebElement> ProductList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='/ateam/Products/AddProduct']")]
        public IWebElement AddProductBtn { get; set; }

        //TOOD:
        // get all products
        // get product with name
        // is registration available for product
        public int GetProductCountOnPage()
        {
            return this.ProductList.Count;
        }

        public IWebElement GetCellFromRecord(int record, int column)
        {
            return this.driver.FindElements(By.CssSelector("#DataTables_Table_0 tbody tr"))[record - 1]
                    .FindElements(By.TagName("td"))[column - 1];
        }

        public void GetProductDetailsByName(string name)
        {
              ProductsRowsIterationHelper(0,name);
        }

        public void GetProductDetailsByDate(string date)
        {
            ProductsRowsIterationHelper(1, date);
        }

        public void GetProductDetailsByLevel(string level)
        {
            ProductsRowsIterationHelper(2, level);
        }

        public void GetProductDetailsByLanguage(string language)
        {
            ProductsRowsIterationHelper(3, language);
        }

        public void GetProductDetailsByAvailability(bool available)
        {
            
        }

        public void GetProductDetailsByStatus(bool isActive)
        {
            string status;
            if (isActive)
            {
                status = "Aktywny";
            }
            else
            {
                status = "Nie Aktywny";
            }
            ProductsRowsIterationHelper(7, status);
        }

        public void GoToProductDetails(int numberOfProduct)
        {
            
        }

        private void ProductsRowsIterationHelper(int column, string text)
        {
            foreach (var product in ProductList)
            {
                if (!product.FindElements(By.TagName("td"))[column].Text.Contains(text))
                {
                    continue;
                }
                product.FindElements(By.TagName("td"))[7].Click();
                break;
            }
        }
    }
}
