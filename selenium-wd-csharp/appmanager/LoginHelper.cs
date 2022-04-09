using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace selenium_wd_csharp
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) 
            : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn())
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("username"), account.Username);
            Type(By.Name("password"), account.Password);
            
            driver.FindElement(By.Name("login")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                driver.FindElement(By.Name("username"));
            }
            
        }


        public bool IsLoggedIn()
        {
            return IsElementPresent(By.XPath("//i[contains(@class, 'sign-out')]"));
        }
    }
}
