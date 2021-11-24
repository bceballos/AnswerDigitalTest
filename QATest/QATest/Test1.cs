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
    [TestFixture]
    internal class Task1Scenario1 : CommonCommands
    {
        private ChromeDriver driver = new ChromeDriver();
        private CommonCommands common = new CommonCommands();

        [SetUp]
        public void Start ()
        {
            common.initialize(driver, "http://the-internet.herokuapp.com/login");
        }

        [Test]
        public void ValidUsernameInvalidPassword() // Perform the browser operations
        {
            submitDetails(driver, "tomsmith", "invalid");

            IWebElement invalid = driver.FindElement(By.XPath(".//*[contains(text(), 'password is invalid!')]"));

            Assert.IsTrue(invalid.Displayed);
        }

        [TearDown]
        public void End()
        {
            common.cleanUp(driver);
        }
    }

    [TestFixture]
    internal class Task1Scenario2 : CommonCommands
    {
        private ChromeDriver driver = new ChromeDriver();

        private CommonCommands common = new CommonCommands();

        [SetUp]
        public void Start()
        {
            common.initialize(driver, "http://the-internet.herokuapp.com/login");
        }

        [Test]
        public void InvalidUsernameValidPassword() // Perform the browser operations
        {
            common.submitDetails(driver, "invalid", "SuperSecretPassword!");

            IWebElement invalid = driver.FindElement(By.XPath(".//*[contains(text(), 'username is invalid!')]"));

            Assert.IsTrue(invalid.Displayed);
        }

        [TearDown]
        public void End()
        {
            common.cleanUp(driver);
        }

    }

    [TestFixture]
    internal class Task1Scenario3 : CommonCommands
    {
        private ChromeDriver driver = new ChromeDriver();

        private CommonCommands common = new CommonCommands();

        [SetUp]
        public void Start()
        {
            common.initialize(driver, "http://the-internet.herokuapp.com/login");
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

        [TearDown]
        public void End()
        {
            common.cleanUp(driver);
        }

    }


    

    
}
