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
using System.Globalization;

namespace FrameworkUnitTest
{
    class MainPage
    {
        private const string URL = "https://www.cheapair.com/";
        private IWebDriver driver;
        
        [FindsBy(How = How.XPath, Using = "//*[@id=\"tripTypeContainer\"]/div/label[2]")]
        public IWebElement Type1;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"tripTypeContainer\"]/div/label[3]")]
        public IWebElement Type2;

        [FindsBy(How = How.CssSelector, Using = "#cabin > option:nth-child(3)")]
        public IWebElement Filter1;

        [FindsBy(How = How.Id, Using = "from1")]
        public IWebElement PlaceFrom;

        [FindsBy(How = How.Id, Using = "to1")]
        public IWebElement PlaceTo;

        [FindsBy(How = How.Id, Using = "to2")]
        public IWebElement PlaceTo2;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"multiCityContainer\"]/div[3]/span[2]")]
        public IWebElement AnotherLeg;

        [FindsBy(How = How.CssSelector, Using = "#dates")]
        public IWebElement Dates;

        [FindsBy(How = How.CssSelector, Using = "#datePickerContainer > div > div.ui-datepicker-group.ui-datepicker-group-last > table > tbody > tr:nth-child(3) > td:nth-child(1)")]
        public IWebElement DaysFrom;

        [FindsBy(How = How.CssSelector, Using = "#datePickerContainer > div > div.ui-datepicker-group.ui-datepicker-group-last > table > tbody > tr:nth-child(4) > td:nth-child(7)")]
        public IWebElement DaysTo;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"fltSearchForm\"]/button")]
        public IWebElement Submit;

        [FindsBy(How = How.CssSelector, Using = "#optionsContainer > div > div > div:nth-child(2) > button.btn.btn-close.btn-secondary.trav-select-inc.icn.icn-plus")]
        public IWebElement PlusSenior;

        [FindsBy(How = How.CssSelector, Using = "#optionsContainer > div > div > div:nth-child(3) > button.btn.btn-close.btn-secondary.trav-select-inc.icn.icn-plus")]
        public IWebElement PlusChild;

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

        public void ClickOnSearchTickets()
        {
            Submit.Click();
            System.Threading.Thread.Sleep(7000);
        }

        public void InsertTripOneWay(string departure, string destination)
        {
            Type1.Click();
            PlaceFrom.Clear();
            PlaceFrom.SendKeys(departure);
            System.Threading.Thread.Sleep(1000);
            PlaceFrom.Click();

            PlaceTo.Clear();
            PlaceTo.SendKeys(destination);
            System.Threading.Thread.Sleep(1000);
            PlaceTo.Click();
        }

        public void InsertTripTwoWay(string departure, string destination)
        {
            PlaceFrom.Clear();
            PlaceFrom.SendKeys(departure);
            System.Threading.Thread.Sleep(1000);
            PlaceFrom.Click();

            PlaceTo.Clear();
            PlaceTo.SendKeys(destination);
            System.Threading.Thread.Sleep(1000);
            PlaceTo.Click();
        }

        public void InsertTripTransfer(string departure, string destination, string destination2)
        {
            Type2.Click();

            PlaceTo.Clear();
            PlaceTo.SendKeys(destination);
            System.Threading.Thread.Sleep(500);

            PlaceFrom.Clear();
            PlaceFrom.SendKeys(departure);

            DaysFrom.Click();
            System.Threading.Thread.Sleep(500);
            AnotherLeg.Click();
            System.Threading.Thread.Sleep(500);

            PlaceTo2.Clear();
            PlaceTo2.SendKeys(destination2);

            DaysTo.Click();
            System.Threading.Thread.Sleep(1000);
 
        }

        public void ChooseTripDate()
        {
            Dates.Click();

            System.Threading.Thread.Sleep(1000);
            DaysTo.Click();
            System.Threading.Thread.Sleep(1000);
        }

        public void ChooseTrip2Dates()
        {
            Dates.Click();

            System.Threading.Thread.Sleep(1000);
            DaysFrom.Click();
            System.Threading.Thread.Sleep(1000);
            DaysTo.Click();
            System.Threading.Thread.Sleep(1000);
        }

        public void SelectBusinessType()
        {
            Filter1.Click();
        }

        public void AddChild()
        {
            PlusChild.Click();
        }

        public void AddSenior()
        {
            PlusSenior.Click();
        }
    }
}
