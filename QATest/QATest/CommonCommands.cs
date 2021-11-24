using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace QATest
{
    class CommonCommands
    {

        public void initialize(ChromeDriver driver, string url) // Open the browser, go to the link, click on the appropriate link
        {
            System.Environment.SetEnvironmentVariable("restart.browser.each.scenario", "true");

            driver.Navigate().GoToUrl(url); // Go to the page

            driver.Manage().Window.Maximize(); // Make the window fullscreen;
        }

        public void submitDetails(ChromeDriver driver, string username, string password)
        {
            IWebElement usernameElement = driver.FindElement(By.XPath(".//*[@name='username']")); // Get the username field
            IWebElement passwordElement = driver.FindElement(By.XPath(".//*[@name='password']")); // Get the password field
            IWebElement loginButtonElement = driver.FindElement(By.XPath(".//*[@type='submit']")); // Get the login button

            usernameElement.Click(); // Click on the username element
            usernameElement.SendKeys(username); // Enter the details

            passwordElement.Click(); // Click on the password element
            passwordElement.SendKeys(password); // Enter the details

            loginButtonElement.Click(); // Click on the login button

            Thread.Sleep(2000); // Sleep for the validation
        }

        public void scrollToBottom(ChromeDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public void scrollToTop(ChromeDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("window.scrollTo(document.documentElement.scrollTop, 0);");

        }

        public void cleanUp(ChromeDriver driver) // Close the browser and cleanup the test
        {
            driver.Close(); // Close the browser
            driver.Quit(); // Terminate the driver
        }
    }
}
