using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Pages.Products
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class ProductDetails : Page
    {

       public ProductDetails(IWebDriver driver) : base(driver)
       {
           
       }
        [FindsBy(How = How.Id, Using = "ProductDetails_IsActive")]
        public IWebElement IsActive { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[class*='product-delete']")]
        public IWebElement DeleteProductBtn { get; set; }
        [FindsBy(How = How.CssSelector, Using = "a[href*='/ateam/Products/EditProduct/']")]
        public IWebElement EditProductBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "js-product-status")]
        public IWebElement ProductStatus { get; set; }
    }
}
