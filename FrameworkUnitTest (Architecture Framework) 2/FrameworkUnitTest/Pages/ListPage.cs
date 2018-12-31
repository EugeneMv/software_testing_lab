using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkUnitTest
{
    class ListPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "#flightsResultsMaster > div > div > div:nth-child(4)")]
        public IWebElement List;

        [FindsBy(How = How.CssSelector, Using = "#modalContainer > div > div > div > div > button")]
        public IWebElement NoThx;

        [FindsBy(How = How.CssSelector, Using = "#sliderRange > span:nth-child(2)")]
        public IWebElement TimeSelector;

        [FindsBy(How = How.CssSelector, Using = "#stickyHeader > div.fltrt-header.fltrt-structure > div.fltrt-filter > div")]
        public IWebElement FilterViewer;

        [FindsBy(How = How.CssSelector, Using = "#applyFilters")]
        public IWebElement FilterApplier;

        [FindsBy(How = How.CssSelector, Using = "#stickyHeader > div.fltrt-header.fltrt-structure > div.fltrt-filter > div > div > div > div > div.fltrt-filter-groups.fltrt-filter-groups-stops > label:nth-child(3)")]
        public IWebElement FilterNonstop;

        [FindsBy(How = How.CssSelector, Using = "#compareFares")]
        public IWebElement Comparer;

        [FindsBy(How = How.CssSelector, Using = "#fareCompareModal")]
        public IWebElement CompareView;

        [FindsBy(How = How.CssSelector, Using = "#flightReviewTarget > div > div > div > div:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(4) > strong > span > span.sc-daURTG.GvLOB")]
        public IWebElement FirstPriceS;

        [FindsBy(How = How.CssSelector, Using = "#flightReviewTarget > div > div > div > div:nth-child(4) > table > tbody > tr:nth-child(2) > td:nth-child(4) > strong > span > span.sc-daURTG.GvLOB")]
        public IWebElement SecondPriceS;

        [FindsBy(How = How.CssSelector, Using = "#flightReviewTarget > div > div > div > div:nth-child(4) > table > tfoot > tr > td:nth-child(3) > span > span.sc-daURTG.GvLOB")]
        public IWebElement CurrentPriceS;

        [FindsBy(How = How.CssSelector, Using = "#flightReviewTarget > div > div > div > div:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(4) > strong > span > span.sc-daURTG.GvLOB")]
        public IWebElement FirstPriceC;

        [FindsBy(How = How.CssSelector, Using = "#flightReviewTarget > div > div > div > div:nth-child(5) > table > tbody > tr:nth-child(2) > td:nth-child(4) > strong > span > span.sc-daURTG.GvLOB")]
        public IWebElement SecondPriceC;

        [FindsBy(How = How.CssSelector, Using = "#flightReviewTarget > div > div > div > div:nth-child(5) > table > tfoot > tr > td:nth-child(3) > span > span.sc-daURTG.GvLOB")]
        public IWebElement CurrentPriceC;

        public ListPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            List<String> tabs = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[1]);
            NoThx.Click();
        }

        public int Count()
        {
            return List.FindElements(By.ClassName("fltrt-opt-region")).Count;
        }

        public void SetTimeFilter()
        {
            Actions move = new Actions(driver);
            var action = move.MoveToElement(FilterViewer).DragAndDropToOffset(TimeSelector, 150, 0).Build();
            action.Perform();
            System.Threading.Thread.Sleep(2500);
            FilterApplier.Click();
            System.Threading.Thread.Sleep(4000);
        }

        public void SetNonStopFilter()
        {
            Actions move = new Actions(driver);
            var action = move.MoveToElement(FilterViewer).Click(FilterNonstop).Build();
            action.Perform();
            System.Threading.Thread.Sleep(2500);
            FilterApplier.Click();
            System.Threading.Thread.Sleep(4000);
        }

        public void SetAirportsFilter()
        {
            Actions move = new Actions(driver);
            var action = move.MoveToElement(FilterViewer).Build();
            action.Perform();
            System.Threading.Thread.Sleep(1500);
            FilterApplier.Click();
            System.Threading.Thread.Sleep(4000);
        }

        public bool CheckComparer()
        {
            var list = driver.FindElement(By.CssSelector("#flightsResultsMaster > div > div > div:nth-child(4)")).FindElements(By.ClassName("fltrt-opt-region"));
            list[0].FindElement(By.ClassName("fltrt-cmp-selection-wrapper")).Click();
            list[1].FindElement(By.ClassName("fltrt-cmp-selection-wrapper")).Click();
            Comparer.Click();
            System.Threading.Thread.Sleep(500);

            return CompareView.Displayed;
        }

        public bool ComparePricesChild()
        {
            var list = driver.FindElement(By.CssSelector("#flightsResultsMaster > div > div > div:nth-child(4)")).FindElements(By.ClassName("fltrt-opt-region"));
            list[1].FindElement(By.ClassName("fltrt-opt-fares-price-region")).Click();
            System.Threading.Thread.Sleep(5500);
            var list1 = driver.FindElement(By.CssSelector("#flightsResultsMaster > div > div > div:nth-child(4)")).FindElements(By.ClassName("fltrt-opt-region"));
            list1[1].FindElement(By.ClassName("fltrt-opt-fares-price-region")).Click();
            System.Threading.Thread.Sleep(5500);

            var fprice = double.Parse(FirstPriceC.Text, CultureInfo.InvariantCulture);
            var sprice = double.Parse(SecondPriceC.Text, CultureInfo.InvariantCulture);

            var val = fprice + sprice;
            var res = double.Parse(CurrentPriceC.Text, CultureInfo.InvariantCulture);

            return Math.Abs(val - res) < 0.01;
        }

        public bool ComparePricesSenior()
        {
            var list = driver.FindElement(By.CssSelector("#flightsResultsMaster > div > div > div:nth-child(4)")).FindElements(By.ClassName("fltrt-opt-region"));
            list[0].FindElement(By.ClassName("fltrt-opt-fares-price-region")).Click();
            System.Threading.Thread.Sleep(5500);
            var list1 = driver.FindElement(By.CssSelector("#flightsResultsMaster > div > div > div:nth-child(4)")).FindElements(By.ClassName("fltrt-opt-region"));
            list1[0].FindElement(By.ClassName("fltrt-opt-fares-price-region")).Click();
            System.Threading.Thread.Sleep(5500);

            var fprice = double.Parse(FirstPriceS.Text, CultureInfo.InvariantCulture);
            var sprice = double.Parse(SecondPriceS.Text, CultureInfo.InvariantCulture);

            var val = fprice + sprice;
            var res = double.Parse(CurrentPriceS.Text, CultureInfo.InvariantCulture);

            return Math.Abs(val - res) < 0.01;
        }
    }
}
