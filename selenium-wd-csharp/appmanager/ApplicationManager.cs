using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace selenium_wd_csharp
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseAdminURL;
        protected string baseShopURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected ShopHelper shopHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            //   driver = new FirefoxDriver();
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            baseAdminURL = "http://localhost/litecart/admin/login.php";
            baseShopURL = "http://localhost/litecart/en/";
            driver.Url = baseShopURL;

            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this);
            shopHelper = new ShopHelper(this);
        }

        ~ApplicationManager()
        {
           // app.Auth.Logout();
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
             //   driver.Url = "http://localhost/litecart/admin/login.php";
                app.Value = newInstance;
                
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }


        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }   
        
        public NavigationHelper Navigation
        {
            get
            {
                return navigationHelper;
            }
        }

        public ShopHelper Shop
        {
            get
            {
                return shopHelper;
            }
        }
    }
}
