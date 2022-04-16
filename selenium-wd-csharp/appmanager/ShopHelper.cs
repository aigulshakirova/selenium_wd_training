using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace selenium_wd_csharp
{
    public class ShopHelper : HelperBase
    {
        public ShopHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public void CheckProductStickers()
        {
            IList<IWebElement> productBlocks = new List<IWebElement>();
            productBlocks = driver.FindElements(By.XPath("//div[@id='main']/div[@class='middle']/div[@class='content']//ul[contains(@class, 'products')]"));
            for (int i=0; i<productBlocks.Count; i++)
            {
                IList<IWebElement> products = new List<IWebElement>();
                products = productBlocks[i].FindElements(By.ClassName("product")); // classname is longer. change to Xpath if needed

                for (int j=0; j<products.Count; j++)
                {
                    if (IsElementPresent(By.ClassName("sticker")) == true)
                    {
                        IList<IWebElement> stickers = new List<IWebElement>();
                        stickers = products[j].FindElements(By.ClassName("sticker"));
                        Assert.IsTrue(stickers.Count == 1);
                    }
                }
            }
        }
    }
}
