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
        private WebDriverWait waiter;

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

        [FindsBy(How = How.XPath, Using = "//*[@id=\"datePickerContainer\"]/div/div[2]/table/tbody/tr[3]/td[1]")]
        public IWebElement DaysFrom;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"datePickerContainer\"]/div/div[2]/table/tbody/tr[4]/td[7]")]
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
            waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(URL);
            waiter.Until(ExpectedConditions.ElementExists(By.CssSelector("#fltSearchContainer")));
        }

        public void ClickOnSearchTickets()
        {
            Submit.Click();
        }

        public void InsertDeparturePlace(string departure)
        {
            PlaceFrom.Clear();
            PlaceFrom.SendKeys(departure);
            PlaceFrom.Click();
        }

        public void InsertDestinationPlace(string destination)
        {
            PlaceTo.Clear();
            PlaceTo.SendKeys(destination);
            PlaceTo.Click();
        }

        public void InsertDestination2Place(string destination)
        {
            PlaceTo2.Clear();
            PlaceTo2.SendKeys(destination);
            PlaceTo2.Click();
        }

        public void SetType(Types type)
        {
            switch (type)
            {
                case Types.OneWay:
                    Type1.Click();
                    break;
                case Types.Transfer:
                    Type2.Click();
                    break;
            }
        }

        public enum Types
        {
            OneWay,
            Transfer
        }

        public void AddLeg()
        {
            AnotherLeg.Click();
        }
        
        public void ToCalendar()
        {
            Dates.Click();
        }

        public void ChooseTripDateFrom()
        {
            waiter.Until(ExpectedConditions.ElementToBeClickable(DaysFrom));
            DaysFrom.Click();
        }

        public void ChooseTripDateTo()
        {
            waiter.Until(ExpectedConditions.ElementToBeClickable(DaysTo));
            DaysTo.Click();
        }

        public void SetBusinessType()
        {
            waiter.Until(ExpectedConditions.ElementToBeClickable(Filter1));
            Filter1.Click();
        }

        public void AddChild()
        {
            waiter.Until(ExpectedConditions.ElementToBeClickable(PlusChild));
            PlusChild.Click();
        }

        public void AddSenior()
        {
            waiter.Until(ExpectedConditions.ElementToBeClickable(PlusSenior));
            PlusSenior.Click();
        }
    }
}
