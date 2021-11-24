using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace QATest
{
    [TestFixture]
    internal class Task3 : CommonCommands
    {
        private ChromeDriver driver = new ChromeDriver();
        private CommonCommands common = new CommonCommands();
        private IWebElement inputBar;
        private IWebElement validation;

        [SetUp]
        public void Start()
        {
            common.initialize(driver, "http://the-internet.herokuapp.com/key_presses");
            inputBar = driver.FindElement(By.XPath(".//input[@id='target']"));
            validation = driver.FindElement(By.XPath(".//*[@id='result']"));
        }

        [Test]
        public void PressOnElementInput() // Perform the browser operations
        {
            inputBar.Click();
            inputBar.SendKeys("W");
            Assert.IsTrue(validation.Text == "You entered: W");

            Thread.Sleep(4000);

            inputBar.Click();
            inputBar.SendKeys("2");
            Assert.IsTrue(validation.Text == "You entered: 2");

            Thread.Sleep(4000);

            inputBar.Click();
            new Actions(driver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
            Assert.IsTrue(validation.Text == "You entered: BACK_SPACE");

            Thread.Sleep(4000);

            inputBar.Click();
            new Actions(driver).SendKeys(OpenQA.Selenium.Keys.Escape).Perform();
            Assert.IsTrue(validation.Text == "You entered: ESCAPE");
        }

        [TearDown]
        public void End()
        {
            common.cleanUp(driver);
        }
    }
}
