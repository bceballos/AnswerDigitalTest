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
    internal class Task2 : CommonCommands
    {
        private ChromeDriver driver = new ChromeDriver();
        private CommonCommands common = new CommonCommands();

        [SetUp]
        public void Start()
        {
            common.initialize(driver, "http://the-internet.herokuapp.com/infinite_scroll");
        }

        [TearDown]
        public void End()
        {
            common.cleanUp(driver);
        }

        [Test]
        public void ScrollDownScrollUpAssertInfiniteScrollText() // Perform the browser operations
        {
            common.scrollToBottom(driver);

            Thread.Sleep(4000); // Added sleeps to prove / show Selenium scrolling as it lags behind a little bit

            common.scrollToBottom(driver);

            Thread.Sleep(4000);

            common.scrollToTop(driver);

            Thread.Sleep(4000);

            IWebElement title = driver.FindElement(By.XPath(".//*[@class='example']/*[contains(text(),'Infinite Scroll')]"));

            Assert.IsTrue(title.Displayed);
        }
    }
}
