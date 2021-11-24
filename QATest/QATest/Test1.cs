using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;

namespace QATest
{
    class CommonCommands
    {

        public void Initialize(ChromeDriver driver) // Open the browser, go to the link, click on the appropriate link
        {
            System.Environment.SetEnvironmentVariable("restart.browser.each.scenario", "true");

            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login"); // Go to the page

            driver.Manage().Window.Maximize(); // Make the window fullscreen;

            IWebElement title = driver.FindElement(By.XPath(".//*[@class='example']/h2[contains(text(),'Login Page')]")); // Check the title is found

            if (!title.Displayed) // If the title is not visible
            {
                Thread.Sleep(2000); // Sleep for 2 seconds
            }

            Assert.IsTrue(title.Displayed); // Assert that the title is visible
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

        public void CleanUp(ChromeDriver driver) // Close the browser and cleanup the test
        {
            driver.Close(); // Close the browser
            driver.Quit(); // Terminate the driver
        }
    }

    [TestFixture]
    internal class Scenario1 : CommonCommands
    {
        private ChromeDriver driver = new ChromeDriver();
        private CommonCommands common = new CommonCommands();

        [SetUp]
        public void Start ()
        {
            common.Initialize(driver);
        }

        [TearDown]
        public void End()
        {
            common.CleanUp(driver);
        }

        [Test]
        public void ValidUsernameInvalidPassword() // Perform the browser operations
        {
            submitDetails(driver, "tomsmith", "invalid");

            IWebElement invalid = driver.FindElement(By.XPath(".//*[contains(text(), 'password is invalid!')]"));

            Assert.IsTrue(invalid.Displayed);
        }
    }

    [TestFixture]
    internal class Scenario2 : CommonCommands
    {
        private ChromeDriver driver = new ChromeDriver();

        private CommonCommands common = new CommonCommands();

        [SetUp]
        public void Start()
        {
            common.Initialize(driver);
        }

        [TearDown]
        public void End()
        {
            common.CleanUp(driver);
        }

        [Test]
        public void InvalidUsernameValidPassword() // Perform the browser operations
        {
            common.submitDetails(driver, "invalid", "SuperSecretPassword!");

            IWebElement invalid = driver.FindElement(By.XPath(".//*[contains(text(), 'username is invalid!')]"));

            Assert.IsTrue(invalid.Displayed);
        }

    }

    [TestFixture]
    internal class Scenario3 : CommonCommands
    {
        private ChromeDriver driver = new ChromeDriver();

        private CommonCommands common = new CommonCommands();

        [SetUp]
        public void Start()
        {
            common.Initialize(driver);
        }

        [TearDown]
        public void End()
        {
            common.CleanUp(driver);
        }

        [Test]
        public void ValidUsernameValidPassword() // Perform the browser operations
        {
            common.submitDetails(driver, "tomsmith", "SuperSecretPassword!");

            IWebElement valid = driver.FindElement(By.XPath(".//*[contains(text(), 'secure area!')]"));

            Assert.IsTrue(valid.Displayed);

            IWebElement logout = driver.FindElement(By.XPath(".//*[@href='/logout']"));

            logout.Click();

            Thread.Sleep(2000);

            IWebElement title = driver.FindElement(By.XPath(".//*[@class='example']/h2[contains(text(),'Login Page')]")); // Check the title is found

            Assert.IsTrue(title.Displayed);
        }

    }


    

    
}
