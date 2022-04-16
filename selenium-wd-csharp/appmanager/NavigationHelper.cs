using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace selenium_wd_csharp
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public void CheckMenuLinks()
        {
            IList<IWebElement> menuElements = new List<IWebElement>();
            menuElements = driver.FindElements(By.CssSelector("ul#box-apps-menu li"));
            for (int i=0; i<menuElements.Count; i++)
            {
                if (i == 0)
                {
                    driver.FindElements(By.CssSelector("ul#box-apps-menu li"))[i].Click();
                }
                if(i != 0)
                {
                 //   driver.FindElements(By.XPath("//../ul[contains(@id,'menu')]/li/../..//ul[contains(@id,'menu')]/li"))[i].Click();
                    driver.FindElements(By.XPath("//ul[contains(@id,'menu')]/li"))[i].Click();
                }
                
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement menuElementHeader = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h1")));

                IList<IWebElement> subMenuElements = new List<IWebElement>();
                subMenuElements = driver.FindElements(By.XPath("//../ul[contains(@id,'menu')]/li//ul/li"));

                for (int j=1; j<subMenuElements.Count; j++)
                {
                    if (j == 1)
                    {
                        subMenuElements[j].Click();
                    }
                    if(j != 1)
                    {
                        driver.FindElements(By.XPath("//../ul[contains(@id,'menu')]/li//ul/li"))[j].Click();
                    }
                    IWebElement subMenuElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h1")));
                }

            }
        }
    }
}
