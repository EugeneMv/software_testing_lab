using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace LabPageFactory
{
    [TestFixture]
    class PageTest
    {
        public static IWebDriver browser;

        [SetUp]
        public void Init()
        {
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("https://www.cheapair.com/");
        }

        [TearDown]
        public void Cleanup()
        {
            browser.Close();
        }

        [Test]
        public void FirstTC()
        {
            ClassPageFactory pageObject = new ClassPageFactory();
            var waiter = new WebDriverWait(browser, TimeSpan.FromSeconds(15));

            pageObject.PlaceFrom.Clear();
            pageObject.PlaceFrom.SendKeys("Minsk, Belarus");
            pageObject.PlaceFrom.Click();

            pageObject.PlaceTo.Clear();
            pageObject.PlaceTo.SendKeys("Berlin, Germany");
            pageObject.PlaceTo.Click();

            pageObject.Dates.Click();
            waiter.Until(ExpectedConditions.ElementToBeClickable(pageObject.DaysFrom));
            pageObject.DaysFrom.Click();
            pageObject.DaysTo.Click();

            waiter.Until(ExpectedConditions.ElementToBeClickable(pageObject.Submit));
            pageObject.Submit.Click();

            List<String> tabs = new List<String>(browser.WindowHandles);
            browser.SwitchTo().Window(tabs[1]);
            waiter.Until(ExpectedConditions.ElementExists(By.CssSelector("#flightsResultsMaster > div > div > div:nth-child(4)")));

            Assert.AreNotEqual(pageObject.List.FindElements(By.ClassName("fltrt-opt-region")).Count, 0);
        }
    }
}
