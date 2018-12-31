using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Security.Policy;
using System.Threading;

namespace FrameworkUnitTest
{
    class MainPage
    {
        private const string URL = "https://www.cheapair.com/";
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "to1")]
        public IWebElement PlaceFrom;

        [FindsBy(How = How.CssSelector, Using = "#dates")]
        public IWebElement Dates;

        [FindsBy(How = How.CssSelector, Using = "#datePickerContainer > div > div.ui-datepicker-group.ui-datepicker-group-last > table > tbody > tr:nth-child(4) > td:nth-child(1)")]
        public IWebElement DaysFrom;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"datePickerContainer\"]/div/div[2]/table/tbody/tr[4]/td[4]")]
        public IWebElement DaysTo;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"fltSearchForm\"]/button")]
        public IWebElement Submit;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(URL);
            System.Threading.Thread.Sleep(1000);
        }

        public int ClickOnSearchTickets()
        {
            Submit.Click();
            System.Threading.Thread.Sleep(7000);
            List<String> tabs = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[1]);
            return driver.FindElement(By.CssSelector("#flightsResultsMaster > div > div > div:nth-child(4)")).FindElements(By.ClassName("fltrt-opt-region")).Count;
        }

        public void InsertTrip(string departure, string destination)
        {
            PlaceFrom.Clear();
            PlaceFrom.SendKeys("Berlin, Germany");
            System.Threading.Thread.Sleep(1000);
            PlaceFrom.Click();
        }

        public void ChooseTripDate()
        {
            Dates.Click();

            System.Threading.Thread.Sleep(1000);
            DaysFrom.Click();
            System.Threading.Thread.Sleep(1000);
            DaysTo.Click();
            System.Threading.Thread.Sleep(1000);
        }

    }
}
